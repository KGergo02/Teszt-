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

        public SendCommand(Grid grid, StackPanel mainStackPanel , ref int modelType, Func<StackPanel, Grid> initializeCourseGrid)
        {
            _grid = grid;

            _modelType = modelType;

            _initializeCourseGrid = initializeCourseGrid;

            _mainStackPanel = mainStackPanel;
        }

        public override void Execute(object parameter)
        {
            for (int i = _grid.ColumnDefinitions.Count; i < _grid.Children.Count; i += _grid.ColumnDefinitions.Count)
            {
                List<TextBox> textBoxes = new List<TextBox>();
                
                for (int j = 0; j < _grid.ColumnDefinitions.Count; j++)
                {
                    TextBox item = (TextBox)_grid.Children[i + j];

                    textBoxes.Add(item);
                }

                foreach (TextBox item in textBoxes)
                {
                    if(item.Text == null || item.Text == String.Empty)
                    {
                        Message.Error("Nem töltöttél ki minden mezőt!");

                        return;
                    }
                }

                switch (_modelType)
                {
                    case 0:
                        SaveCourse(textBoxes);
                        break;
                }

                textBoxes.Clear();
            }

            GridService.ClearGrid(ref _grid, ref _mainStackPanel);

            _grid = _initializeCourseGrid(_mainStackPanel);

            Message.Success("Kurzus sikeresen létrehozva!");
        }

        private void SaveCourse(List<TextBox> textBoxes)
        {
            Course course = new Course(textBoxes[0].Text, Convert.ToInt32(textBoxes[1].Text), new List<Test>());

            Database database = new Database();

            database.Courses.Add(course);

            database.SaveChanges();
        }
    }
}
