using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Teszt__.src.DAL;
using static Teszt__.src.Models.DatabaseContext;

namespace Teszt__.src.Services
{
    public class QuestionService
    {
        public static void CreateQuestionCards(Test test, ref DockPanel dockPanel, Views.Hallgato_Views.TestView window)
        {
            Style h1 = window.FindResource("h1") as Style;
            
            Style h2 = window.FindResource("h2") as Style;
            
            Style cb = window.FindResource("CB") as Style;

            Style rb = window.FindResource("RB") as Style;

            using (DatabaseContext database = new DatabaseContext())
            {
                List<Question> questions = database.GetQuestionsOfTest(test);

                questions = ListService.Shuffle(questions);
                
                for (int i = 0; i < questions.Count; i++)
                {
                    StackPanel stackPanel = new StackPanel()
                    {
                        Margin = new Thickness(0, 0, 0, 40),
                    };

                    DockPanel.SetDock(stackPanel, Dock.Top);

                    Label questionNumberLabel = new Label()
                    {
                        Style = h1,
                        Content = $"{i + 1}. Feladat",
                    };

                    Label questionLabel = new Label()
                    {
                        Style = h2,
                        Content = $"{questions[i].Name}",
                    };

                    stackPanel.Children.Add(questionNumberLabel);

                    stackPanel.Children.Add(questionLabel);

                    List<Answer> answers = database.GetAnswersOfQuestion(questions[i]);

                    answers = ListService.Shuffle(answers);

                    Dictionary<string, int> questionDetails = new Dictionary<string, int>();

                    for (int j = 0; j < answers.Count; j++)
                    {
                        Control answerOption = null;

                        questionDetails.Clear();

                        questionDetails.Add("Id", answers[j].Id);

                        questionDetails.Add("QuestionId", answers[j].QuestionId);

                        if (questions[i].QuestionType.Equals("Rádiógomb"))
                        {
                            answerOption = new RadioButton()
                            {
                                Style = rb,
                                Content = $"{answers[j].Value}",
                                Tag = $"{answers[j].QuestionId}",
                            };
                        }
                        else if (questions[i].QuestionType.Equals("Jelölődoboz"))
                        {
                            answerOption = new CheckBox()
                            {
                                Style = cb,
                                Content = $"{answers[j].Value}",
                                Tag = $"{answers[j].QuestionId}",
                            };
                        }

                        stackPanel.Children.Add(answerOption);
                    }

                    dockPanel.Children.Add(stackPanel);
                }
            }
        }
    }
}
