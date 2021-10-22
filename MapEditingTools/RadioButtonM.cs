using System.Windows.Controls;

namespace MapEditingTools
{
    public class RadioButtonM
    {
        public static bool GetRadioButtonState(RadioButton rb)
        {
            return (bool)rb.IsChecked;
        }
    }
}
