using System.Windows.Navigation;
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

            navigationWindow.Closing += WindowService.OnWindowClosingLogoutUserQuestion;
        }
    }
}
