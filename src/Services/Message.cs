using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Teszt__.src.Services
{
    public static class Message
    {
        public static void Error(string uzenet)
        {
            MessageBox.Show(uzenet, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void Success(string uzenet)
        {
            MessageBox.Show(uzenet, "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static MessageBoxResult Question(string uzenet)
        {
            return MessageBox.Show(uzenet, "Kérdés", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
