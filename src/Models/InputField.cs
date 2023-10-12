using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Teszt__.src.Models
{
    public class InputField
    {
        public Dictionary<string, TextBox> textBoxes;

        public Dictionary<string, PasswordBox> passwordBoxes;

        public void ClearColorOfInputFields()
        {
            foreach(var textBox in textBoxes.Values)
            {
                textBox.Background = Brushes.White;
            }
            
            foreach(var passwordBox in passwordBoxes.Values)
            {
                passwordBox.Background = Brushes.White;
            }
        }

        public void ChangeColor(string keyOfTextBox)
        {
            if(textBoxes.ContainsKey(keyOfTextBox))
            {
                textBoxes[keyOfTextBox].Background = Brushes.Red;
            }
            else if(passwordBoxes.ContainsKey(keyOfTextBox))
            {
                passwordBoxes[keyOfTextBox].Background = Brushes.Red;
            }
        }

        public static InputField operator +(InputField inputField, Dictionary<string, TextBox> textBox)
        {
            inputField.textBoxes = textBox;

            return inputField;
        }

        public static InputField operator +(InputField inputField, Dictionary<string, PasswordBox> passwordBox)
        {
            inputField.passwordBoxes = passwordBox;

            return inputField;
        }
    }
}
