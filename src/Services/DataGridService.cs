using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using Teszt__.src.DAL;
using static Teszt__.src.Models.DatabaseContext;

namespace Teszt__.src.Services
{
    public static class DataGridService
    {
        public static StackPanel _MainStackPanel;

        public static string Mode;

        public static string SelectedCourse;

        public static string SelectedTest;

        public static Button SendButton;

        public static void CreateDataGrid(string mode, ref StackPanel _mainStackPanel, ref Button sendButton)
        {
            _mainStackPanel.Children.Clear();

            _MainStackPanel = _mainStackPanel;

            Mode = mode;

            SendButton = sendButton;

            DataGrid dataGrid = new DataGrid()
            {
                FontSize = 30,
                RowBackground = Brushes.SteelBlue,
                AlternatingRowBackground = Brushes.SkyBlue,
                CanUserAddRows = false,
                AutoGenerateColumns = false,
                CanUserReorderColumns = false,
                CanUserDeleteRows = false,
            };

            if (Mode == "results")
            {
                SendButton.Visibility = Visibility.Collapsed;

                ColumnDefinition coldef1 = new ColumnDefinition();
                
                ColumnDefinition coldef2 = new ColumnDefinition();

                ColumnDefinition coldef3 = new ColumnDefinition();

                RowDefinition rowdef1 = new RowDefinition();
                
                RowDefinition rowdef2 = new RowDefinition();

                Grid grid = new Grid();

                grid.ColumnDefinitions.Add(coldef1);

                grid.ColumnDefinitions.Add(coldef2);
                
                grid.ColumnDefinitions.Add(coldef3);

                grid.RowDefinitions.Add(rowdef1);

                grid.RowDefinitions.Add(rowdef2);

                Label courseLabel = new Label()
                {
                    FontSize = 35,
                    Foreground = Brushes.White,
                    Content = "Kurzus",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(5),
                };

                Grid.SetColumn(courseLabel, 0);

                Grid.SetRow(courseLabel, 0);

                grid.Children.Add(courseLabel);

                Label testLabel = new Label()
                {
                    FontSize = 35,
                    Foreground = Brushes.White,
                    Content = "Teszt",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(5),
                };

                Grid.SetColumn(testLabel, 1);

                Grid.SetRow(testLabel, 0);

                grid.Children.Add(testLabel);

                ComboBox courseComboBox = new ComboBox()
                {
                    FontSize = 30,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 0, 30),
                    Width = 250,
                    Height = 50,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };

                Grid.SetColumn(courseComboBox, 0);

                Grid.SetRow(courseComboBox, 1);

                grid.Children.Add(courseComboBox);

                ComboBox testComboBox = new ComboBox()
                {
                    FontSize = 30,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 0, 30),
                    Width = 250,
                    Height = 50,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };

                Grid.SetColumn(testComboBox, 1);

                Grid.SetRow(testComboBox, 1);

                grid.Children.Add(testComboBox);

                Button clearFiltersButton = new Button()
                {
                    Content = "Szűrők törlése",
                    FontSize = 30,
                    Margin = new Thickness(0, 0, 0, 30),
                    Width = 200,
                    Height = 50,
                };

                Grid.SetColumn(clearFiltersButton, 2);

                Grid.SetRow(clearFiltersButton, 1);

                clearFiltersButton.Click += ClearFiltersButton_Click;

                grid.Children.Add(clearFiltersButton);

                List<Result> models = new List<Result>();

                using (DatabaseContext database = new DatabaseContext())
                {
                    List<Course> courses = database.GetCourses();

                    List<string> courseNames = courses.Select(item => item.Name).ToList();

                    List<string> testNames = database.Tests.Select(item => item.Name).ToList();

                    courseComboBox.Items.Add("");

                    testComboBox.Items.Add("");

                    foreach (var item in courseNames)
                    {
                        courseComboBox.Items.Add(item);
                    }

                    foreach (var item in testNames)
                    {
                        testComboBox.Items.Add(item);
                    }

                    courseComboBox.SelectedItem = SelectedCourse;

                    testComboBox.SelectedItem = SelectedTest;

                    courseComboBox.SelectionChanged += CourseComboBox_SelectionChanged;

                    testComboBox.SelectionChanged += TestComboBox_SelectionChanged;

                    if ((SelectedCourse == null || SelectedCourse == "") && (SelectedTest == null || SelectedTest == ""))
                    {
                        models = DatabaseContext.GetResultsOfAllUsers();
                    }
                    else if((SelectedCourse != null || SelectedCourse != "") && (SelectedTest == null || SelectedTest == ""))
                    {
                        Course course = (Course)database.FindByName(SelectedCourse, typeof(Course));

                        List<int> tests = database.GetTestsOfCourse(course).Select(item => item.Id).ToList();

                        models = database.Results.Where(item => tests.Contains(item.TestId)).ToList();
                    }
                    else if((SelectedCourse == null || SelectedCourse == "") && (SelectedTest != null || SelectedTest != ""))
                    {
                        Test test = (Test)database.FindByName(SelectedTest, typeof(Test));

                        models = database.Results.Where(item => item.TestId == test.Id).ToList();
                    }
                    else
                    {
                        Course course = (Course)database.FindByName(SelectedCourse, typeof(Course));

                        List<int> tests = database.GetTestsOfCourse(course).Select(item => item.Id).ToList();

                        Test test = (Test)database.FindByName(SelectedTest, typeof(Test));

                        if(tests.Contains(test.Id))
                        {
                            models = database.Results.Where(item => item.TestId == test.Id).ToList();
                        }
                        else
                        {
                            models.Clear();
                        }
                    }
                }

                _mainStackPanel.Children.Add(grid);

                if (models.Count == 0)
                {
                    Label label = new Label()
                    {
                        Content = "Nincs megjeleníthető adat",
                        FontWeight = FontWeights.Bold,
                        FontSize = 36,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Foreground = Brushes.White,
                        Margin = new Thickness(0, 70, 0, 0)
                    };

                    _mainStackPanel.Children.Add(label);

                    return;
                }

                dataGrid.ItemsSource = models;

                Dictionary<string, string> namesOfColumns = new Dictionary<string, string>();

                if (models[0] is Result result)
                {
                    namesOfColumns = result.GetNameOfProperties();

                    dataGrid.IsReadOnly = true;
                }

                foreach (KeyValuePair<string, string> pair in namesOfColumns)
                {
                    DataGridTextColumn column = new DataGridTextColumn { Header = pair.Value, Binding = new Binding(pair.Key), CanUserResize = false };

                    column.HeaderStyle = new Style(typeof(DataGridColumnHeader));

                    column.HeaderStyle.Setters.Add(new Setter(Control.HorizontalContentAlignmentProperty, HorizontalAlignment.Center));

                    dataGrid.Columns.Add(column);
                }

                DataGridTemplateColumn buttonColumn = new DataGridTemplateColumn()
                {
                    CanUserResize = false,
                    Width = 200,
                    IsReadOnly = true,
                };

                buttonColumn.Header = "";

                FrameworkElementFactory buttonFactory = new FrameworkElementFactory(typeof(Button));

                buttonFactory.SetValue(Button.ContentProperty, "Törlés");

                buttonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler((sender, e) =>
                {
                    if (models[0] is Result)
                    {
                        MessageBoxResult prompt = Message.Question("Biztosan törölni szeretnéd ezt a bejegyzést?");

                        if(prompt == MessageBoxResult.Yes)
                        {
                            DatabaseContext.DeleteResult((Result)((Button)sender).DataContext);

                            CreateDataGrid("results", ref _MainStackPanel, ref SendButton);
                        }
                    }
                }));

                buttonColumn.CellTemplate = new DataTemplate() { VisualTree = buttonFactory };

                dataGrid.Columns.Add(buttonColumn);

            }

            _mainStackPanel.Children.Add(dataGrid);
        }

        private static void CourseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedCourse = ((ComboBox)(sender)).SelectedItem.ToString();

            CreateDataGrid(Mode, ref _MainStackPanel, ref SendButton);
        }

        private static void TestComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedTest = ((ComboBox)(sender)).SelectedItem.ToString();

            CreateDataGrid(Mode, ref _MainStackPanel, ref SendButton);
        }

        private static void ClearFiltersButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedCourse = null;

            SelectedTest = null;

            CreateDataGrid(Mode, ref _MainStackPanel, ref SendButton);
        }
    }
}
