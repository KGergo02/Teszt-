using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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

            Style tb = window.FindResource("TB") as Style;

            using (DatabaseContext database = new DatabaseContext())
            {
                List<Question> questions = database.GetQuestionsOfTest(test);

                questions = ListService.Shuffle(questions);
                
                for (int i = 0; i < questions.Count; i++)
                {
                    Border border = new Border()
                    {
                        BorderBrush = Brushes.White,
                        Margin = new Thickness(0,30,0,30),
                        BorderThickness = new Thickness(5),
                        CornerRadius = new CornerRadius(10),
                        HorizontalAlignment = HorizontalAlignment.Left,
                    };

                    StackPanel stackPanel = new StackPanel()
                    {
                        Margin = new Thickness(40, 0, 50, 20),
                    };

                    border.Child = stackPanel;

                    DockPanel.SetDock(border, Dock.Top);

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

                    for (int j = 0; j < answers.Count; j++)
                    {
                        Control answerOption = new Control();

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
                        else if (questions[i].QuestionType.Equals("Rövid választ igénylő feladat"))
                        {
                            answerOption = new TextBox()
                            {
                                Style = tb,
                                Tag = $"{answers[j].QuestionId}",
                            };
                        }

                        stackPanel.Children.Add(answerOption);
                    }

                    dockPanel.Children.Add(border);
                }
            }
        }
    }
}
