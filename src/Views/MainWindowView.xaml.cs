using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Teszt__.src.Commands;

namespace Teszt__.src.Views
{
    public partial class MainWindowView : Page
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        private void registerLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterLabelCommand command = new RegisterLabelCommand();

            command.Execute(this);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadedMainCommand command = new LoadedMainCommand();

            if (command.CanExecute(this))
            {
                command.Execute(this);
            }
        }
    }
}
