using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.Models;

namespace Teszt__.src.ViewModels
{
    public class HallgatoMainViewModel : ViewModelBase
    {
        private readonly Navigation _navigation;

        private readonly Func<ViewModelBase> _createViewModel;

        public HallgatoMainViewModel(Navigation navigation/*, Func<ViewModelBase> createViewModel*/)
        {
            _navigation = navigation;
            //_createViewModel = createViewModel;
        }
    }
}
