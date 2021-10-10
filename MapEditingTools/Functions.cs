using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

  //      function rotateMap(input, output, pivotButton, rotateX, rotateY, rotateZ, pivotX, pivotY, pivotZ)
  //      {
  //          var rotatedMap = new customMap(document.getElementById(input).value);
  //          var rotation = new quaternion(-Number(getTextboxNumber(rotateX)), Number(getTextboxNumber(rotateY)), -Number(getTextboxNumber(rotateZ)));

  //          if (document.getElementById(pivotButton).checked == true)
  //{
  //                  var pivot = new Point(Number(getTextboxNumber(pivotX)), Number(getTextboxNumber(pivotY)), Number(getTextboxNumber(pivotZ)));
  //                  rotatedMap.Rotate(rotation, pivot);
  //              }
  //else
  //              {
  //                  rotatedMap.Rotate(rotation);
  //              }

  //              document.getElementById(output).value = rotatedMap.toString();
  //              }

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
