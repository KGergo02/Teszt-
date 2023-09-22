using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Teszt__.src.classes
{
    public static class Scene
    {
        public static void Switch(Window mainWindow, Window secondWindow)
        {
            mainWindow.Hide();

            secondWindow.WindowState = mainWindow.WindowState;

            secondWindow.Show();

            secondWindow.Tag = mainWindow;
        }
    }
}
