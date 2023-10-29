using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Teszt__.src.DAL;
using Teszt__.src.Services;
using Teszt__.src.ViewModels.Oktato_ViewModels;
using static Teszt__.src.DAL.UserDatabaseContext;

namespace Teszt__.src.Commands.Oktato_Commands
{
    class CreateTestCommand : CommandBase
    {
        private Grid grid;
        private StackPanel mainStackPanel;
        private OktatoMainViewModel _viewModel;
        public CreateTestCommand(ref Grid grid, ref StackPanel mainStackPanel, OktatoMainViewModel viewModel)
        {
            this.grid = grid;
            this.mainStackPanel = mainStackPanel;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.modelType = 1;

            _viewModel._AddNewRowButton.Content = "Új sor";

            GridService.ClearGrid(ref grid, ref mainStackPanel);

            grid = GridService.CreateTestGrid(ref grid, ref mainStackPanel);
        }
    }
}
