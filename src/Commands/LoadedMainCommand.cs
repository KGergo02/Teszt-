using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.DAL;

namespace Teszt__.src.Commands
{
    class LoadedMainCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            UserDatabaseContext database = new UserDatabaseContext();

            database.GetUserByName("KGergo02");
        }
    }
}
