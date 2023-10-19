using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Teszt__.src.Models;

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
            
            _username = user.name;

            _titleName = $"Főoldal - {user.name}";
        }
    }
}
