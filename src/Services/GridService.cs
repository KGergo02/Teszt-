using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Teszt__.src.Services
{
    public static class GridService
    {
        public static void ClearGrid(ref Grid grid, ref StackPanel stackPanel)
        {
            grid.Children.Clear();

            stackPanel.Children.Clear();

            grid.ColumnDefinitions.Clear();

            grid.RowDefinitions.Clear();
        }
    }
}
