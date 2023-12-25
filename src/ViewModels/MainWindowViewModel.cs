using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using Teszt__.src.Commands;
using Teszt__.src.DAL;
using Teszt__.src.Services;
using Teszt__.src.Views;

namespace Teszt__.src.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private NavigationWindow _navigationWindow;

        public MainWindowViewModel(NavigationWindow navWindow)
        {
            _navigationWindow = navWindow;

            HallgatoLoginCommand = new BeforeLoginCommand(_navigationWindow, false);

            OktatoLoginCommand = new BeforeLoginCommand(_navigationWindow, true);

            LoadedMainCommand = new LoadedMainCommand();

            navWindow.Navigating += WindowService.OnWindowNavigation;
        }

        public ICommand HallgatoLoginCommand
        {
            get;
        }

        public ICommand OktatoLoginCommand
        {
            get;
        }

        public ICommand LoadedMainCommand
        {
            get;
        }
    }
}
