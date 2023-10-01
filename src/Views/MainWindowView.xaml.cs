using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Teszt__.src.Views;

namespace Teszt__
{
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
        }

        private void registerLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterWindowView window = new RegisterWindowView();

            window.ShowDialog();
        }
    }
}
