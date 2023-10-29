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
            if (grid.Children.Count != 0)
            {
                grid.Children.RemoveRange(0, grid.Children.Count);
            }

            Label labelCourseName = new Label();

            labelCourseName.Content = "Kurzus neve";

            Label labelCourseLimit = new Label();

            labelCourseLimit.Content = "Kurzus limit";

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

            TextBox tb1 = new TextBox();

            TextBox tb2 = new TextBox()
            {
                Tag = "number"
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
                Content = "Teszt neve"
            };

            Grid.SetColumn(testName, 0);

            Grid.SetRow(testName, 0);

            Label questionsLabel = new Label()
            {
                Content = "Kérdés"
            };

            Label submitLimitLabel = new Label()
            {
                Content = "Kitöltési limit"
            };

            Grid.SetColumn(submitLimitLabel, 1);

            Grid.SetRow(submitLimitLabel, 0);

            Label dateLabel = new Label()
            {
                Content = "Teszt időpontja"
            };

            Grid.SetColumn(dateLabel, 2);

            Grid.SetRow(dateLabel, 0);

            Label startTimeLabel = new Label()
            {
                Content = "Indítási idő (óra:perc)"
            };

            Grid.SetColumn(startTimeLabel, 3);

            Grid.SetRow(startTimeLabel, 0);

            Label endTimeLabel = new Label()
            {
                Content = "Kitölthető eddig (óra:perc)"
            };

            Grid.SetColumn(endTimeLabel, 4);

            Grid.SetRow(endTimeLabel, 0);

            TextBox testNameTb = new TextBox();

            Grid.SetColumn(testNameTb, 0);
            Grid.SetRow(testNameTb, 1);

            TextBox submitLimitTb = new TextBox();

            submitLimitTb.Tag = "number";

            Grid.SetColumn(submitLimitTb, 1);
            Grid.SetRow(submitLimitTb, 1);

            DatePicker date = new DatePicker();

            Grid.SetColumn(date, 2);
            Grid.SetRow(date, 1);

            TextBox startTimeTb = new TextBox();

            startTimeTb.Tag = "time";

            Grid.SetColumn(startTimeTb, 3);
            Grid.SetRow(startTimeTb, 1);

            TextBox endTimeTb = new TextBox();

            endTimeTb.Tag = "time";

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

            Label QTypeLabel = new Label();

            QTypeLabel.Content = "Kérdés típusa";

            Grid.SetColumn(QTypeLabel, 1);
            Grid.SetRow(QTypeLabel, 0);

            grid.Children.Add(QTypeLabel);

            mainStackPanel.Children.Add(grid);

            return grid;
        }

        public static Grid CreateQuestionGrid(Grid grid, StackPanel mainStackPanel)
        {
            grid = CreateQuestionControls(grid, mainStackPanel);

            ComboBox CBType = new ComboBox();

            CBType.Items.Add("Jelölődoboz");
            CBType.Items.Add("Rádiógomb");
            CBType.Items.Add("Egyválaszos");

            CBType.SelectedIndex = 0;

            CBType.SelectionChanged += (sender, e) => CBType_SelectionChanged(sender, e, grid, mainStackPanel);

            Grid.SetColumn(CBType, 1);

            Grid.SetRow(CBType, 1);

            grid.Children.Add(CBType);

            Label QNameLabel = new Label();

            QNameLabel.Content = "Kérdés";

            Grid.SetColumn(QNameLabel, 1);
            Grid.SetRow(QNameLabel, 2);

            grid.Children.Add(QNameLabel);

            TextBox QNameTB = new TextBox();

            QNameTB.AcceptsReturn = true;

            QNameTB.TextWrapping = System.Windows.TextWrapping.Wrap;

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
                Content = "Válaszlehetőségek"
            };

            Grid.SetColumn(ValaszokLabel, 1);
            Grid.SetRow(ValaszokLabel, 0);
            
            questionGrid.Children.Add(ValaszokLabel);

            TextBox tb = new TextBox();

            Grid.SetColumn(tb, 1);
            Grid.SetRow(tb, 1);

            questionGrid.Children.Add(tb);

            CheckBox cb = new CheckBox()
            {
                Content = "Válasz?"
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
                Content = "Válasz"
            };

            Grid.SetColumn(label, 1);
            Grid.SetRow(label, 0);

            TextBox tb = new TextBox()
            {
                Width = 100
            };

            Grid.SetColumn(tb, 1);
            Grid.SetRow(tb, 1);

            questionGrid.Children.Add(label);
            questionGrid.Children.Add(tb);
        }
    }
}
