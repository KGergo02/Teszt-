using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.Models;
using Teszt__.src.ViewModels;

namespace Teszt__.src.Services
{
    public class NavigationService
    {
        private readonly Navigation _navigation;

        private readonly Func<ViewModelBase> _createViewModel;

        public NavigationService(Navigation navigation, Func<ViewModelBase> createViewModel)
        {
            _navigation = navigation;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigation.CurrentViewModel = _createViewModel();
        }
    }
}
