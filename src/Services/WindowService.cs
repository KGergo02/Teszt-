using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Teszt__.src.ViewModels;
using Teszt__.src.Views;

namespace Teszt__.src.Services
{
    public static class WindowService
    {
        public static void OnWindowClosing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = Message.Question("Biztosan be szeretnéd zárni az ablakot?");

            if(result.Equals(MessageBoxResult.No))
            {
                e.Cancel = true;
            }
        }

        public static void OnWindowClosingLogoutUserQuestion(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = Message.Question("Biztosan ki szeretnél jelentkezni?");

            if (result.Equals(MessageBoxResult.No))
            {
                e.Cancel = true;
            }
            else if(result.Equals(MessageBoxResult.Yes))
            {
                e.Cancel = true;

                NavigationService.GetNavigationWindow().Closing -= OnWindowClosingLogoutUserQuestion;

                NavigationService.NavigateToHomePage();
            }
        }

        public static void OnWindowNavigation(object sender, NavigatingCancelEventArgs e)
        {
            if(e.NavigationMode == NavigationMode.Back || e.NavigationMode == NavigationMode.Forward)
            {
                e.Cancel = true;
            }
        }
    }
}
