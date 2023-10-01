using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Teszt__.src.ViewModels;

namespace Teszt__
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindowView()
            {
                DataContext = new MainWindowViewModel()
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}

