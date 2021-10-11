using System;
using System.Windows.Controls;

namespace MapEditingTools
{
    class Functions
    {
        public static void TranslateMap(TextBox input, TextBox output, TextBox translateX, TextBox translateY, TextBox translateZ)
        {
            CustomMap TranslatedMap = new CustomMap(input.Text);
            Point displacement = new Point(InputBoxM.GetTextboxNumber(translateX), InputBoxM.GetTextboxNumber(translateY), InputBoxM.GetTextboxNumber(translateZ));
            TranslatedMap.Translate(displacement);

            output.Text = TranslatedMap.ToString();
        }

        public static void RotateMap(TextBox input, TextBox output, RadioButton pivotButton, TextBox rotateX, TextBox rotateY, TextBox rotateZ, TextBox pivotX, TextBox pivotY, TextBox pivotZ)
        {
            CustomMap rotatedMap = new CustomMap(input.Text);
            Quaternion rotation = new Quaternion(-InputBoxM.GetTextboxNumber(rotateX), InputBoxM.GetTextboxNumber(rotateY), -InputBoxM.GetTextboxNumber(rotateZ));

            if (pivotButton.IsChecked == true)
            {
                Point pivot = new Point(InputBoxM.GetTextboxNumber(pivotX), InputBoxM.GetTextboxNumber(pivotY), InputBoxM.GetTextboxNumber(pivotZ));
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
                Point center = new Point(InputBoxM.GetTextboxNumber(centerX), InputBoxM.GetTextboxNumber(centerY), InputBoxM.GetTextboxNumber(centerZ));
                scaledMap.Scale(InputBoxM.GetTextboxNumber(Scale), center);
            }
            else
            {
                scaledMap.Scale(InputBoxM.GetTextboxNumber(Scale));
            }

            output.Text = scaledMap.ToString();
        }


            //      function mirrorMap(input, output, pivotButton, mirrorX, mirrorY, mirrorZ, pivotX, pivotY, pivotZ)
            //      {
            //          var mirroredMap = new customMap(document.getElementById(input).value);
            //          //var rotation = new quaternion(-Number(getTextboxNumber(rotateX)), Number(getTextboxNumber(rotateY)), -Number(getTextboxNumber(rotateZ)));
            //          //var rotation = new quaternion(-Number(69), Number(69), -Number(69));
            //          var axes = [getCheckboxState(mirrorX), getCheckboxState(mirrorY), getCheckboxState(mirrorZ)];

            //          if (document.getElementById(pivotButton).checked == true)
            //{
            //                  var pivot = new Point(Number(getTextboxNumber(pivotX)), Number(getTextboxNumber(pivotY)), Number(getTextboxNumber(pivotZ)));
            //                  mirroredMap.Mirror(axes, pivot);
            //              }
            //else
            //              {
            //                  mirroredMap.Mirror(axes);
            //              }

            //              document.getElementById(output).value = mirroredMap.toString();
            //              }
        }
}