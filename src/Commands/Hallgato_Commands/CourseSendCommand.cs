using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Teszt__.src.DAL;
using Teszt__.src.Services;
using Teszt__.src.Views.Hallgato_Views;
using static Teszt__.src.Models.DatabaseContext;

namespace Teszt__.src.Commands.Hallgato_Commands
{
    public class CourseSendCommand : CommandBase
    {
        private bool Mode;

        private ListBox ListBox;

        private CourseView Window { get; set; }

        public CourseSendCommand(bool mode, CourseView window)
        {
            this.Mode = mode;

            ListBox = window.listBox;

            Window = window;
        }

        public override void Execute(object parameter)
        {
            if(ListBox.SelectedItems.Count == 0)
            {
                return;
            }

            List<Course> courses = new List<Course>();

            using (DatabaseContext database = new DatabaseContext())
            {
                foreach (string item in ListBox.SelectedItems)
                {
                    Course course = database.GetCourses().Find(obj => obj.Name == item);

                    courses.Add(course);
                }
            }

            if(Mode)
            {
                DatabaseContext.SaveUserCourse(UserService.GetCurrentUser(), courses);

                NavigationService.GetNavigationWindow().Closing -= WindowService.OnWindowClosingLogoutUserQuestion;

                NavigationService.NavigateToHallgatoView();

                Message.Success("Kurzusok sikeresen felvéve!");

                Window.Close();
            }
            else
            {
                DatabaseContext.DeleteUserCourse(UserService.GetCurrentUser(), courses);

                NavigationService.GetNavigationWindow().Closing -= WindowService.OnWindowClosingLogoutUserQuestion;

                NavigationService.NavigateToHallgatoView();

                Message.Success("Kurzusok sikeresen leadva!");

                Window.Close();
            }
        }
    }
}
