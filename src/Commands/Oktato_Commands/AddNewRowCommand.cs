using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Teszt__.src.ViewModels.Oktato_ViewModels;
using Teszt__.src.Services;
using static Teszt__.src.Models.DatabaseContext;
using Teszt__.src.DAL;

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
                    AddAnswerRow(rowcount);
                    break;
            }
        }

        private void AddCourseRow(int rowcount)
        {
            RowDefinition rowdef = new RowDefinition();

            _grid.RowDefinitions.Add(rowdef);

            TextBox tb1 = new TextBox()
            {
                FontSize = 30,
                Width = 300,
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
                FontSize = 30,
                Width = 100,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
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

            TextBox testNameTb = new TextBox()
            {
                FontSize = 30,
                Width = 300,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(testNameTb, 0);
            Grid.SetRow(testNameTb, rowcount);

            TextBox submitLimitTb = new TextBox()
            {
                Tag = "number",
                FontSize = 30,
                Width = 100,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(submitLimitTb, 1);
            Grid.SetRow(submitLimitTb, rowcount);

            DatePicker date = new DatePicker()
            {
                FontSize = 30,
                Width = 300,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(date, 2);
            Grid.SetRow(date, rowcount);

            TextBox startTimeTb = new TextBox()
            {
                Tag = "time",
                Width = 100,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(startTimeTb, 3);
            Grid.SetRow(startTimeTb, rowcount);

            TextBox endTimeTb = new TextBox()
            {
                Tag = "time",
                Width = 100,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(endTimeTb, 4);
            Grid.SetRow(endTimeTb, rowcount);

            ComboBox CoursesComboBox = new ComboBox()
            {
                Width = 400,
                FontSize = 30,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
            };

            using (DatabaseContext database = new DatabaseContext())
            {
                foreach (Course item in database.Courses)
                {
                    CoursesComboBox.Items.Add(item.Name);
                }
            }

            Grid.SetColumn(CoursesComboBox, 5);
            Grid.SetRow(CoursesComboBox, rowcount);

            _grid.Children.Add(testNameTb);
            _grid.Children.Add(submitLimitTb);
            _grid.Children.Add(date);
            _grid.Children.Add(startTimeTb);
            _grid.Children.Add(endTimeTb);
            _grid.Children.Add(CoursesComboBox);
        }

        private void AddAnswerRow(int rowcount)
        {
            RowDefinition rowdef = new RowDefinition();

            if (_grid.Tag.ToString() == "checkbox")
            {
                _grid.RowDefinitions.Add(rowdef);

                TextBox tb = new TextBox()
                {
                    Width = 200,
                    FontSize = 30,
                    Margin = new System.Windows.Thickness(20),
                    TextWrapping = System.Windows.TextWrapping.Wrap,
                    VerticalAlignment = System.Windows.VerticalAlignment.Top,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                };

                Grid.SetColumn(tb, 1);
                Grid.SetRow(tb, rowcount);

                CheckBox cb = new CheckBox()
                {
                    Content = "Válasz?",
                    FontSize = 30,
                    Margin = new System.Windows.Thickness(20),
                    Foreground = System.Windows.Media.Brushes.White,
                    HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                    VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
                    VerticalAlignment = System.Windows.VerticalAlignment.Top,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                };

                Grid.SetColumn(cb, 2);
                Grid.SetRow(cb, rowcount);

                _grid.Children.Add(tb);
                _grid.Children.Add(cb);
            }
            else if(_grid.Tag.ToString() == "radiobutton")
            {
                _grid.RowDefinitions.Add(rowdef);

                TextBox tb = new TextBox()
                {
                    Width = 200,
                    FontSize = 30,
                    Margin = new System.Windows.Thickness(20),
                    TextWrapping = System.Windows.TextWrapping.Wrap,
                    VerticalAlignment = System.Windows.VerticalAlignment.Top,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                };

                Grid.SetColumn(tb, 1);
                Grid.SetRow(tb, rowcount);

                RadioButton cb = new RadioButton()
                {
                    Content = "Helyes válasz",
                    FontSize = 30,
                    Margin = new System.Windows.Thickness(20),
                    Foreground = System.Windows.Media.Brushes.White,
                    HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                    VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
                    VerticalAlignment = System.Windows.VerticalAlignment.Top,
                };

                Grid.SetColumn(cb, 2);
                Grid.SetRow(cb, rowcount);

                _grid.Children.Add(tb);
                _grid.Children.Add(cb);
            }
            else if(_grid.Tag.ToString() == "single")
            {
                Message.Error("Több választ nem adhatsz hozzá a kérdéshez!");
            }
        }
    }
}
