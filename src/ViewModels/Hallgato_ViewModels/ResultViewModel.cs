using System;
using System.Windows.Input;
using Teszt__.src.Commands.Hallgato_Commands;
using Teszt__.src.Views.Hallgato_Views;

namespace Teszt__.src.ViewModels.Hallgato_ViewModels
{
    public class ResultViewModel
    {
        public string Result { get; set; }
        
        public string Percentage { get; set; }

        public ResultViewModel(int elertPontszam, int elerhetoPontszam, ResultView resultView, int testId)
        {
            Result = $"{0} / {0}";

            Percentage = $"{0}%";

            if (elerhetoPontszam > 0)
            {
                Result = $"{elertPontszam} / {elerhetoPontszam}";

                Percentage = $"{Convert.ToInt32(Math.Round((double)elertPontszam / elerhetoPontszam * 100, 2))}%";
            }

            CloseResultWindowCommand = new CloseResultWindowCommand(resultView);
        }

        public ICommand CloseResultWindowCommand { get; }
    }
}
