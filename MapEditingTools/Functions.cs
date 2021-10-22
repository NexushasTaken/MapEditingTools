using System;
using System.Windows.Controls;

namespace MapEditingTools
{
    class Functions
    {
        public static void TranslateMap(TextBox input, TextBox output, TextBox translateX, TextBox translateY, TextBox translateZ)
        {
            CustomMap TranslatedMap = new CustomMap(input.Text);
            Point displacement = new Point(InputBoxM.GetTextboxNumberA(translateX), InputBoxM.GetTextboxNumberA(translateY), InputBoxM.GetTextboxNumberA(translateZ));
            TranslatedMap.Translate(displacement);

            output.Text = TranslatedMap.ToString();
        }

        public static void RotateMap(TextBox input, TextBox output, RadioButton pivotButton, TextBox rotateX, TextBox rotateY, TextBox rotateZ, TextBox pivotX, TextBox pivotY, TextBox pivotZ)
        {
            CustomMap rotatedMap = new CustomMap(input.Text);
            Quaternion rotation = new Quaternion(-InputBoxM.GetTextboxNumberA(rotateX), InputBoxM.GetTextboxNumberA(rotateY), -InputBoxM.GetTextboxNumberA(rotateZ));

            if (pivotButton.IsChecked == true)
            {
                Point pivot = new Point(InputBoxM.GetTextboxNumberA(pivotX), InputBoxM.GetTextboxNumberA(pivotY), InputBoxM.GetTextboxNumberA(pivotZ));
                rotatedMap.Rotate(rotation, pivot);
            }
            else
            {
                rotatedMap.Rotate(rotation);
            }
            output.Text = rotatedMap.ToString();
        }
        public static void ScaleMap(TextBox input, TextBox output, RadioButton pivotButton, TextBox Scale, TextBox centerX, TextBox centerY, TextBox centerZ)
        {
            CustomMap scaledMap = new CustomMap(input.Text);

            if (pivotButton.IsChecked == true)
            {
                Point center = new Point(InputBoxM.GetTextboxNumberA(centerX), InputBoxM.GetTextboxNumberA(centerY), InputBoxM.GetTextboxNumberA(centerZ));
                scaledMap.Scale(InputBoxM.GetTextboxNumberA(Scale), center);
            }
            else
            {
                scaledMap.Scale(InputBoxM.GetTextboxNumberA(Scale));
            }

            output.Text = scaledMap.ToString();
        }


        public static void MirrorMap(TextBox input, TextBox output, RadioButton pivotButton, CheckBox mirrorX, CheckBox mirrorY, CheckBox mirrorZ, TextBox pivotX, TextBox pivotY, TextBox pivotZ)
        {
            CustomMap mirroredMap = new CustomMap(input.Text);
            //var rotation = new quaternion(-Number(getTextboxNumber(rotateX)), Number(getTextboxNumber(rotateY)), -Number(getTextboxNumber(rotateZ)));
            //var rotation = new quaternion(-Number(69), Number(69), -Number(69));
            bool[] axes = { 
                (bool)mirrorX.IsChecked, 
                (bool)mirrorY.IsChecked, 
                (bool)mirrorZ.IsChecked 
            };

            if (pivotButton.IsChecked == true)
            {
                //Point pivot = new Point(InputBoxM.GetTextboxNumber(pivotX)), InputBoxM.GetTextboxNumber(pivotY)), InputBoxM.GetTextboxNumber(pivotZ)));
                Point pivot = new Point(InputBoxM.GetTextboxNumberA(pivotX), InputBoxM.GetTextboxNumberA(pivotY), InputBoxM.GetTextboxNumberA(pivotZ));
                mirroredMap.Mirror(axes, pivot);
            }
            else
            {
                mirroredMap.Mirror(axes);
            }

            output.Text = mirroredMap.ToString();
        }
    }
}