using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
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

        private NavigationWindow _navigationWindow;

        private StackPanel _mainStackPanel;

        public HallgatoMainViewModel(ref User user, HallgatoMainView window)
        {
            _navigationWindow = navigationWindow;
            
            _username = user.Name;

            _titleName = $"Főoldal - {_username}";

            _mainStackPanel = window.mainStackPanel;

            _user = user;

            FillStackPanelWithCourseCards();

            NavigationService.GetNavigationWindow().Closing += WindowService.OnWindowClosingLogoutUserQuestion;

            ShowUserProfileCommand = new ShowUserProfileCommand(ref user);

            LogOutCommand = new LogOutCommand();
        }

        public ICommand ShowUserProfileCommand { get; }
        public ICommand LogOutCommand { get; }

        public void FillStackPanelWithCourseCards()
        {
            List<User_Course> user_courses;

            using (DatabaseContext database = new DatabaseContext())
            {
                user_courses = database.GetUser_CourseListOfUser(_user);
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
                    Foreground = System.Windows.Media.Brushes.White,
                    Margin = new Thickness(0, 70, 0, 0)
                };

                _mainStackPanel.Children.Add(label);
            }
        }
    }
}
