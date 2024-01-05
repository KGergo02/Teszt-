using System.Windows;
using Teszt__.src.DAL;
using Teszt__.src.Services;
using Teszt__.src.ViewModels;

namespace Teszt__.src.Commands
{
    class LoadedMainCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
        {
            bool needsLoading = ((MainWindowViewModel)Application.Current.MainWindow.DataContext).NeedsLoading;

            ((MainWindowViewModel)Application.Current.MainWindow.DataContext).NeedsLoading = false;

            return needsLoading;
        }

        public override void Execute(object parameter)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                database.GetUserByName("KGergo02");
            }
        }
    }
}
