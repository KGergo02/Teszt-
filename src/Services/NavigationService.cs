using System;
using System.Windows.Navigation;
using static Teszt__.src.Models.DatabaseContext;
using Teszt__.src.ViewModels.Oktato_ViewModels;
using Teszt__.src.Views.Oktato_Views;
using Teszt__.src.ViewModels;
using Teszt__.src.Views.Hallgato_Views;
using System.Windows;

namespace Teszt__.src.Services
{
    public static class NavigationService
    {
        public static NavigationWindow GetNavigationWindow()
        {
            MainWindowViewModel viewModel = (MainWindowViewModel)Application.Current.MainWindow.DataContext;

            return viewModel.GetNavigationWindow();
        }

        public static void NavigateToHomePage()
        {
            GetNavigationWindow().Navigate(new Uri("src/Views/MainWindowView.xaml", UriKind.Relative));
        }

        public static void NavigateToOktatoView(ref User user)
        {
            OktatoMainView window = new OktatoMainView();

            window.DataContext = new OktatoMainViewModel(ref user, window);

            GetNavigationWindow().Navigate(window);
        }

        public static void NavigateToHallgatoView(ref User user)
        {
            HallgatoMainView window = new HallgatoMainView();

            window.DataContext = new HallgatoMainViewModel(ref user, window);

            GetNavigationWindow().Navigate(window);
        }
    }
}
