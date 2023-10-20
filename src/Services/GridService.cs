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
            stackPanel.Children.RemoveRange(0, stackPanel.Children.Count);

            grid.ColumnDefinitions.Clear();

            grid.RowDefinitions.Clear();
        }
    }
}
