using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditingTools
{
    class ColorCode
    {
        public int _Red;
        public int _Green;
        public int _Blue;
        public string _Hex;

        //RGB to Hex
        public ColorCode(int _Red, int _Green, int _Blue)
        {
            _Hex = string.Format("{0:X2}{1:X2}{2:X2}", _Red, _Green, _Blue);
        }

        //Hex to RGB
        public ColorCode(string _Hex)
        {
            _Hex = _Hex.ToUpper();
            if (Checked(_Hex))
            {
                if (_Hex.Length == 7 && _Hex.ToCharArray()[0].Equals('#'))
                {
                    string _Red = _Hex.Substring(1, 2);
                    this._Red = Convert.ToInt32(_Red, 16);

                    string _Green = _Hex.Substring(3, 2);
                    this._Green = Convert.ToInt32(_Green, 16);

                    string _Blue = _Hex.Substring(5, 2);
                    this._Blue = Convert.ToInt32(_Blue, 16);

                }
                else if (_Hex.Length == 6)
                {
                    string _Red = _Hex.Substring(0, 2);
                    this._Red = Convert.ToInt32(_Red, 16);

                    string _Green = _Hex.Substring(2, 2);
                    this._Green = Convert.ToInt32(_Green, 16);

                    string _Blue = _Hex.Substring(4, 2);
                    this._Blue = Convert.ToInt32(_Blue, 16);
                }
            }
            else
            {
                _Red = 0;
                _Green = 0;
                _Blue = 0;
            }
        }
        private static bool Checked(string hex)
        {
            char[] array = hex.ToCharArray();
            foreach (char item in array)
            {
                if (item.Equals('#'))
                {
                    continue;
                }
                Enum.TryParse(item.ToString(), out Hex getParse);
                if (getParse == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
    enum Hex
    {
        A = 10, B = 11, C = 12, D = 13, E = 14, F = 15
    }
}
