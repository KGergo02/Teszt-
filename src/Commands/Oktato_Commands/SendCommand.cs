using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Teszt__.src.Services;
using Teszt__.src.ViewModels.Oktato_ViewModels;
using System.Text.RegularExpressions;
using DatabaseContext = Teszt__.src.DAL.DatabaseContext;
using static Teszt__.src.Models.DatabaseContext;

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
            if (!CheckControlInputs(_grid.Children)) return;

            for (int i = _grid.ColumnDefinitions.Count; i < _grid.Children.Count; i += _grid.ColumnDefinitions.Count)
            {
                List<Control> controls = new List<Control>();
                
                if(_viewModel.modelType == 0)
                {
                    for (int j = 0; j < _grid.ColumnDefinitions.Count; j++)
                    {
                        Control item = (Control)_grid.Children[i + j];

                        controls.Add(item);
                    }
                }
                else
                {
                    for (int j = 0; j < _grid.Children.Count; j++)
                    {
                        if (
                            _grid.Children[j] is TextBox ||
                            _grid.Children[j] is DatePicker ||
                            _grid.Children[j] is ComboBox ||
                            _grid.Children[j] is CheckBox ||
                            _grid.Children[j] is RadioButton
                            )
                        {
                            Control item = (Control)_grid.Children[j];

                            controls.Add(item);
                        }
                    }
                }

                switch (_viewModel.modelType)
                {
                    case 0:
                        if (CheckCourseInputs() && CheckIfInCourses(controls))
                        {
                            if(!IfSaveCourseWasSuccessful(controls))
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;

                    case 1:
                        if(IfSaveTestWasSuccessful(controls))
                        {
                            goto NotifyUser;
                        }
                        break;
                    case 2:
                        if (IfSaveQuestionWasSuccessful(controls))
                        {
                            goto NotifyUser;
                        }
                        break;
                }

                controls.Clear();
            }

            NotifyUser:

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

        private bool CheckControlInputs(UIElementCollection controls)
        {
            foreach (var item in controls)
            {
                if (item is TextBox)
                {
                    TextBox tb = (TextBox)item;

                    if (tb.Text == String.Empty)
                    {
                        Message.Error("Nem töltöttél ki minden mezőt!");

                        return false;
                    }

                    if (tb.Tag != null && !CheckIfNumber(tb.Text, tb.Tag.ToString()))
                    {
                        Message.Error("Nem számot adtál meg!");

                        return false;
                    }

                    if(_viewModel.modelType == 1)
                    {
                        List<DateTime> dates = new List<DateTime>();

                        foreach (Control datePickerControl in controls)
                        {
                            if (datePickerControl is DatePicker datePicker)
                            {
                                if (datePicker.SelectedDate == null)
                                {
                                    Message.Error("Nem adtál meg dátumot!");

                                    return false;
                                }

                                dates.Add(datePicker.SelectedDate.Value.Date);
                            }
                        }

                        if (dates[0] > dates[1])
                        {
                            Message.Error("Nem választhatsz kezdési nap előtti napot!");

                            return false;
                        }

                        if (dates[0] == dates[1])
                        {
                            if (tb.Tag != null && !CheckIfTime(tb.Text, tb.Tag.ToString()))
                            {
                                Message.Error("Nem jó formátumban adtad meg az időt!\nHelyes formátum: 00:00");

                                return false;
                            }
                            else if (tb.Tag != null && tb.Tag.ToString() == "time" && !CheckIfStartTimeIsLessThanEndTime())
                            {
                                Message.Error("Az indítási időpont nem lehet előbb, mint a befejezési idő!");

                                return false;
                            }
                        }
                        else
                        {
                            if (tb.Tag != null && !CheckIfTime(tb.Text, tb.Tag.ToString()))
                            {
                                Message.Error("Nem jó formátumban adtad meg az időt!\nHelyes formátum: 00:00");

                                return false;
                            }
                        }
                    }
                }
                else if (item is ComboBox)
                {
                    ComboBox cb = (ComboBox)item;

                    if (cb.SelectedIndex == -1)
                    {
                        Message.Error("Nem választottál a listából!");

                        return false;
                    }
                }
            }

            return true;
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
                string pattern = @"^(?:[01]?\d|2[0-3])(?::[0-5]\d){1,2}$";

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
            List<string> inputNames = new List<string>();

            foreach (var item in _grid.Children)
            {
                if(item is TextBox)
                {
                    TextBox tb = (TextBox)item;

                    if(tb.Tag == null)
                    {
                        inputNames.Add(tb.Text.ToUpper());
                    }
                }
            }

            if(inputNames.Count != inputNames.Distinct().Count())
            {
                Message.Error("Nem lehet azonos nevű kurzus a bemenetben!");
                return false;
            }

            return true;
        }

        private bool CheckIfInCourses(List<Control> controls)
        {
            bool inputIsInCourses = false;

            string errorMessage = "";

            foreach (var item in controls)
            {
                if(item is TextBox)
                {
                    TextBox tb = (TextBox)item;

                    using (DatabaseContext database = new DatabaseContext())
                    {
                        foreach (Course course in database.Courses)
                        {
                            if (course.Name.ToUpper() == tb.Text.ToUpper())
                            {
                                if (errorMessage == String.Empty)
                                {
                                    errorMessage += $"Ilyen kurzus már szerepel az adatbázisban!\n\nKurzusok:\n{course.Name}";
                                }
                                else
                                {
                                    errorMessage += "\n" + course.Name;
                                }

                                inputIsInCourses = true;
                            }
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

        private bool IfSaveCourseWasSuccessful(List<Control> controls)
        {
            TextBox name = (TextBox)controls[0];
            
            TextBox limit = (TextBox)controls[1];

            int number = Convert.ToInt32(limit.Text);

            Course course = new Course(name.Text, number);

            DatabaseContext.SaveCourse(course);

            return true;
        }

        private bool IfSaveTestWasSuccessful(List<Control> controls)
        {
            using (DatabaseContext database = new DatabaseContext())
            {

                ComboBox course = (ComboBox)controls[0];

                CheckBox bestAnswer = (CheckBox)controls[1];

                TextBox name = (TextBox)controls[2];

                TextBox submit_limit = (TextBox)controls[3];

                DatePicker startDatePicker = (DatePicker)controls[4];
            
                TextBox startTime = (TextBox)controls[5];

                DatePicker endDatePicker = (DatePicker)controls[6];

                TextBox endTime = (TextBox)controls[7];

                Course currentCourse = (Course) database.FindByName(course.SelectedValue.ToString(), typeof(Course));

                Test newTest = new Test(name.Text.ToString(), Convert.ToInt32(submit_limit.Text), (bool)bestAnswer.IsChecked, startDatePicker.SelectedDate.Value.Date.ToShortDateString(), startTime.Text.ToString(), endDatePicker.SelectedDate.Value.Date.ToShortDateString(), endTime.Text.ToString(), currentCourse.Id);

                DatabaseContext.SaveTest(newTest);
            }

            return true;
        }

        private bool IfSaveQuestionWasSuccessful(List<Control> controls)
        {
            using (DatabaseContext database = new DatabaseContext())
            {
                ComboBox questionType = (ComboBox)controls[0];

                ComboBox testName = (ComboBox)controls[1];

                TextBox pont = (TextBox)controls[2];

                TextBox questionName = (TextBox)controls[3];

                Test currentTest = (Test)database.FindByName(testName.SelectedValue.ToString(), typeof(Test));

                Question question = new Question(questionName.Text.ToString(), questionType.SelectedValue.ToString(), Convert.ToInt32(pont.Text), currentTest.Id);

                DatabaseContext.SaveQuestion(question);

                int step = controls.Count % 2 == 0 ? 2 : 1;

                for (int i = 4; i < controls.Count; i += step)
                {
                    TextBox questionValue = (TextBox)controls[i];

                    bool answer = false;

                    if(step == 2)
                    {
                        if (controls[i + 1] is CheckBox)
                        {
                            CheckBox answerCheckBox = (CheckBox)controls[i + 1];

                            answer = (bool)answerCheckBox.IsChecked;
                        }
                        else if (controls[i + 1] is RadioButton)
                        {
                            RadioButton answerRadioButton = (RadioButton)controls[i + 1];

                            answer = (bool)answerRadioButton.IsChecked;
                        }
                    }
                    else
                    {
                        answer = true;
                    }

                    Question questionForAnswer = database.Questions.Where(item => item.Name == question.Name && item.QuestionType == item.QuestionType).AsEnumerable().LastOrDefault();

                    Answer newAnswer = new Answer(questionValue.Text.ToString(), answer, questionForAnswer.Id);

                    DatabaseContext.SaveAnswer(newAnswer);
                }
            }

            return true;
        }
    }
}
