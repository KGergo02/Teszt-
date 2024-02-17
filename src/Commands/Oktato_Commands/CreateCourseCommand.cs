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

        private OktatoMainViewModel _viewModel;

        public CreateCourseCommand(ref Grid grid, ref StackPanel mainStackPanel, OktatoMainViewModel viewModel)
        {
            _grid = grid;
            _mainStackPanel = mainStackPanel;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.modelType = 0;

            _viewModel._AddNewRowButton.Content = "Új sor";

            _viewModel._AddNewRowButton.Visibility = System.Windows.Visibility.Visible;

            GridService.ClearGrid(ref _grid, ref _mainStackPanel);

            _grid = GridService.CreateCourseGrid(ref _grid, ref _mainStackPanel);
        }
    }
}
