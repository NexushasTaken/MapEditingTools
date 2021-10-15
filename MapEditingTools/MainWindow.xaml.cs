using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MapEditingTools
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ChangePanel(EToolVars tool)
        {
            _MainWindow.Width = 800;
            _MainWindow.Title = "Aottg Map Tools";
            switch (tool)
            {
                case EToolVars.Mirror:
                    _MirrorPanel.Visibility = Visibility.Visible;
                    _RotatePanel.Visibility = Visibility.Hidden;
                    _ScalePanel.Visibility = Visibility.Hidden;
                    _TranslatePanel.Visibility = Visibility.Hidden;
                    _RotationConverter.Visibility = Visibility.Hidden;
                    _ColorCodeConverter.Visibility = Visibility.Hidden;
                    break;
                case EToolVars.Rotate:
                    _MirrorPanel.Visibility = Visibility.Hidden;
                    _RotatePanel.Visibility = Visibility.Visible;
                    _ScalePanel.Visibility = Visibility.Hidden;
                    _TranslatePanel.Visibility = Visibility.Hidden;
                    _RotationConverter.Visibility = Visibility.Hidden;
                    _ColorCodeConverter.Visibility = Visibility.Hidden;
                    break;
                case EToolVars.Scale:
                    _MirrorPanel.Visibility = Visibility.Hidden;
                    _RotatePanel.Visibility = Visibility.Hidden;
                    _ScalePanel.Visibility = Visibility.Visible;
                    _TranslatePanel.Visibility = Visibility.Hidden;
                    _RotationConverter.Visibility = Visibility.Hidden;
                    _ColorCodeConverter.Visibility = Visibility.Hidden;
                    break;
                case EToolVars.Translate:
                    _MirrorPanel.Visibility = Visibility.Hidden;
                    _RotatePanel.Visibility = Visibility.Hidden;
                    _ScalePanel.Visibility = Visibility.Hidden;
                    _TranslatePanel.Visibility = Visibility.Visible;
                    _RotationConverter.Visibility = Visibility.Hidden;
                    _ColorCodeConverter.Visibility = Visibility.Hidden;
                    break;
                case EToolVars.RotationConverter:
                    _MirrorPanel.Visibility = Visibility.Hidden;
                    _RotatePanel.Visibility = Visibility.Hidden;
                    _ScalePanel.Visibility = Visibility.Hidden;
                    _TranslatePanel.Visibility = Visibility.Hidden;
                    _RotationConverter.Visibility = Visibility.Visible;
                    _ColorCodeConverter.Visibility = Visibility.Hidden;
                    break;
                case EToolVars.ColorCodeConverter:
                    _MirrorPanel.Visibility = Visibility.Hidden;
                    _RotatePanel.Visibility = Visibility.Hidden;
                    _ScalePanel.Visibility = Visibility.Hidden;
                    _TranslatePanel.Visibility = Visibility.Hidden;
                    _RotationConverter.Visibility = Visibility.Hidden;
                    _ColorCodeConverter.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        private void MirrorItem_Selected(object sender, RoutedEventArgs e)
        {
            ChangePanel(EToolVars.Mirror);
        }
        private void RotateItem_Selected(object sender, RoutedEventArgs e)
        {
            ChangePanel(EToolVars.Rotate);
        }
        private void ScaleItem_Selected(object sender, RoutedEventArgs e)
        {
            ChangePanel(EToolVars.Scale);
        }
        private void TranslateItem_Selected(object sender, RoutedEventArgs e)
        {
            ChangePanel(EToolVars.Translate);
        }
        private void RotationConvertItem_Selected(object sender, RoutedEventArgs e)
        {
            ChangePanel(EToolVars.RotationConverter);
        }
        private void ColorCodeConvertItem_Selected(object sender, RoutedEventArgs e)
        {
            ChangePanel(EToolVars.ColorCodeConverter);
        }

        private void ScalePoint_Checked(object sender, RoutedEventArgs e)
        {
            _ScalePointCanvas.Visibility = Visibility.Visible;
        }
        private void ScalePoint_Unchecked(object sender, RoutedEventArgs e)
        {
            _ScalePointCanvas.Visibility = Visibility.Hidden;
        }
        private void RotatePoint_Checked(object sender, RoutedEventArgs e)
        {
            _RotatePointCanvas.Visibility = Visibility.Visible;
        }
        private void RotatePoint_Unchecked(object sender, RoutedEventArgs e)
        {
            _RotatePointCanvas.Visibility = Visibility.Hidden;
        }
        private void MirrorPoint_Checked(object sender, RoutedEventArgs e)
        {
            _MirrorPointCanvas.Visibility = Visibility.Visible;
        }
        private void MirrorPoint_Unchecked(object sender, RoutedEventArgs e)
        {
            _MirrorPointCanvas.Visibility = Visibility.Hidden;
        }

        private void TranslateBtn_Click(object sender, RoutedEventArgs e)
        {
            Functions.TranslateMap(_TranslateTBA, _TranslateTBB, _TranslateX, _TranslateY, _TranslateZ);
        }
        private void RotateBtn_Click(object sender, RoutedEventArgs e)
        {
            Functions.RotateMap(_RotateTBA, _RotateTBB, _RotateMapCenter, _RotateXAngle, _RotateYAngle, _RotateZAngle, _RotateXPos, _RotateYPos, _RotateZPos);
        }
        private void ScaleBtn_Click(object sender, RoutedEventArgs e)
        {
            Functions.ScaleMap(_ScaleTBA, _ScaleTBB, _ScaleMapCenter, _ScaleTB, _ScaleXPos, _ScaleYPos, _ScaleZPos);
        }
        private void MirrorBtn_Click(object sender, RoutedEventArgs e)
        {
            Functions.MirrorMap(_MirrorTBA, _MirrorTBB, _MirrorMapCenter, _MirrorX, _MirrorY, _MirrorZ, _MirrorXPos, _MirrorYPos, _MirrorZPos);
        }

        private void TranslateCopyA_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Copy(_TranslateTBA);
        }
        private void TranslateClearA_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Empty(_TranslateTBA);
        }
        private void TranslateCopyB_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Copy(_TranslateTBB);
        }
        private void TranslateClearB_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Empty(_TranslateTBB);
        }

        private void ScaleCopyA_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Copy(_ScaleTBA);
        }
        private void ScaleClearA_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Empty(_ScaleTBA);
        }
        private void ScaleCopyB_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Copy(_ScaleTBB);
        }
        private void ScaleClearB_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Copy(_ScaleTBB);
        }

        private void RotateCopyA_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Copy(_RotateTBA);
        }
        private void RotateClearA_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Empty(_RotateTBA);
        }
        private void RotateCopyB_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Copy(_RotateTBB);
        }
        private void RotateClearB_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Empty(_RotateTBB);
        }

        private void MirrorCopyA_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Copy(_MirrorTBA);
        }
        private void MirrorClearA_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Empty(_MirrorTBA);
        }
        private void MirrorCopyB_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Copy(_MirrorTBB);
        }
        private void MirrorClearB_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Empty(_MirrorTBB);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void Euler_TextChanged(object sender, TextChangedEventArgs e)
        {
            Quaternion quaternion = new Quaternion(InputBoxM.GetTextboxNumberA(_EulerX), InputBoxM.GetTextboxNumberA(_EulerY), InputBoxM.GetTextboxNumberA(_EulerZ));
            _QuatW.Text = quaternion.W.toFixed(7).ToString();
            _QuatX.Text = quaternion.X.toFixed(7).ToString();
            _QuatY.Text = quaternion.Y.toFixed(7).ToString();
            _QuatZ.Text = quaternion.Z.toFixed(7).ToString();
        }

        private void EulerCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText($"{_EulerX.Text},{_EulerY.Text},{_EulerZ.Text}");
        }

        private void QuatCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText($"{_QuatX.Text},{_QuatY.Text},{_QuatZ.Text},{_QuatW.Text}");
        }

        private void RGBTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsDigit(_RedTB.Text) && IsDigit(_BlueTB.Text) && IsDigit(_GreenTB.Text))
            {
                if (Convert.ToInt32(_RedTB.Text) <= 256 && 
                    Convert.ToInt32(_BlueTB.Text) <= 256 && 
                    Convert.ToInt32(_GreenTB.Text) <= 256)
                {
                    _HexTB.Text = string.Format("{0:X2}{1:X2}{2:X2}",
                        Convert.ToInt32(_RedTB.Text), 
                        Convert.ToInt32(_BlueTB.Text), 
                        Convert.ToInt32(_GreenTB.Text));
                }
            }
        }

        private void HexTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            string txt = _HexTB.Text;
            int Length = txt.Length;
            if (!(Length >= 7 || Length <= 5) || Length == 6)
            {
                if (IsHex(_HexTB.Text))
                {
                    string _Red = txt.Substring(0, 2);
                    string _Green = txt.Substring(2, 2);
                    string _Blue = txt.Substring(4, 2);
                    _RedTB.Text = Convert.ToInt32(_Red, 16).ToString();
                    _GreenTB.Text = Convert.ToInt32(_Green, 16).ToString();
                    _BlueTB.Text = Convert.ToInt32(_Blue, 16).ToString();
                }
            }
            _HexTB.Text = txt;
        }
        static bool IsDigit(string str)
        {
            try
            {
                Convert.ToInt32(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        static bool IsHex(string str)
        {
            char[] array = str.ToCharArray();
            foreach (char c in array)
            {
                if (!Uri.IsHexDigit(c))
                {
                    return false;
                }
            }
            return true;
        }


        private void RGBCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText($"{_RedTB.Text} {_GreenTB.Text} {_BlueTB.Text}");
        }

        private void HexCopy_Click(object sender, RoutedEventArgs e)
        {
            ClipBoardM.Copy(_HexTB);
        }
    }
}
