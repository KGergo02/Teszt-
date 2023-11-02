using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            questionGrid.Children.Clear();

            grid.ColumnDefinitions.Clear();

            grid.RowDefinitions.Clear();
        }

        public static Grid CreateCourseGrid(ref Grid grid, ref StackPanel mainStackPanel)
        {
            Label labelCourseName = new Label()
            {
                Content = "Kurzus neve",
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Label labelCourseLimit = new Label()
            {
                Content = "Kurzus limit",
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

            grid.ColumnDefinitions.Add(coldef1);
            grid.ColumnDefinitions.Add(coldef2);
            grid.ColumnDefinitions.Add(coldef3);
            grid.ColumnDefinitions.Add(coldef4);
            grid.ColumnDefinitions.Add(coldef5);

            RowDefinition rowdef1 = new RowDefinition();
            RowDefinition rowdef2 = new RowDefinition();

            grid.RowDefinitions.Add(rowdef1);
            grid.RowDefinitions.Add(rowdef2);

            Label testName = new Label()
            {
                Content = "Teszt neve",
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(testName, 0);

            Grid.SetRow(testName, 0);

            Label questionsLabel = new Label()
            {
                Content = "Kérdés",
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Label submitLimitLabel = new Label()
            {
                Content = "Kitöltési limit",
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(submitLimitLabel, 1);

            Grid.SetRow(submitLimitLabel, 0);

            Label dateLabel = new Label()
            {
                Content = "Teszt időpontja",
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(dateLabel, 2);

            Grid.SetRow(dateLabel, 0);

            Label startTimeLabel = new Label()
            {
                Content = "Indítási idő (óra:perc)",
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(startTimeLabel, 3);

            Grid.SetRow(startTimeLabel, 0);

            Label endTimeLabel = new Label()
            {
                Content = "Kitölthető eddig (óra:perc)",
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(endTimeLabel, 4);

            Grid.SetRow(endTimeLabel, 0);

            TextBox testNameTb = new TextBox()
            {
                FontSize = 30,
                Width = 100,
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
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(submitLimitTb, 1);
            Grid.SetRow(submitLimitTb, 1);

            DatePicker date = new DatePicker()
            {
                Width = 150,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(date, 2);
            Grid.SetRow(date, 1);

            TextBox startTimeTb = new TextBox()
            {
                Tag = "time",
                Width = 30,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(startTimeTb, 3);
            Grid.SetRow(startTimeTb, 1);

            TextBox endTimeTb = new TextBox()
            {
                Tag = "time",
                Width = 30,
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(endTimeTb, 4);
            Grid.SetRow(endTimeTb, 1);

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

        private static Grid questionGrid = new Grid();

        private static Grid CreateQuestionControls(Grid grid, StackPanel mainStackPanel)
        {
            ColumnDefinition coldef1 = new ColumnDefinition();
            ColumnDefinition coldef2 = new ColumnDefinition();
            ColumnDefinition coldef3 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(coldef1);
            grid.ColumnDefinitions.Add(coldef2);
            grid.ColumnDefinitions.Add(coldef3);

            RowDefinition rowdef1 = new RowDefinition();
            RowDefinition rowdef2 = new RowDefinition();
            RowDefinition rowdef3 = new RowDefinition();
            RowDefinition rowdef4 = new RowDefinition();
            RowDefinition rowdef5 = new RowDefinition();
            grid.RowDefinitions.Add(rowdef1);
            grid.RowDefinitions.Add(rowdef2);
            grid.RowDefinitions.Add(rowdef3);
            grid.RowDefinitions.Add(rowdef4);
            grid.RowDefinitions.Add(rowdef5);

            Label QTypeLabel = new Label()
            {
                Content = "Kérdés típusa",
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(QTypeLabel, 1);
            Grid.SetRow(QTypeLabel, 0);

            grid.Children.Add(QTypeLabel);

            mainStackPanel.Children.Add(grid);

            return grid;
        }

        public static Grid CreateQuestionGrid(Grid grid, StackPanel mainStackPanel)
        {
            grid = CreateQuestionControls(grid, mainStackPanel);

            ComboBox CBType = new ComboBox()
            {
                Height = 20,
                Width = 200,
                FontSize = 30,
                HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
            };

            CBType.Items.Add("Jelölődoboz");
            CBType.Items.Add("Rádiógomb");
            CBType.Items.Add("Egyválaszos");

            CBType.SelectedIndex = 0;

            CBType.SelectionChanged += (sender, e) => CBType_SelectionChanged(sender, e, grid, mainStackPanel);

            Grid.SetColumn(CBType, 1);

            Grid.SetRow(CBType, 1);

            grid.Children.Add(CBType);

            Label QNameLabel = new Label()
            {
                Content = "Kérdés",
                FontSize = 30,
            };

            Grid.SetColumn(QNameLabel, 1);
            Grid.SetRow(QNameLabel, 2);

            grid.Children.Add(QNameLabel);

            TextBox QNameTB = new TextBox()
            {
                FontSize = 30,
                Height = 50,
                Width = 200,
                AcceptsReturn = true,
                TextWrapping = System.Windows.TextWrapping.Wrap,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(QNameTB, 1);
            Grid.SetRow(QNameTB, 3);

            grid.Children.Add(QNameTB);

            CreateQuestionGridCheckBoxAndRadioButtonControls(questionGrid);

            Grid.SetColumn(questionGrid, 1);
            Grid.SetRow(questionGrid, 5);

            questionGrid.Tag = "checkbox";

            grid.Children.Add(questionGrid);

            return grid;
        }

        private static void CBType_SelectionChanged(object sender, SelectionChangedEventArgs e, Grid grid, StackPanel mainStackPanel)
        {
            ComboBox cb = (ComboBox)sender;

            switch (cb.SelectedValue)
            {
                case "Jelölődoboz":
                    questionGrid.Children.Clear();
                    CreateQuestionGridCheckBoxAndRadioButtonControls(questionGrid);
                    questionGrid.Tag = "checkbox";
                    break;
                case "Rádiógomb":
                    questionGrid.Children.Clear();
                    CreateQuestionGridCheckBoxAndRadioButtonControls(questionGrid);
                    questionGrid.Tag = "radiobutton";
                    break;
                case "Egyválaszos":
                    questionGrid.Children.Clear();
                    CreateQuestionTextBoxControls(questionGrid);
                    questionGrid.Tag = "single";
                    break;
            }
        }

        private static void CreateQuestionGridCheckBoxAndRadioButtonControls(Grid questionGrid)
        {
            ColumnDefinition coldef1 = new ColumnDefinition();
            ColumnDefinition coldef2 = new ColumnDefinition();
            ColumnDefinition coldef3 = new ColumnDefinition();

            RowDefinition rowdef1 = new RowDefinition();
            RowDefinition rowdef2 = new RowDefinition();

            questionGrid.ColumnDefinitions.Add(coldef1);
            questionGrid.ColumnDefinitions.Add(coldef2);
            questionGrid.ColumnDefinitions.Add(coldef3);

            questionGrid.RowDefinitions.Add(rowdef1);
            questionGrid.RowDefinitions.Add(rowdef2);

            Label ValaszokLabel = new Label()
            {
                Content = "Válaszlehetőségek",
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(ValaszokLabel, 1);
            Grid.SetRow(ValaszokLabel, 0);
            
            questionGrid.Children.Add(ValaszokLabel);

            TextBox tb = new TextBox()
            {
                Height = 20,
                Width = 100,
                FontSize = 30,
                TextWrapping = System.Windows.TextWrapping.Wrap,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(tb, 1);
            Grid.SetRow(tb, 1);

            questionGrid.Children.Add(tb);

            CheckBox cb = new CheckBox()
            {
                Content = "Válasz?",
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(cb, 2);
            Grid.SetRow(cb, 1);

            questionGrid.Children.Add(cb);
        }

        private static void CreateQuestionTextBoxControls(Grid questionGrid)
        {
            ColumnDefinition coldef1 = new ColumnDefinition();
            ColumnDefinition coldef2 = new ColumnDefinition();
            ColumnDefinition coldef3 = new ColumnDefinition();

            RowDefinition rowdef1 = new RowDefinition();
            RowDefinition rowdef2 = new RowDefinition();

            questionGrid.ColumnDefinitions.Add(coldef1);
            questionGrid.ColumnDefinitions.Add(coldef2);
            questionGrid.ColumnDefinitions.Add(coldef3);

            Label label = new Label()
            {
                Content = "Válasz",
                FontSize = 30,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            Grid.SetColumn(label, 1);
            Grid.SetRow(label, 0);

            TextBox tb = new TextBox()
            {
                Width = 100,
                Height = 100,
                TextWrapping = System.Windows.TextWrapping.Wrap,
                FontSize = 30,
            };

            Grid.SetColumn(tb, 1);
            Grid.SetRow(tb, 1);

            questionGrid.Children.Add(label);
            questionGrid.Children.Add(tb);
        }
    }
}
