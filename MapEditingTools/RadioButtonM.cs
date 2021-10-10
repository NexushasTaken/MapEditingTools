using System.Windows.Controls;

namespace MapEditingTools
{
    public class RadioButtonM
    {
        public static bool GetRadioButtonState(RadioButton rb)
        {
            return (bool)rb.IsChecked;
        }
        //Idk whats this use for
        //function fixEdgeBug(Default, Other)
        //{
        //    if (window.navigator.userAgent.indexOf("Edge") > -1)
        //    {
        //        if (!document.getElementById(Default).checked && !document.getElementById(Other).checked)
        //        {
        //            document.getElementById(Default).checked = false;
        //            document.getElementById(Other).checked = true;
        //        }
        //    }
        //}
    }
}
