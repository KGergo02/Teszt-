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
        public static void Error(string message)
        {
            MessageBox.Show(message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void Success(string message)
        {
            MessageBox.Show(message, "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static MessageBoxResult Question(string message)
        {
            return MessageBox.Show(message, "Kérdés", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
