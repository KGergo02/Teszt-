using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Teszt__.src.ViewModels.Oktato_ViewModels;
using Teszt__.src.Services;

namespace Teszt__.src.Commands.Oktato_Commands
{
    class AddNewRowCommand : CommandBase
    {
        private Grid _grid;
        private OktatoMainViewModel _viewModel;

        public AddNewRowCommand(ref Grid grid, OktatoMainViewModel viewModel)
        {
            _grid = grid;

            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            int rowcount = _grid.RowDefinitions.Count;

            switch (_viewModel.modelType)
            {
                case 0:
                    AddCourseRow(rowcount);
                    break;
                case 1:
                    AddTestRow(rowcount);
                    break;
                case 2:
                    AddAnswerRow();
                    break;
            }
        }

        private void AddCourseRow(int rowcount)
        {
            RowDefinition rowdef = new RowDefinition();

            _grid.RowDefinitions.Add(rowdef);

            TextBox tb1 = new TextBox()
            {
                FontSize = 10,
                Width = 100,
                Margin = new System.Windows.Thickness(5),
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(tb1, 0);

            Grid.SetRow(tb1, rowcount);

            _grid.Children.Add(tb1);

            TextBox tb2 = new TextBox()
            {
                Tag = "number",
                FontSize = 10,
                Width = 100,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
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

            TextBox submitLimitTb = new TextBox()
            {
                Tag = "number",
                FontSize = 10,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(submitLimitTb, 1);
            Grid.SetRow(submitLimitTb, rowcount);

            DatePicker date = new DatePicker()
            {
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(date, 2);
            Grid.SetRow(date, rowcount);

            TextBox startTimeTb = new TextBox()
            {
                Tag = "time",
                FontSize = 10,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(startTimeTb, 3);
            Grid.SetRow(startTimeTb, rowcount);

            TextBox endTimeTb = new TextBox()
            {
                Tag = "time",
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(endTimeTb, 4);
            Grid.SetRow(endTimeTb, rowcount);

            _grid.Children.Add(testNameTb);
            _grid.Children.Add(submitLimitTb);
            _grid.Children.Add(date);
            _grid.Children.Add(startTimeTb);
            _grid.Children.Add(endTimeTb);
        }

        private void AddAnswerRow()
        {
            Grid grid = (Grid)_grid.Children[4];

            RowDefinition rowdef = new RowDefinition();

            int rowcount = grid.RowDefinitions.Count;

            if (grid.Tag.ToString() == "checkbox" || grid.Tag.ToString() == "radiobutton")
            {
                grid.RowDefinitions.Add(rowdef);

                TextBox tb = new TextBox()
                {
                    FontSize = 10,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                };

                Grid.SetColumn(tb, 1);
                Grid.SetRow(tb, rowcount);

                CheckBox cb = new CheckBox()
                {
                    Content = "Válasz?",
                    FontSize = 10,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                };

                Grid.SetColumn(cb, 2);
                Grid.SetRow(cb, rowcount);

                grid.Children.Add(tb);
                grid.Children.Add(cb);
            }
            else if(grid.Tag.ToString() == "single")
            {
                Message.Error("Több választ nem adhatsz hozzá!");
            }
        }
    }
}
