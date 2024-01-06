using System.Threading.Tasks;
using System.Windows;
using Teszt__.src.DAL;
using Teszt__.src.Services;
using Teszt__.src.ViewModels;

namespace Teszt__.src.Commands
{
    class LoadedMainCommand : CommandBase
    {
        private bool needsLoading;

        public LoadedMainCommand(bool needsLoading)
        {
            this.needsLoading = needsLoading;
        }

        public override bool CanExecute(object parameter)
        {
            return needsLoading;
        }

        public override async void Execute(object parameter)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                await database.GetUserByNameAsync("KGergo02");
            }
        }
    }
}
