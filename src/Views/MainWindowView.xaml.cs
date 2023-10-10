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
    }
}
