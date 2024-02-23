using System.Windows.Controls;
using Teszt__.src.Services;

namespace Teszt__.src.ViewModels.Oktato_ViewModels
{
    public class ShowDataViewModel : ViewModelBase
    {
        public ShowDataViewModel(string mode, StackPanel mainStackPanel, Button sendButton)
        {
            DataGridService.CreateDataGrid(mode, ref mainStackPanel, ref sendButton);
        }
    }
}
