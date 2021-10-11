using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditingTools
{
    public class InputBoxM
    {
        public static double GetTextboxNumber(TextBox textbox)
        {
            if (textbox.Text == null || textbox.Text.Equals(""))
            {
                textbox.Text = 0.ToString();
                return 0;
            }

            return Convert.ToDouble(textbox.Text);
        }

        //Idk whats this use for
        //function isNumberKey(evt)
        //{
        //    var charCode = (evt.which) ? evt.which : evt.keyCode;

        //    //number keys
        //    if (charCode >= 48 && charCode <= 57)
        //    {
        //        return true;
        //    }

        //    //these overlap with the arrow keys in ascii
        //    if (["%", "&", "'", "("].includes(evt.key))
        //    {
        //        return false;
        //    }

        //    //arrow keys
        //    if (charCode >= 37 && charCode <= 40)
        //    {
        //        return true;
        //    }

        //    //misc (control, backspace, tab, insert, delete)
        //    if (evt.ctrlKey || charCode == 8 || charCode == 9 || charCode == 45 || charCode == 46)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

    }
}
