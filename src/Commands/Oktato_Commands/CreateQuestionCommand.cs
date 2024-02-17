using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Teszt__.src.Services;
using Teszt__.src.ViewModels.Oktato_ViewModels;

namespace Teszt__.src.Commands.Oktato_Commands
{
    class CreateQuestionCommand : CommandBase
    {
        private Grid grid;
        private StackPanel mainStackPanel;
        private OktatoMainViewModel _viewModel;

        public CreateQuestionCommand(ref Grid grid, ref StackPanel mainStackPanel, OktatoMainViewModel viewModel)
        {
            this.grid = grid;
            this.mainStackPanel = mainStackPanel;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.modelType = 2;

            _viewModel._AddNewRowButton.Content = "Új válasz";

            _viewModel._AddNewRowButton.Visibility = System.Windows.Visibility.Visible;

            GridService.ClearGrid(ref grid, ref mainStackPanel);

            grid = GridService.CreateQuestionGrid(grid, mainStackPanel);
        }
    }
}
