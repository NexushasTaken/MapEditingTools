using System;
using System.Windows.Controls;

namespace MapEditingTools
{
    public class InputBoxM
    {
        public static double GetTextboxNumberA(TextBox textbox)
        {
            if (textbox.Text == null || textbox.Text.Equals(""))
            {
                textbox.Text = 0.ToString();
                return 0;
            }
            return Convert.ToInt32(textbox.Text);
        }

        public static double GetTextboxNumberB(TextBox textbox)
        {
            try
            {
                if (Convert.ToDouble(textbox.Text) >= 360)
                {
                    textbox.Text = 359.ToString();
                    return 359;
                }
                else
                {
                    return Convert.ToDouble(textbox.Text);
                }
            }
            catch (FormatException)
            {
                textbox.Text = "0";
                return 0;
            }
        }
    }
}
