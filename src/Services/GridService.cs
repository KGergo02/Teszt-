using System.Windows.Controls;
using Teszt__.src.DAL;
using static Teszt__.src.Models.DatabaseContext;

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

        public static Grid CreateCourseGrid(ref Grid grid, ref StackPanel mainStackPanel)
        {
            Label labelCourseName = new Label()
            {
                Content = "Kurzus neve",
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Label labelCourseLimit = new Label()
            {
                Content = "Kurzus limit",
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            ColumnDefinition coldef1 = new ColumnDefinition();

            ColumnDefinition coldef2 = new ColumnDefinition();

            grid.ColumnDefinitions.Add(coldef1);

            grid.ColumnDefinitions.Add(coldef2);

            RowDefinition rowdef1 = new RowDefinition();

            RowDefinition rowdef2 = new RowDefinition();

            grid.RowDefinitions.Add(rowdef1);

            grid.RowDefinitions.Add(rowdef2);

            Grid.SetColumn(labelCourseName, 0);

            Grid.SetRow(labelCourseName, 0);

            Grid.SetColumn(labelCourseLimit, 1);

            Grid.SetRow(labelCourseLimit, 0);

            TextBox tb1 = new TextBox()
            {
                FontSize = 30,
                Width = 300,
                Margin = new System.Windows.Thickness(5),
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

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

            Grid.SetColumn(tb1, 0);

            Grid.SetRow(tb1, 1);

            Grid.SetColumn(tb2, 1);

            Grid.SetRow(tb2, 1);

            grid.Children.Add(labelCourseName);

            grid.Children.Add(labelCourseLimit);

            grid.Children.Add(tb1);

            grid.Children.Add(tb2);

            mainStackPanel.Children.Add(grid);

            return grid;
        }

        public static Grid CreateTestGrid(ref Grid grid, ref StackPanel mainStackPanel)
        {
            ColumnDefinition coldef1 = new ColumnDefinition();
            ColumnDefinition coldef2 = new ColumnDefinition();
            ColumnDefinition coldef3 = new ColumnDefinition();
            ColumnDefinition coldef4 = new ColumnDefinition();
            ColumnDefinition coldef5 = new ColumnDefinition();
            ColumnDefinition coldef6 = new ColumnDefinition();

            grid.ColumnDefinitions.Add(coldef1);
            grid.ColumnDefinitions.Add(coldef2);
            grid.ColumnDefinitions.Add(coldef3);
            grid.ColumnDefinitions.Add(coldef4);
            grid.ColumnDefinitions.Add(coldef5);
            grid.ColumnDefinitions.Add(coldef6);

            RowDefinition rowdef1 = new RowDefinition();
            RowDefinition rowdef2 = new RowDefinition();

            grid.RowDefinitions.Add(rowdef1);
            grid.RowDefinitions.Add(rowdef2);

            Label testName = new Label()
            {
                Content = "Teszt neve",
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(testName, 0);

            Grid.SetRow(testName, 0);

            Label submitLimitLabel = new Label()
            {
                Content = "Kitöltési limit",
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(submitLimitLabel, 1);

            Grid.SetRow(submitLimitLabel, 0);

            Label dateLabel = new Label()
            {
                Content = "Teszt időpontja",
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(dateLabel, 2);

            Grid.SetRow(dateLabel, 0);

            Label startTimeLabel = new Label()
            {
                Content = "Indítási idő",
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(startTimeLabel, 3);

            Grid.SetRow(startTimeLabel, 0);

            Label endTimeLabel = new Label()
            {
                Content = "Kitölthető eddig",
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(endTimeLabel, 4);

            Grid.SetRow(endTimeLabel, 0);

            Label CourseLabel = new Label()
            {
                Content = "Kurzus",
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(endTimeLabel, 5);

            Grid.SetRow(endTimeLabel, 0);

            TextBox testNameTb = new TextBox()
            {
                FontSize = 30,
                Width = 300,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(testNameTb, 0);
            Grid.SetRow(testNameTb, 1);

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
            Grid.SetRow(submitLimitTb, 1);

            DatePicker date = new DatePicker()
            {
                FontSize = 30,
                Width = 300,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(date, 2);
            Grid.SetRow(date, 1);

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
            Grid.SetRow(startTimeTb, 1);

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
            Grid.SetRow(endTimeTb, 1);

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
            Grid.SetRow(CoursesComboBox, 1);

            grid.Children.Add(testName);
            grid.Children.Add(submitLimitLabel);
            grid.Children.Add(dateLabel);
            grid.Children.Add(startTimeLabel);
            grid.Children.Add(endTimeLabel);

            grid.Children.Add(testNameTb);
            grid.Children.Add(submitLimitTb);
            grid.Children.Add(date);
            grid.Children.Add(startTimeTb);
            grid.Children.Add(endTimeTb);

            mainStackPanel.Children.Add(grid);

            return grid;
        }

        private static Grid _grid;

        private static Grid CreateQuestionControls(Grid grid, StackPanel mainStackPanel)
        {
            ColumnDefinition coldef1 = new ColumnDefinition()
            {
                Width = new System.Windows.GridLength(300),
            };
            ColumnDefinition coldef2 = new ColumnDefinition();
            ColumnDefinition coldef3 = new ColumnDefinition();

            _grid.ColumnDefinitions.Add(coldef1);
            _grid.ColumnDefinitions.Add(coldef2);
            _grid.ColumnDefinitions.Add(coldef3);

            RowDefinition rowdef1 = new RowDefinition();
            RowDefinition rowdef2 = new RowDefinition()
            {
                Height = new System.Windows.GridLength(50),
            };
            RowDefinition rowdef3 = new RowDefinition();
            RowDefinition rowdef4 = new RowDefinition();
            RowDefinition rowdef5 = new RowDefinition()
            {
                Height = new System.Windows.GridLength(50),
            };
            RowDefinition rowdef6 = new RowDefinition();
            RowDefinition rowdef7 = new RowDefinition();
            RowDefinition rowdef8 = new RowDefinition();
            _grid.RowDefinitions.Add(rowdef1);
            _grid.RowDefinitions.Add(rowdef2);
            _grid.RowDefinitions.Add(rowdef3);
            _grid.RowDefinitions.Add(rowdef4);
            _grid.RowDefinitions.Add(rowdef5);
            _grid.RowDefinitions.Add(rowdef6);
            _grid.RowDefinitions.Add(rowdef7);
            _grid.RowDefinitions.Add(rowdef8);

            Label QTypeLabel = new Label()
            {
                Content = "Kérdés típusa",
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
            };

            Grid.SetColumn(QTypeLabel, 0);
            Grid.SetRow(QTypeLabel, 0);

            grid.Children.Add(QTypeLabel);

            mainStackPanel.Children.Add(grid);

            return grid;
        }

        public static Grid CreateQuestionGrid(Grid grid, StackPanel mainStackPanel)
        {
            grid.Children.Clear();

            _grid = grid;

            grid = CreateQuestionControls(grid, mainStackPanel);

            ComboBox CBType = new ComboBox()
            {
                Width = 400,
                FontSize = 30,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
            };

            CBType.Items.Add("Jelölődoboz");
            CBType.Items.Add("Rádiógomb");
            CBType.Items.Add("Szöveges válasz");

            CBType.SelectionChanged += (sender, e) => CBType_SelectionChanged(sender);

            Grid.SetColumn(CBType, 0);

            Grid.SetRow(CBType, 1);

            _grid.Children.Add(CBType);

            Label TestLabel = new Label()
            {
                Content = "Válaszd ki a tesztet",
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
            };

            Grid.SetColumn(TestLabel, 0);
            Grid.SetRow(TestLabel, 2);

            _grid.Children.Add(TestLabel);

            ComboBox TestComboBox = new ComboBox()
            {
                Width = 400,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
            };

            using (DatabaseContext testDatabaseContext = new DatabaseContext())
            {
                foreach (Test item in testDatabaseContext.Tests)
                {
                    TestComboBox.Items.Add(item.Name);
                }
            }    

            Grid.SetColumn(TestComboBox, 0);
            Grid.SetRow(TestComboBox, 3);

            _grid.Children.Add(TestComboBox);

            Label QNameLabel = new Label()
            {
                Content = "Kérdés",
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 30,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
            };

            Grid.SetColumn(QNameLabel, 0);
            Grid.SetRow(QNameLabel, 5);

            _grid.Children.Add(QNameLabel);

            TextBox QNameTB = new TextBox()
            {
                FontSize = 30,
                Width = 300,
                Height = 250,
                AcceptsReturn = true,
                TextWrapping = System.Windows.TextWrapping.Wrap,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
            };

            Grid.SetColumn(QNameTB, 0);
            Grid.SetRow(QNameTB, 6);

            _grid.Children.Add(QNameTB);

            CBType.SelectedIndex = 0;

            return _grid;
        }

        private static void CBType_SelectionChanged(object sender)
        {
            ComboBox cb = (ComboBox)sender;

            switch (cb.SelectedValue)
            {
                case "Jelölődoboz":
                    CreateQuestionGridCheckBoxControls();
                    _grid.Tag = "checkbox";
                    break;
                case "Rádiógomb":
                    CreateQuestionGridRadioButtonControls();
                    _grid.Tag = "radiobutton";
                    break;
                case "Szöveges válasz":
                    CreateQuestionTextBoxControls();
                    _grid.Tag = "single";
                    break;
            }
        }

        private static void CreateQuestionGridCheckBoxControls()
        {
            if(_grid.Children.Count > 6)
            {
                _grid.Children.RemoveRange(6, _grid.Children.Count - 6);
            }

            Label ValaszokLabel = new Label()
            {
                Content = "Válaszlehetőségek",
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(ValaszokLabel, 1);
            Grid.SetRow(ValaszokLabel, 6);

            _grid.Children.Add(ValaszokLabel);

            TextBox tb = new TextBox()
            {
                Width = 200,
                FontSize = 30,
                Margin = new System.Windows.Thickness(30),
                TextWrapping = System.Windows.TextWrapping.Wrap,
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(tb, 1);
            Grid.SetRow(tb, 6);

            _grid.Children.Add(tb);

            CheckBox cb = new CheckBox()
            {
                Content = "Válasz?",
                FontSize = 30,
                Height = 100,
                Width = 120,
                Foreground = System.Windows.Media.Brushes.White,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
            };

            Grid.SetColumn(cb, 2);
            Grid.SetRow(cb, 6);

            _grid.Children.Add(cb);
        }

        private static void CreateQuestionGridRadioButtonControls()
        {
            _grid.Children.RemoveRange(6, _grid.Children.Count - 6);
            
            Label ValaszokLabel = new Label()
            {
                Content = "Válaszlehetőségek",
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(ValaszokLabel, 1);
            Grid.SetRow(ValaszokLabel, 6);

            _grid.Children.Add(ValaszokLabel);

            TextBox tb = new TextBox()
            {
                Width = 200,
                FontSize = 30,
                Margin = new System.Windows.Thickness(30),
                TextWrapping = System.Windows.TextWrapping.Wrap,
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(tb, 1);
            Grid.SetRow(tb, 6);

            _grid.Children.Add(tb);

            RadioButton cb = new RadioButton()
            {
                Content = "Helyes válasz",
                FontSize = 30,
                Height = 100,
                Width = 200,
                Foreground = System.Windows.Media.Brushes.White,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
            };

            Grid.SetColumn(cb, 2);
            Grid.SetRow(cb, 6);

            _grid.Children.Add(cb);
        }

        private static void CreateQuestionTextBoxControls()
        {
            _grid.Children.RemoveRange(6, _grid.Children.Count - 6);
            
            Label label = new Label()
            {
                Content = "Válasz",
                Foreground = System.Windows.Media.Brushes.White,
                FontSize = 30,
                Margin = new System.Windows.Thickness(50),
                VerticalAlignment = System.Windows.VerticalAlignment.Top,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(label, 1);
            Grid.SetRow(label, 6);

            TextBox tb = new TextBox()
            {
                Width = 300,
                Height = 100,
                Margin = new System.Windows.Thickness(30),
                TextWrapping = System.Windows.TextWrapping.Wrap,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(tb, 1);
            Grid.SetRow(tb, 6);

            _grid.Children.Add(label);
            _grid.Children.Add(tb);
        }
    }
}
