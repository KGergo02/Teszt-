using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Teszt__.src.Commands.Oktato_Commands
{
    class AddNewRowCommand : CommandBase
    {
        private Grid _grid;
        private int _modelType;

        public AddNewRowCommand(ref Grid grid, ref int modelType)
        {
            _grid = grid;

            _modelType = modelType;
        }


        public override void Execute(object parameter)
        {
            int rowcount = _grid.RowDefinitions.Count;

            switch (_modelType)
            {
                case 0:
                    AddCourseRow(rowcount);
                    break;
                case 1:
                    AddTestRow(rowcount);
                    break;
            }
        }

        private void AddCourseRow(int rowcount)
        {
            RowDefinition rowdef = new RowDefinition();

            _grid.RowDefinitions.Add(rowdef);

            TextBox tb1 = new TextBox();

            Grid.SetColumn(tb1, 0);

            Grid.SetRow(tb1, rowcount);

            _grid.Children.Add(tb1);

            TextBox tb2 = new TextBox()
            {
                Tag = "number"
            };

            Grid.SetColumn(tb2, 1);

            Grid.SetRow(tb2, rowcount);

            _grid.Children.Add(tb2);
        }

        private void AddTestRow(int rowcount)
        {
            RowDefinition rowdef = new RowDefinition();

            _grid.RowDefinitions.Add(rowdef);

            TextBox testNameTb = new TextBox();

            Grid.SetColumn(testNameTb, 0);
            Grid.SetRow(testNameTb, rowcount);

            TextBox submitLimitTb = new TextBox();

            Grid.SetColumn(submitLimitTb, 1);
            Grid.SetRow(submitLimitTb, rowcount);

            DatePicker date = new DatePicker();

            Grid.SetColumn(date, 2);
            Grid.SetRow(date, rowcount);

            TextBox startTimeTb = new TextBox();

            Grid.SetColumn(startTimeTb, 3);
            Grid.SetRow(startTimeTb, rowcount);

            TextBox endTimeTb = new TextBox();

            Grid.SetColumn(endTimeTb, 4);
            Grid.SetRow(endTimeTb, rowcount);

            _grid.Children.Add(testNameTb);
            _grid.Children.Add(submitLimitTb);
            _grid.Children.Add(date);
            _grid.Children.Add(startTimeTb);
            _grid.Children.Add(endTimeTb);
        }
    }
}
