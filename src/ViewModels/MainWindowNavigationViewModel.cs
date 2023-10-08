using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.Models;

namespace Teszt__.src.ViewModels
{
    public class MainWindowNavigationViewModel : ViewModelBase
    {
        private readonly Navigation _navigation;

        public ViewModelBase CurrentViewModel => _navigation.CurrentViewModel;

        public MainWindowNavigationViewModel(Navigation navigation, Func<HallgatoMainViewModel> createViewModel)
        {
            _navigation = navigation;

            _navigation.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
