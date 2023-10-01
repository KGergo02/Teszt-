using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Teszt__.src.Commands;

namespace Teszt__.src.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            HallgatoLoginCommand = new HallgatoLoginCommand();

            OktatoLoginCommand = new OktatoLoginCommand();
        }

        public ICommand HallgatoLoginCommand
        {
            get;
        }

        public ICommand OktatoLoginCommand
        {
            get;
        }
    }
}
