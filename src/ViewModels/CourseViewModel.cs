using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Teszt__.src.Commands.Hallgato_Commands;
using Teszt__.src.DAL;
using Teszt__.src.Services;
using Teszt__.src.Views.Hallgato_Views;
using static Teszt__.src.Models.DatabaseContext;

namespace Teszt__.src.ViewModels
{
    public class CourseViewModel : ViewModelBase
    {

        private List<string> _courses;
        public List<string> Courses
        {
            get
            {
                return _courses;
            }
            set
            {
                _courses = value;
                OnPropertyChanged(nameof(Courses));
            }
        }

        public string TitleName { get; set; }

        public string ButtonText { get; set; }

        public string NoDataLabelText { get; set; }

        public CourseViewModel(bool mode, CourseView window)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                List<string> userCourses = database.GetCourseListOfUser(UserService.GetCurrentUser()).Select(item => item.Course_name).ToList();

                List<Course> courses = database.GetCourses();

                List<string> coursesAvailableForListBox = new List<string>();

                if (mode)
                {
                    ButtonText = "Kurzusok hozzáadása";

                    TitleName = "Kurzus felvétele";

                    foreach (Course course in courses)
                    {
                        if (!userCourses.Contains(course.Name) && DatabaseContext.CountCourseLimit(course) < course.User_limit && DatabaseContext.AreAllTestsOfCourseSubmittable(course))
                        {
                            coursesAvailableForListBox.Add(course.Name);
                        }
                    }
                }
                else
                {
                    ButtonText = "Kurzusok leadása";

                    TitleName = "Kurzus leadása";

                    foreach (Course course in courses)
                    {
                        if (userCourses.Contains(course.Name) && DatabaseContext.CountUserSubmissionsOfCourse(UserService.GetCurrentUser(), course) == 0 && DatabaseContext.AreAllTestsOfCourseSubmittable(course))
                        {
                            coursesAvailableForListBox.Add(course.Name);
                        }
                    }
                }

                Courses = coursesAvailableForListBox;

                if (Courses.Count == 0)
                {
                    if(mode)
                    {
                        NoDataLabelText = "Nincs felvehető kurzus";
                    }
                    else
                    {
                        NoDataLabelText = "Nincs leadható kurzus";
                    }
                }
                else
                {
                    window.NoDataLabel.Visibility = Visibility.Hidden;
                }
            }

            CourseSendCommand = new CourseSendCommand(mode, window);

            CloseCourseWindowCommand = new CloseCourseWindowCommand(window);
        }

        public ICommand CourseSendCommand { get; }

        public ICommand CloseCourseWindowCommand { get; }
    }
}
