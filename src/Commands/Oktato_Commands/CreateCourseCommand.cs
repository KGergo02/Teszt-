using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using Teszt__.src.Models;
using Teszt__.src.Services;
using Teszt__.src.ViewModels.Oktato_ViewModels;
using Teszt__.src.Views.Oktato_Views;

namespace Teszt__.src.Commands.Oktato_Commands
{
    class CreateCourseCommand : CommandBase
    {
        private StackPanel _mainStackPanel;

        private Grid _grid;
        
        private Func<StackPanel, Grid> _initializeCourseGrid;

        public CreateCourseCommand(ref Grid grid, ref StackPanel mainStackPanel, Func<StackPanel, Grid> initializeCourseGrid)
        {
            _grid = grid;
            _mainStackPanel = mainStackPanel;
            _initializeCourseGrid = initializeCourseGrid;
        }

        public override void Execute(object parameter)
        {
            GridService.ClearGrid(ref _grid, ref _mainStackPanel);

            _grid = _initializeCourseGrid(_mainStackPanel);
        }
    }
}
