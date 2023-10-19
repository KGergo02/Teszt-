using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Teszt__.src.Commands;
using Teszt__.src.Commands.Oktato_Commands;
using Teszt__.src.Models;
using Teszt__.src.Views.Oktato_Views;

namespace Teszt__.src.ViewModels.Oktato_ViewModels
{
    public class OktatoMainViewModel : ViewModelBase
    {
        private NavigationWindow _navigationWindow;

        private string _titleName;
        public string TitleName
        {
            get
            {
                return _titleName;
            }
            set
            {
                _titleName = value;
                OnPropertyChanged(nameof(TitleName));
            }
        }

        public StackPanel _mainStackPanel;

        public Grid grid = new Grid();

        private readonly User _user;

        public OktatoMainViewModel(User user, OktatoMainView window, NavigationWindow navigationWindow)
        {
            TitleName = $"Főoldal - {user.name}";

            _user = user;

            _navigationWindow = navigationWindow;

            _mainStackPanel = window._mainStackPanel;

            InitializeCourseGrid();

            CreateCourseCommand = new CreateCourseCommand(_user, _navigationWindow);
            
            CreateTestCommand = new CreateTestCommand();
            
            CreateQuestionCommand = new CreateQuestionCommand();

            LogOutCommand = new LogOutCommand(_navigationWindow);

            AddNewRowCommand = new AddNewRowCommand(ref grid);
        }

        private void InitializeCourseGrid()
        {
            grid = new Grid();

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

            TextBox tb2 = new TextBox();

            Grid.SetColumn(tb1, 0);

            Grid.SetRow(tb1, 1);

            Grid.SetColumn(tb2, 1);

            Grid.SetRow(tb2, 1);

            grid.Children.Add(labelCourseName);

            grid.Children.Add(labelCourseLimit);

            grid.Children.Add(tb1);

            grid.Children.Add(tb2);

            _mainStackPanel.Children.Add(grid);
        }

        public ICommand CreateCourseCommand { get; }
        public ICommand CreateTestCommand { get; }
        public ICommand CreateQuestionCommand { get; }
        public ICommand LogOutCommand { get; }
        public ICommand AddNewRowCommand { get; }
        public ICommand SendCommand { get; }
    }
}
