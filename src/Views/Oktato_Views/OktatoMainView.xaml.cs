using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Teszt__.src.Views.Oktato_Views
{
    /// <summary>
    /// Interaction logic for OktatoMainView.xaml
    /// </summary>
    public partial class OktatoMainView : Page
    {
        public StackPanel _mainStackPanel;

        public OktatoMainView()
        {
            InitializeComponent();

            _mainStackPanel = mainStackPanel;
        }
    }
}
