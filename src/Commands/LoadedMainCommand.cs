using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teszt__.src.DAL;
using static Teszt__.src.Models.DatabaseContext;

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
