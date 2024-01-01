using System;
using System.Windows.Navigation;
using static Teszt__.src.Models.DatabaseContext;
using Teszt__.src.ViewModels.Oktato_ViewModels;
using Teszt__.src.Views.Oktato_Views;
using Teszt__.src.ViewModels;
using Teszt__.src.Views.Hallgato_Views;

namespace Teszt__.src.Services
{
    public static class NavigationService
    {
        public static void NavigateToHomePage(NavigationWindow navigationWindow)
        {
            navigationWindow.Navigate(new Uri("src/Views/MainWindowView.xaml", UriKind.Relative));
        }

        public static void NavigateToOktatoView(ref User user, NavigationWindow navigationWindow)
        {
            OktatoMainView window = new OktatoMainView();

            window.DataContext = new OktatoMainViewModel(ref user, window, navigationWindow);

            navigationWindow.Navigate(window);
        }

        public static void NavigateToHallgatoView(ref User user, NavigationWindow navigationWindow)
        {
            HallgatoMainView window = new HallgatoMainView();

            window.DataContext = new HallgatoMainViewModel(ref user, window, navigationWindow);

            navigationWindow.Navigate(window);
        }
    }
}
