using System;
using System.Windows.Navigation;
using static Teszt__.src.Models.DatabaseContext;
using Teszt__.src.ViewModels.Oktato_ViewModels;
using Teszt__.src.Views.Oktato_Views;
using Teszt__.src.ViewModels;
using Teszt__.src.Views.Hallgato_Views;
using System.Windows;
using Teszt__.src.ViewModels.Hallgato_ViewModels;

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

        public static void NavigateToOktatoView()
        {
            OktatoMainView window = new OktatoMainView();

            window.DataContext = new OktatoMainViewModel(window);

            GetNavigationWindow().Navigate(window);
        }

        public static void NavigateToHallgatoView()
        {
            HallgatoMainView window = new HallgatoMainView();

            window.DataContext = new HallgatoMainViewModel(window);

            GetNavigationWindow().Navigate(window);
        }

        public static void NavigateToTestView(Test test)
        {
            TestView window = new TestView();

            window.DataContext = new TestViewModel(test, window);

            GetNavigationWindow().Navigate(window);
        }

        public static void NavigateToDataView(string mode)
        {
            ShowDataView window = new ShowDataView();

            window.DataContext = new ShowDataViewModel(mode, window.mainStackPanel, window.sendButton);

            GetNavigationWindow().Navigate(window);
        }
    }
}
