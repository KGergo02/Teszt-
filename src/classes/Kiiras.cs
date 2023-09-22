using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Teszt__.src.classes
{
    public static class Kiiras
    {
        public static void Hiba(string uzenet)
        {
            MessageBox.Show(uzenet, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void Siker(string uzenet)
        {
            MessageBox.Show(uzenet, "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static MessageBoxResult Kerdes(string uzenet)
        {
            return MessageBox.Show(uzenet, "Kérdés", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
