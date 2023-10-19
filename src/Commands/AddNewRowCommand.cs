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
        public AddNewRowCommand(ref Grid grid)
        {
            _grid = grid;
        }
        public Grid _grid { get; }

        public override void Execute(object parameter)
        {
            RowDefinition rowdef = new RowDefinition();

            _grid.RowDefinitions.Add(rowdef);

            TextBox tb1 = new TextBox();

            TextBox tb2 = new TextBox();

            Grid.SetRow(tb1, _grid.RowDefinitions.Count - 1);
                                                        
            Grid.SetRow(tb2, _grid.RowDefinitions.Count - 1);

            Grid.SetColumn(tb1, 0);

            Grid.SetColumn(tb2, 1);

            _grid.Children.Add(tb1);

            _grid.Children.Add(tb2);
        }
    }
}
