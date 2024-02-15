using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Teszt__.src.Commands;
using Teszt__.src.Commands.User_Commands;
using Teszt__.src.DAL;
using Teszt__.src.Services;
using Teszt__.src.Views.Hallgato_Views;
using static Teszt__.src.Models.DatabaseContext;

namespace Teszt__.src.ViewModels
{
    public class HallgatoMainViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _titleName;
        public string TitleName
        {
            get
            {
                return _titleName;
            }
            set
            {
                _titleName = value;
                OnPropertyChanged(nameof(TitleName));
            }
        }

        private User _user;

        private StackPanel _mainStackPanel;

        public HallgatoMainViewModel(HallgatoMainView window)
        {
            _user = UserService.GetCurrentUser();

            _username = _user.Name;

            _titleName = $"Főoldal - {_username}";

            _mainStackPanel = window.mainStackPanel;

            FillStackPanelWithCourseCards();

            ShowUserProfileCommand = new ShowUserProfileCommand();

            LogOutCommand = new LogOutCommand();

            NavigationService.GetNavigationWindow().Closing += WindowService.OnWindowClosingLogoutUserQuestion;
        }

        public ICommand ShowUserProfileCommand { get; }
        public ICommand LogOutCommand { get; }

        public void FillStackPanelWithCourseCards()
        {
            _mainStackPanel.Children.Clear();

            List<User_Course> user_courses;

            List<Result> results;

            using (DatabaseContext database = new DatabaseContext())
            {
                user_courses = database.GetUser_CourseListOfUser(_user);

                results = database.GetResultsOfUser(_user);
            }
            
            if(user_courses.Count == 0)
            {
                Label label = new Label()
                {
                    Content = "Nincs megjeleníthető kurzus",
                    FontWeight = FontWeights.Bold,
                    FontSize = 36,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Foreground = Brushes.White,
                    Margin = new Thickness(0, 70, 0, 0)
                };

                _mainStackPanel.Children.Add(label);
            }
            else
            {
                foreach (User_Course item in user_courses)
                {
                    Course course;

                    List<Test> tests;

                    List<Label> testLabels = new List<Label>();

                    using (DatabaseContext database = new DatabaseContext())
                    {
                        course = (Course)database.FindByName(item.Course_name, typeof(Course));

                        tests = database.GetTestsOfCourse(course);
                    }

                    Label courseLabel = new Label()
                    {
                        Content = course.Name,
                        FontWeight = FontWeights.Bold,
                        FontSize = 36,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Foreground = Brushes.Cyan,
                        Margin = new Thickness(0, 15, 0, 15),
                        Cursor = Cursors.Hand,
                    };

                    Rectangle line = new Rectangle()
                    {
                        Height = 4,
                        Fill = Brushes.White,
                    };

                    _mainStackPanel.Children.Add(courseLabel);
                    
                    _mainStackPanel.Children.Add(line);

                    if(tests.Count == 0)
                    {
                        Label testDescriptionLabel = new Label()
                        {
                            Content = "Nincs kitölthető teszt",
                            FontWeight = FontWeights.Bold,
                            FontSize = 25,
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Foreground = Brushes.White,
                            Margin = new Thickness(0, 10, 0, 0),
                        };

                        testLabels.Add(testDescriptionLabel);

                        _mainStackPanel.Children.Add(testDescriptionLabel);

                        courseLabel.Tag = testLabels;
                    }

                    foreach (Test test in tests)
                    {
                        Result currentResult = results.FindAll(result => result.TestId == test.Id).OrderByDescending(result => result.Value).FirstOrDefault();

                        int resultsCount = results.FindAll(result => result.TestId == test.Id).Count();

                        Label testLabel = new Label()
                        {
                            Content = currentResult == null ? test.Name : $"{test.Name}:\t[{currentResult.Value}]/[{DatabaseContext.CalculateMaxTestPoint(test)}]",
                            FontWeight = FontWeights.Bold,
                            FontSize = 25,
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Foreground = Brushes.White,
                            Margin = new Thickness(0, 10, 0, 0),
                            Cursor = resultsCount < test.Submit_Limit ? Cursors.Hand : Cursors.Arrow,
                            Tag = test,
                        };

                        Label testDescriptionLabel = new Label()
                        {
                            Content = currentResult == null ? $"Kitölthető: {test.Date}, ({test.StartTime} - {test.EndTime})" : resultsCount >= test.Submit_Limit ? $"Kitöltve: {currentResult.Date}" : $"Kitöltve: {currentResult.Date}\nEzt a tesztet még [{test.Submit_Limit - resultsCount}] alkalommal töltheted ki",
                            FontStyle = FontStyles.Italic,
                            FontSize = 20,
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = currentResult == null ? HorizontalAlignment.Center : HorizontalAlignment.Left,
                            Foreground = Brushes.White,
                            Margin = new Thickness(0, 0, 0, 15),
                            Cursor = resultsCount < test.Submit_Limit ? Cursors.Hand : Cursors.Arrow,
                            Tag = test,
                        };

                        if (resultsCount < test.Submit_Limit)
                        {
                            testLabel.MouseDown += TestService.TestLabelClickedEvent;

                            testDescriptionLabel.MouseDown += TestService.TestLabelClickedEvent; 
                        }

                        testLabels.Add(testLabel);

                        testLabels.Add(testDescriptionLabel);

                        courseLabel.Tag = testLabels;

                        _mainStackPanel.Children.Add(testLabel);

                        _mainStackPanel.Children.Add(testDescriptionLabel);

                    }

                    courseLabel.MouseDown += ControlEventService.OnCourseCardLabelClick;
                }
            }
        }
    }
}
