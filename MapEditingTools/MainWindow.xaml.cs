using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapEditingTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
                    break;
                case EToolVars.Rotate:
                    _MirrorPanel.Visibility = Visibility.Hidden;
                    _RotatePanel.Visibility = Visibility.Visible;
                    _ScalePanel.Visibility = Visibility.Hidden;
                    _TranslatePanel.Visibility = Visibility.Hidden;
                    break;
                case EToolVars.Scale:
                    _MirrorPanel.Visibility = Visibility.Hidden;
                    _RotatePanel.Visibility = Visibility.Hidden;
                    _ScalePanel.Visibility = Visibility.Visible;
                    _TranslatePanel.Visibility = Visibility.Hidden;
                    break;
                case EToolVars.Translate:
                    _MirrorPanel.Visibility = Visibility.Hidden;
                    _RotatePanel.Visibility = Visibility.Hidden;
                    _ScalePanel.Visibility = Visibility.Hidden;
                    _TranslatePanel.Visibility = Visibility.Visible;
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
    }
}
