using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Teszt__.src.Commands.Hallgato_Commands;
using Teszt__.src.Views.Hallgato_Views;

namespace Teszt__.src.ViewModels.Hallgato_ViewModels
{
    public class ResultViewModel
    {
        public string Result { get; set; }
        
        public string Percentage { get; set; }

        public ResultViewModel(int elertPontszam, int elerhetoPontszam, ResultView resultView)
        {
            Result = $"{elertPontszam} / {elerhetoPontszam}";

            Percentage = $"{Convert.ToInt32(Math.Round((double)elertPontszam / elerhetoPontszam * 100,2))}%";

            CloseResultWindowCommand = new CloseResultWindowCommand(resultView);
        }

        public static void CloseWindow(object sender)
        {

        }

        public ICommand CloseResultWindowCommand { get; }
    }
}
