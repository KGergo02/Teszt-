using System.Windows.Input;
using System.Windows.Navigation;
using Teszt__.src.Commands;
using Teszt__.src.Commands.User_Commands;
using Teszt__.src.Services;
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

        private NavigationWindow _navigationWindow;

        public HallgatoMainViewModel(User user, NavigationWindow navigationWindow)
        {
            _navigationWindow = navigationWindow;
            
            _username = user.Name;

            _titleName = $"Főoldal - {user.Name}";

            _navigationWindow.Closing += WindowService.OnWindowClosingLogoutUserQuestion;

            ShowUserProfileCommand = new ShowUserProfileCommand(ref user);

            LogOutCommand = new LogOutCommand(navigationWindow);
        }

        public ICommand ShowUserProfileCommand { get; }
        public ICommand LogOutCommand { get; }
    }
}
