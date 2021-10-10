using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditingTools
{
    public class CheckBoxM
    {
        public static bool GetCheckboxState(CheckBox cb)
        {
            return (bool)cb.IsChecked;
        }
    }
}
