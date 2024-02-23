using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Teszt__.src.DAL;
using Teszt__.src.Services;
using Teszt__.src.ViewModels.Oktato_ViewModels;
using Teszt__.src.Views.Oktato_Views;
using static Teszt__.src.Models.DatabaseContext;

namespace Teszt__.src.Commands.Oktato_Commands
{
    public class ShowResultsCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            ShowDataView window = new ShowDataView();

            window.DataContext = new ShowDataViewModel("results", window.mainStackPanel, window.sendButton);

            window.ShowDialog();
        }
    }
}
