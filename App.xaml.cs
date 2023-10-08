using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Teszt__.src.Models;
using Teszt__.src.ViewModels;
using Teszt__.src.Views;

namespace Teszt__
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Navigation _navigation = new Navigation();

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigation.CurrentViewModel = CreateMainWindowNavigationViewModel();

            MainWindow = new MainWindowView()
            {
                DataContext = new MainWindowViewModel()
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private MainWindowNavigationViewModel CreateMainWindowNavigationViewModel()
        {
            return new MainWindowNavigationViewModel(_navigation, CreateHallgatoMainViewModel);
        }

        private HallgatoMainViewModel CreateHallgatoMainViewModel()
        {
            return new HallgatoMainViewModel(_navigation);
        }
    }
}

