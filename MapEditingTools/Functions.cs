using System;
using System.Windows.Controls;

namespace MapEditingTools
{
    class Functions
    {
        public static void TranslateMap(TextBox input, TextBox output, string translateX, string translateY, string translateZ)
        {
            CustomMap TranslatedMap = new CustomMap(input.Text);
            Point displacement = new Point(Convert.ToDouble(translateX), Convert.ToDouble(translateY), Convert.ToDouble(translateZ));
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
        //          function scaleMap(input, output, pivotButton, Scale, centerX, centerY, centerZ)
        //          {
        //              var scaledMap = new customMap(document.getElementById(input).value);

        //              if (document.getElementById(pivotButton).checked == true)
        //{
        //              var center = new Point(Number(getTextboxNumber(centerX)), Number(getTextboxNumber(centerY)), Number(getTextboxNumber(centerZ)));
        //              scaledMap.Scale(Number(getTextboxNumber(Scale)), center);
        //          }
        //else
        //          {
        //              scaledMap.Scale(Number(getTextboxNumber(Scale)));
        //          }

        //          document.getElementById(output).value = scaledMap.toString();

        //      }


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