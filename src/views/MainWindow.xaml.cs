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
using Teszt__.src.views;
using Teszt__.src.classes;

namespace Teszt__
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void hallgatoi_Button_Click(object sender, RoutedEventArgs e)
        {
            sendToLogin(false);
        }

        private void oktatoi_Button_Click(object sender, RoutedEventArgs e)
        {
            sendToLogin(true);
        }

        private void registerLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void sendToLogin(bool admin)
        {
            LoginWindow window = new LoginWindow(admin);

            Scene.Switch(this, window);
        }
    }
}
