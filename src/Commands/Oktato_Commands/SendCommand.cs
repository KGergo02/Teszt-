using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Teszt__.src.Services;
using Teszt__.src.Models;
using Teszt__.src.DAL;
using static Teszt__.src.DAL.UserDatabaseContext;
using Teszt__.src.ViewModels.Oktato_ViewModels;
using System.Text.RegularExpressions;
using static Teszt__.src.DAL.TestDatabaseContext;
using static Teszt__.src.DAL.CourseDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Teszt__.src.Commands.Oktato_Commands
{
    class SendCommand : CommandBase
    {
        private Grid _grid;

        private StackPanel _mainStackPanel;

        private OktatoMainViewModel _viewModel;

        public SendCommand(ref Grid grid, ref StackPanel mainStackPanel , OktatoMainViewModel viewModel)
        {
            _grid = grid;

            _viewModel = viewModel;

            _mainStackPanel = mainStackPanel;
        }

        public override void Execute(object parameter)
        {
            foreach (var item in _grid.Children)
            {
                if(item is TextBox)
                {
                    TextBox tb = (TextBox)item;

                    if(tb.Text == String.Empty)
                    {
                        Message.Error("Nem töltöttél ki minden mezőt!");

                        return;
                    }
                }
                else if(item is DatePicker)
                {
                    DatePicker dp = (DatePicker)item;

                    if(dp.SelectedDate == null)
                    {
                        Message.Error("Nem töltöttél ki minden mezőt!");

                        return;
                    }
                }
            }

            for (int i = _grid.ColumnDefinitions.Count; i < _grid.Children.Count; i += _grid.ColumnDefinitions.Count)
            {
                List<Control> controls = new List<Control>();
                
                if(_viewModel.modelType != 2)
                {
                    for (int j = 0; j < _grid.ColumnDefinitions.Count; j++)
                    {
                        Control item = (Control)_grid.Children[i + j];

                        controls.Add(item);
                    }
                }

                switch (_viewModel.modelType)
                {
                    case 0:
                        if (CheckCourseInputs() && CheckIfInCourses())
                        {
                            if(!SaveCourse(controls))
                            {
                                return;
                            }
                        }
                        return;

                    case 1:
                        if(CheckTestInputs())
                        {
                            if(!SaveTest(controls))
                            {
                                return;
                            }
                        }
                        return;
                }

                controls.Clear();
            }

            GridService.ClearGrid(ref _grid, ref _mainStackPanel);

            

            string type = "";

            switch(_viewModel.modelType)
            {
                case 0:
                    type = "Kurzus";
                    _grid = GridService.CreateCourseGrid(ref _grid, ref _mainStackPanel);
                    break;
                case 1:
                    type = "Teszt";
                    _grid = GridService.CreateTestGrid(ref _grid, ref _mainStackPanel);
                    break;
                case 2:
                    type = "Kérdés";
                    _grid = GridService.CreateQuestionGrid(_grid, _mainStackPanel);
                    break;

            }

            Message.Success($"{type} sikeresen létrehozva!");
        }

        private bool CheckIfNumber(string text, string tag)
        {
            if(tag == "number")
            {
                int number = 0;

                if (!int.TryParse(text, out number))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckIfTime(string text, string tag)
        {
            if(tag == "time")
            {
                string pattern = @"^([0-1]?[0-9]|2[0-3]){2}:[0-5][0-9]$";

                Regex regex = new Regex(pattern);

                if(regex.Matches(text).Count == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckIfStartTimeIsLessThanEndTime()
        {
            List<TextBox> timeTextBoxes = new List<TextBox>();

            foreach (var item in _grid.Children)
            {
                if(item is TextBox)
                {
                    TextBox tb = (TextBox)item;

                    if(tb.Tag != null && tb.Tag.ToString() == "time")
                    {
                        timeTextBoxes.Add((TextBox)item);
                    }
                }
            }

            List<string> numbers1 = timeTextBoxes[0].Text.Split(':').ToList();
           
            List<string> numbers2 = timeTextBoxes[1].Text.Split(':').ToList();

            if (numbers1.Count == 2 && numbers2.Count == 2)
            {
                if(Convert.ToInt32(numbers1[0]) > Convert.ToInt32(numbers2[0]) || 
                   Convert.ToInt32(numbers1[1]) >= Convert.ToInt32(numbers2[1]) && Convert.ToInt32(numbers1[1]) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckCourseInputs()
        {
            HashSet<string> inputNames = new HashSet<string>();

            foreach (var item in _grid.Children)
            {
                if(item is TextBox)
                {
                    TextBox tb = (TextBox)item;

                    inputNames.Add(tb.Text.ToUpper());

                    if(tb.Tag != null && !CheckIfNumber(tb.Text, tb.Tag.ToString()))
                    {
                        Message.Error("Nem számot adtál meg!");

                        return false;
                    }
                }
            }

            if(inputNames.Count != _grid.RowDefinitions.Count - 1)
            {
                Message.Error("Nem lehet azonos nevű kurzus a bemenetben!");
                return false;
            }

            return true;
        }

        private bool CheckTestInputs()
        {
            foreach (var item in _grid.Children)
            {
                if(item is TextBox)
                {
                    TextBox tb = (TextBox)item;

                    if(tb.Tag != null && !CheckIfNumber(tb.Text, tb.Tag.ToString()))
                    {
                        Message.Error("Nem számot adtál meg!");

                        return false;
                    }
                    else if(tb.Tag != null && !CheckIfTime(tb.Text, tb.Tag.ToString()))
                    {
                        Message.Error("Nem jó formátumban adtad meg az időt!\nHelyes formátum: óra:perc");

                        return false;
                    }
                    else if(tb.Tag != null && tb.Tag.ToString() == "time" && !CheckIfStartTimeIsLessThanEndTime())
                    {
                        Message.Error("A kezdési időpont nem lehet előbb, mint a befejezés");

                        return false;
                    }
                }
            }

            return true;
        }

        private bool CheckIfInCourses()
        {
            bool inputIsInCourses = false;

            string errorMessage = "";

            foreach (var item in _grid.Children)
            {
                if(item is TextBox)
                {
                    TextBox tb = (TextBox)item;

                    CourseDatabaseContext database = new CourseDatabaseContext();

                    foreach (Course course in database.Courses)
                    {
                        if(course.name.ToUpper() == tb.Text.ToUpper())
                        {
                            if(errorMessage == String.Empty)
                            {
                                errorMessage += $"Ilyen kurzus már szerepel az adatbázisban!\n\nKurzusok:\n{course.name}";
                            }
                            else
                            {
                                errorMessage += "\n" + course.name;
                            }

                            inputIsInCourses = true;
                        }
                    }
                }
            }

            if(inputIsInCourses)
            {
                Message.Error(errorMessage);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool SaveCourse(List<Control> controls)
        {
            TextBox name = (TextBox)controls[0];
            
            TextBox limit = (TextBox)controls[1];

            int number = Convert.ToInt32(limit.Text);

            Course course = new Course(name.Text, number, new List<Test>());

            CourseDatabaseContext database = new CourseDatabaseContext();

            database.Courses.Add(course);

            database.SaveChanges();

            return true;
        }

        private bool SaveTest(List<Control> controls)
        {
            TextBox name = (TextBox)controls[0];

            TextBox submit_limit = (TextBox)controls[1];

            DatePicker datePicker = (DatePicker)controls[2];

            TextBox startTime = (TextBox)controls[3];
            
            TextBox endTime = (TextBox)controls[4];

            Test test = new Test(name.Text, Convert.ToInt32(submit_limit.Text), datePicker.SelectedDate.Value.Date.ToShortDateString(), startTime.Text, endTime.Text);

            TestDatabaseContext database = new TestDatabaseContext();

            try
            {
                database.Tests.Add(test);

                database.SaveChanges();
            }
            catch (DbUpdateException)
            {
                Message.Error("Ilyen teszt már létezik az adatbázisban!");

                return false;
            }

            return true;
        }
    }
}
