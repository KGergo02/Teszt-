using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Teszt__.src.Services
{
    public class ControlEventService
    {
        public static void OnCourseCardLabelClick(object sender, MouseButtonEventArgs args)
        {
            Label courseLabel = (Label)sender;

            foreach (Label item in (List<Label>)courseLabel.Tag)
            {
                if(item.IsVisible)
                {
                    item.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    item.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }
    }
}
