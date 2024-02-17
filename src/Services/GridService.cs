using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
                Foreground = Brushes.White,
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Label labelCourseLimit = new Label()
            {
                Content = "Kurzus limit",
                Foreground = Brushes.White,
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
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
                Margin = new Thickness(5),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            TextBox tb2 = new TextBox()
            {
                Tag = "number",
                FontSize = 30,
                Width = 100,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
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

            grid.ColumnDefinitions.Add(coldef1);
            grid.ColumnDefinitions.Add(coldef2);
            grid.ColumnDefinitions.Add(coldef3);
            grid.ColumnDefinitions.Add(coldef4);

            RowDefinition rowdef1 = new RowDefinition();
            RowDefinition rowdef2 = new RowDefinition();
            RowDefinition rowdef3 = new RowDefinition();
            RowDefinition rowdef4 = new RowDefinition();

            grid.RowDefinitions.Add(rowdef1);
            grid.RowDefinitions.Add(rowdef2);
            grid.RowDefinitions.Add(rowdef3);
            grid.RowDefinitions.Add(rowdef4);

            Label CourseLabel = new Label()
            {
                Content = "Kurzus kiválasztása:",
                Foreground = Brushes.White,
                FontSize = 30,
                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            Grid.SetColumn(CourseLabel, 0);

            Grid.SetRow(CourseLabel, 0);

            ComboBox CoursesComboBox = new ComboBox()
            {
                Width = 200,
                FontSize = 30,
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
            };

            using (DatabaseContext database = new DatabaseContext())
            {
                foreach (Course item in database.Courses)
                {
                    CoursesComboBox.Items.Add(item.Name);
                }
            }

            Grid.SetColumn(CoursesComboBox, 1);
            Grid.SetRow(CoursesComboBox, 0);

            Label bestResultCountsLabel = new Label()
            {
                Content = "Legjobb eredmény számít?",
                Foreground = Brushes.White,
                Margin = new Thickness(20),
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            Grid.SetColumn(bestResultCountsLabel, 2);
            Grid.SetRow(bestResultCountsLabel, 0);

            CheckBox bestResultCountsCheckBox = new CheckBox()
            {
                VerticalContentAlignment = VerticalAlignment.Center,
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            ScaleTransform scale = new ScaleTransform(2.0, 2.0);

            bestResultCountsCheckBox.RenderTransformOrigin = new Point(0.5, 0.5);
            bestResultCountsCheckBox.RenderTransform = scale;

            Grid.SetColumn(bestResultCountsCheckBox, 3);
            Grid.SetRow(bestResultCountsCheckBox, 0);

            Label testName = new Label()
            {
                Content = "Teszt neve:",
                Foreground = Brushes.White,
                FontSize = 30,
                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            Grid.SetColumn(testName, 0);

            Grid.SetRow(testName, 1);

            TextBox testNameTb = new TextBox()
            {
                FontSize = 30,
                Width = 200,
                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(testNameTb, 1);
            Grid.SetRow(testNameTb, 1);

            Label submitLimitLabel = new Label()
            {
                Content = "Kitöltési limit:",
                Foreground = Brushes.White,
                Margin = new Thickness(20),
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            Grid.SetColumn(submitLimitLabel, 2);

            Grid.SetRow(submitLimitLabel, 1);

            TextBox submitLimitTb = new TextBox()
            {
                Tag = "number",
                FontSize = 30,
                Width = 100,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            Grid.SetColumn(submitLimitTb, 3);
            Grid.SetRow(submitLimitTb, 1);

            Label startDateLabel = new Label()
            {
                Content = "Teszt kezdési napja:",
                Foreground = Brushes.White,
                FontSize = 30,
                Margin = new Thickness(20),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            Grid.SetColumn(startDateLabel, 0);

            Grid.SetRow(startDateLabel, 2);

            DatePicker startDatePicker = new DatePicker()
            {
                FontSize = 30,
                Width = 200,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(startDatePicker, 1);
            Grid.SetRow(startDatePicker, 2);

            Label startTimeLabel = new Label()
            {
                Content = "Indítási idő (óó:pp):",
                Foreground = Brushes.White,
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            Grid.SetColumn(startTimeLabel, 2);

            Grid.SetRow(startTimeLabel, 2);

            TextBox startTimeTb = new TextBox()
            {
                Text = "00:00",
                Tag = "time",
                Width = 100,
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(startTimeTb, 3);
            Grid.SetRow(startTimeTb, 2);

            Label endDateLabel = new Label()
            {
                Content = "Teszt befejezési napja:",
                Foreground = Brushes.White,
                FontSize = 30,
                Margin = new Thickness(20),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            Grid.SetColumn(endDateLabel, 0);

            Grid.SetRow(endDateLabel, 3);

            DatePicker endDatePicker = new DatePicker()
            {
                FontSize = 30,
                Width = 200,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(endDatePicker, 1);
            Grid.SetRow(endDatePicker, 3);

            Label endTimeLabel = new Label()
            {
                Content = "Kitölthető eddig (óó:pp):",
                Foreground = Brushes.White,
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            Grid.SetColumn(endTimeLabel, 2);

            Grid.SetRow(endTimeLabel, 3);

            TextBox endTimeTb = new TextBox()
            {
                Text = "23:59",
                Tag = "time",
                Width = 100,
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(endTimeTb, 3);
            Grid.SetRow(endTimeTb, 3);



            grid.Children.Add(CourseLabel);
            grid.Children.Add(CoursesComboBox);
            grid.Children.Add(bestResultCountsLabel);
            grid.Children.Add(bestResultCountsCheckBox);
            grid.Children.Add(testName);
            grid.Children.Add(testNameTb);
            grid.Children.Add(submitLimitLabel);
            grid.Children.Add(submitLimitTb);
            grid.Children.Add(startDateLabel);
            grid.Children.Add(startDatePicker);
            grid.Children.Add(startTimeLabel);
            grid.Children.Add(startTimeTb);
            grid.Children.Add(endDateLabel);
            grid.Children.Add(endDatePicker);
            grid.Children.Add(endTimeLabel);
            grid.Children.Add(endTimeTb);


            mainStackPanel.Children.Add(grid);

            return grid;
        }

        private static Grid _grid;

        private const int startingChildrenCount = 8;
        private const int startingRowCount = 8;

        private static Grid CreateQuestionControls(Grid grid, StackPanel mainStackPanel)
        {
            ColumnDefinition coldef1 = new ColumnDefinition()
            {
                Width = new GridLength(400),
            };
            ColumnDefinition coldef2 = new ColumnDefinition();
            ColumnDefinition coldef3 = new ColumnDefinition();

            _grid.ColumnDefinitions.Add(coldef1);
            _grid.ColumnDefinitions.Add(coldef2);
            _grid.ColumnDefinitions.Add(coldef3);

            RowDefinition rowdef1 = new RowDefinition();
            RowDefinition rowdef2 = new RowDefinition()
            {
                Height = new GridLength(100),
            };
            RowDefinition rowdef3 = new RowDefinition();
            RowDefinition rowdef4 = new RowDefinition();
            RowDefinition rowdef5 = new RowDefinition()
            {
                Height = new GridLength(40),
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
                Foreground = Brushes.White,
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
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

            _grid = CreateQuestionControls(grid, mainStackPanel);

            ComboBox CBType = new ComboBox()
            {
                Width = 400,
                FontSize = 30,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
            };

            CBType.Items.Add("Jelölődoboz");
            CBType.Items.Add("Rádiógomb");
            CBType.Items.Add("Rövid választ igénylő feladat");

            CBType.SelectionChanged += (sender, e) => CBType_SelectionChanged(sender);

            Grid.SetColumn(CBType, 0);

            Grid.SetRow(CBType, 1);

            _grid.Children.Add(CBType);

            Label TestLabel = new Label()
            {
                Content = "Válaszd ki a tesztet",
                Foreground = Brushes.White,
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(TestLabel, 0);
            Grid.SetRow(TestLabel, 2);

            _grid.Children.Add(TestLabel);

            ComboBox TestComboBox = new ComboBox()
            {
                Width = 400,
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            using (DatabaseContext testDatabaseContext = new DatabaseContext())
            {
                foreach (Test item in testDatabaseContext.Tests)
                {
                    TestComboBox.Items.Add(item.Name);
                }
            }
            
            if(TestComboBox.Items.Count == 0)
            {
                TestComboBox.IsEnabled = false;
            }

            Grid.SetColumn(TestComboBox, 0);
            Grid.SetRow(TestComboBox, 3);

            _grid.Children.Add(TestComboBox);

            Label PontLabel = new Label()
            {
                Content = "Pont",
                Foreground = Brushes.White,
                Margin = new Thickness(20),
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(PontLabel, 1);
            Grid.SetRow(PontLabel, 2);

            _grid.Children.Add(PontLabel);

            TextBox PontTextBox = new TextBox()
            {
                Tag = "number",
                Width = 70,
                FontSize = 30,
                Margin = new Thickness(10),
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(PontTextBox, 1);
            Grid.SetRow(PontTextBox, 3);

            _grid.Children.Add(PontTextBox);

            Label QNameLabel = new Label()
            {
                Content = "Kérdés",
                Foreground = Brushes.White,
                FontSize = 30,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(QNameLabel, 0);
            Grid.SetRow(QNameLabel, 5);

            _grid.Children.Add(QNameLabel);

            TextBox QNameTB = new TextBox()
            {
                FontSize = 30,
                Width = 400,
                Height = 250,
                AcceptsReturn = true,
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
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
                case "Rövid választ igénylő feladat":
                    CreateQuestionTextBoxControls();
                    _grid.Tag = "single";
                    break;
            }
        }

        private static void ResetQuestionGrid()
        {
            if (_grid.Children.Count > startingChildrenCount)
            {
                _grid.Children.RemoveRange(startingChildrenCount, _grid.Children.Count - startingChildrenCount);
            }

            if (_grid.RowDefinitions.Count > startingRowCount)
            {
                _grid.RowDefinitions.RemoveRange(startingRowCount, _grid.RowDefinitions.Count - startingRowCount);
            }
        }

        private static void CreateQuestionGridCheckBoxControls()
        {
            ResetQuestionGrid();

            Label ValaszokLabel = new Label()
            {
                Content = "Válaszlehetőségek",
                Foreground = Brushes.White,
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(ValaszokLabel, 1);
            Grid.SetRow(ValaszokLabel, 5);

            _grid.Children.Add(ValaszokLabel);

            TextBox tb = new TextBox()
            {
                Width = 200,
                FontSize = 30,
                Margin = new Thickness(20),
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(tb, 1);
            Grid.SetRow(tb, 6);

            _grid.Children.Add(tb);

            CheckBox cb = new CheckBox()
            {
                Content = "Válasz?",
                FontSize = 30,
                Margin = new Thickness(20),
                Foreground = Brushes.White,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
            };

            Grid.SetColumn(cb, 2);
            Grid.SetRow(cb, 6);

            _grid.Children.Add(cb);
        }

        private static void CreateQuestionGridRadioButtonControls()
        {
            ResetQuestionGrid();

            Label ValaszokLabel = new Label()
            {
                Content = "Válaszlehetőségek",
                Foreground = Brushes.White,
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(ValaszokLabel, 1);
            Grid.SetRow(ValaszokLabel, 5);

            _grid.Children.Add(ValaszokLabel);

            TextBox tb = new TextBox()
            {
                Width = 200,
                FontSize = 30,
                Margin = new Thickness(30),
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(tb, 1);
            Grid.SetRow(tb, 6);

            _grid.Children.Add(tb);

            RadioButton cb = new RadioButton()
            {
                Content = "Helyes válasz",
                FontSize = 30,
                Margin = new Thickness(20),
                Foreground = Brushes.White,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
            };

            Grid.SetColumn(cb, 2);
            Grid.SetRow(cb, 6);

            _grid.Children.Add(cb);
        }

        private static void CreateQuestionTextBoxControls()
        {
            ResetQuestionGrid();

            Label label = new Label()
            {
                Content = "Válasz",
                Foreground = Brushes.White,
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(label, 1);
            Grid.SetRow(label, 5);

            TextBox tb = new TextBox()
            {
                Width = 300,
                Height = 150,
                Margin = new Thickness(30),
                TextWrapping = TextWrapping.Wrap,
                FontSize = 30,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            Grid.SetColumn(tb, 1);
            Grid.SetRow(tb, 6);

            _grid.Children.Add(label);
            _grid.Children.Add(tb);
        }
    }
}
