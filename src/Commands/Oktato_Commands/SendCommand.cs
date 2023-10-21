using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Teszt__.src.Services;
using Teszt__.src.Models;
using Teszt__.src.DAL;
using static Teszt__.src.DAL.Database;

namespace Teszt__.src.Commands.Oktato_Commands
{
    class SendCommand : CommandBase
    {
        private Grid _grid;

        private StackPanel _mainStackPanel;

        private int _modelType;

        private Func<StackPanel, Grid> _initializeCourseGrid;

        public SendCommand(ref Grid grid, ref StackPanel mainStackPanel , ref int modelType, Func<StackPanel, Grid> initializeCourseGrid)
        {
            _grid = grid;

            _modelType = modelType;

            _initializeCourseGrid = initializeCourseGrid;

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
            }

            for (int i = _grid.ColumnDefinitions.Count; i < _grid.Children.Count; i += _grid.ColumnDefinitions.Count)
            {
                List<Control> controls = new List<Control>();
                
                for (int j = 0; j < _grid.ColumnDefinitions.Count; j++)
                {
                    Control item = (Control)_grid.Children[i + j];

                    controls.Add(item);
                }

                switch (_modelType)
                {
                    case 0:
                        if (CheckCourseInputs())
                        {
                            SaveCourse(controls);
                        }
                        else return;
                        break;
                }

                controls.Clear();
            }

            GridService.ClearGrid(ref _grid, ref _mainStackPanel);

            _grid = _initializeCourseGrid(_mainStackPanel);

            Message.Success("Kurzus sikeresen létrehozva!");
        }

        private bool CheckCourseInputs()
        {
            foreach (var item in _grid.Children)
            {
                if(item is TextBox)
                {
                    TextBox tb = (TextBox)item;

#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
                    if (tb.Tag == "number")
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
                    {
                        int number = 0;

                        if (!int.TryParse(tb.Text, out number))
                        {
                            Message.Error("Nem számot adtál meg!");

                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void SaveCourse(List<Control> controls)
        {
            TextBox name = (TextBox)controls[0];
            
            TextBox limit = (TextBox)controls[1];

            int number = Convert.ToInt32(limit.Text);

            Course course = new Course(name.Text, number, new List<Test>());

            Database database = new Database();

            database.Courses.Add(course);

            database.SaveChanges();
        }
    }
}
