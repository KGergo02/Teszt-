using System.Threading.Tasks;
using System.Windows;
using Teszt__.src.DAL;
using Teszt__.src.Services;
using Teszt__.src.ViewModels;

namespace Teszt__.src.Commands
{
    class LoadedMainCommand
    {
        public bool CanExecute()
        {
            bool needsLoading = ((MainWindowViewModel)Application.Current.MainWindow.DataContext).NeedsLoading;

            ((MainWindowViewModel)Application.Current.MainWindow.DataContext).NeedsLoading = false;

            return needsLoading;
        }

        public async Task Execute()
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                await database.GetUserByNameAsync("KGergo02");
            }
        }
    }
}
