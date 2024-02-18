using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using Teszt__.src.DAL;
using Teszt__.src.ViewModels;
using Teszt__.src.ViewModels.Hallgato_ViewModels;
using Teszt__.src.Views;
using Teszt__.src.Views.Hallgato_Views;
using static Teszt__.src.Models.DatabaseContext;

namespace Teszt__.src.Services
{
    public static class TestService
    {
        public static void TestLabelClickedEvent(object sender, MouseButtonEventArgs e)
        {
            Label label = (Label)sender;
            
            Test test = (Test)label.Tag;

            MessageBoxResult result = Message.Question($"Biztos indítani szeretnéd a {test.Name} nevű tesztet?\n\nEgy teszt indítása több időt is igénybe vehet, kérem várjon!");
            
            if(result == MessageBoxResult.Yes)
            {
                CheckTimeOfTest(test);
            }
        }

        public static async void CheckTimeOfTest(Test test)
        {
            DateTime currentTime = await UserService.GetCurrentTimeAsync();

            DateTime startDateTime = test.GetStartDateTime();

            DateTime endDateTime = test.GetEndDateTime();

            if(startDateTime <= currentTime && currentTime < endDateTime)
            {
                StartTest(test);
            }
            else if(startDateTime > currentTime)
            {
                Message.Error($"A kezdési idő előtt a teszt nem indítható!\n\nIndítható:\n{test.StartDate.Replace(" ", "")} ({test.StartTime} - {test.EndTime})");
            }
            else if(currentTime > endDateTime)
            {
                Message.Error($"A teszt határideje lejárt!");
            }
        }

        public static void StartTest(Test test)
        {
            NavigationService.GetNavigationWindow().Closing -= WindowService.OnWindowClosingLogoutUserQuestion;

            NavigationService.GetNavigationWindow().Closing += WindowService.OnTestClosing;

            NavigationService.NavigateToTestView(test);
        }

        public static void EndTest(Test test, TestView window)
        {
            ((TestViewModel)window.DataContext).Timer.Stop();

            int pontSzam = 0;

            int elerhetoPontszam = DatabaseContext.CalculateMaxTestPoint(test);

            List<Answer> userAnswers = new List<Answer>();

            foreach (Border border in window.mainDockPanel.Children)
            {
                StackPanel stackPanel = (StackPanel)border.Child;

                foreach (Control item in stackPanel.Children)
                {
                    if(item.Tag != null)
                    {
                        Answer answer = new Answer();

                        answer.QuestionId = Convert.ToInt32(item.Tag.ToString());

                        if (item is RadioButton radioButton)
                        {
                            answer.Value = radioButton.Content.ToString();
                            
                            answer.Correct = radioButton.IsChecked.Equals(true);
                        }
                        else if(item is CheckBox checkBox)
                        {
                            answer.Value = checkBox.Content.ToString();

                            answer.Correct = checkBox.IsChecked.Equals(true);
                        }
                        else if (item is TextBox textBox)
                        {
                            answer.Value = textBox.Text;

                            if(answer.Value == String.Empty)
                            {
                                answer.Correct = false;

                                break;
                            }

                            using (DatabaseContext database = new DatabaseContext())
                            {
                                Answer correctAnswer = database.Answers.ToList().Find(answ => answ.Value.ToUpper() == answer.Value.ToUpper() && answ.QuestionId == answer.QuestionId);

                                if(correctAnswer != null)
                                {
                                    answer.Correct = true;
                                }
                                else
                                {
                                    answer.Correct = false;
                                }
                            }
                        }

                        userAnswers.Add(answer);
                    }
                }

                Question question = null;

                bool answeredCorrectly = true;

                foreach (Answer answer in userAnswers)
                {
                    using (DatabaseContext database = new DatabaseContext())
                    {
                        if(question == null)
                        {
                            question = (Question)database.FindById(answer.QuestionId, typeof(Question));
                        }

                        List<Answer> answers = database.GetAnswersOfQuestion(question);

                        Answer correctAnswer = answers.Find(
                            item =>
                            item.QuestionId == answer.QuestionId &&
                            question.QuestionType == "Rövid választ igénylő feladat" ? 
                            item.Value.ToUpper() == answer.Value.ToUpper() : item.Value == answer.Value
                            );

                        if(correctAnswer == null || !correctAnswer.Equals(answer))
                        {
                            answeredCorrectly = false;
                        }
                    }
                }

                if (question != null && answeredCorrectly)
                {
                    pontSzam += question.Value;
                }

                answeredCorrectly = true;

                userAnswers.Clear();
            }

            NavigationService.GetNavigationWindow().Closing -= WindowService.OnTestClosing;

            DatabaseContext.SaveResult(new Result(UserService.GetCurrentUser().Name, pontSzam, test.Id, DateTime.Now.ToString()));

            NavigationService.NavigateToHallgatoView();

            ResultView resultView = new ResultView();

            resultView.DataContext = new ResultViewModel(pontSzam, elerhetoPontszam, resultView, test.Id);

            resultView.ShowDialog();
        }
    }
}
