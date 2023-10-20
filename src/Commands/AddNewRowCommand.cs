using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Teszt__.src.Commands
{
    class AddNewRowCommand : CommandBase
    {
        public AddNewRowCommand(Grid grid)
        {
            _grid = grid;
        }
        private Grid _grid;

        public override void Execute(object parameter)
        {
            int rowcount = _grid.RowDefinitions.Count + 1;

            for (int i = 0; i < _grid.ColumnDefinitions.Count; i++)
            {
                RowDefinition rowdef = new RowDefinition();

                _grid.RowDefinitions.Add(rowdef);

                TextBox tb1 = new TextBox();

                Grid.SetRow(tb1, rowcount - 1);

                Grid.SetColumn(tb1, i);

                _grid.Children.Add(tb1);
            }
        }
    }
}
