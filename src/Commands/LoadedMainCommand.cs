using Teszt__.src.DAL;

namespace Teszt__.src.Commands
{
    class LoadedMainCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                database.GetUserByName("KGergo02");
            }
        }
    }
}
