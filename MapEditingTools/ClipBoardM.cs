using System.Windows.Controls;
using System.Windows;

namespace MapEditingTools
{
    public class ClipBoardM
    {
        public static void Copy(TextBox tb)
        {
            string copyText = tb.Text;
            Clipboard.SetText(copyText);
        }

        public static void Empty(TextBox tb)
        {
            tb.Text = "";
        }
    }
}
