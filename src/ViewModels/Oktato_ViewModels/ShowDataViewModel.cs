using System.Windows.Controls;
using System.Windows.Input;
using Teszt__.src.Commands;
using Teszt__.src.Commands.Oktato_Commands;
using Teszt__.src.Commands.User_Commands;
using Teszt__.src.Services;

namespace Teszt__.src.ViewModels.Oktato_ViewModels
{
    public class ShowDataViewModel : ViewModelBase
    {
        public ShowDataViewModel(string mode, StackPanel mainStackPanel, Button sendButton)
        {
            NavigateToOktatoViewCommand = new NavigateToOktatoViewCommand();

            ShowUserProfileCommand = new ShowUserProfileCommand();

            LogOutCommand = new LogOutCommand();

            DataGridService.CreateDataGrid(mode, ref mainStackPanel, ref sendButton);
        }

        public ICommand NavigateToOktatoViewCommand { get; }
        public ICommand ShowUserProfileCommand { get; }
        public ICommand LogOutCommand { get; }
    }
}
