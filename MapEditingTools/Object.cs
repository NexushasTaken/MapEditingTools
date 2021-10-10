using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditingTools
{
    public class Object
    {
        private string _type;
        private string _content;
        private string _shape;
        private int _scriptLength;
        private string _texture;
        private string _name;
        private double _length;
        private double _height;
        private double _width;
        private int _color;
        private double _red;
        private double _green;
        private double _blue;
        private double _tileX;
        private double _tileY;
        private double _Xpos;
        private double _Ypos;
        private double _Zpos;
        private double _Xangle;
        private double _Yangle;
        private double _Zangle;
        private double _Wangle;
        private double _spawnTime;
        private int _endlessMode;
        private int _objectType;

        public Object(string objectScript)
        {
            string[] elementList = objectScript.Split(',');

            _type = elementList[0];
            _shape = elementList[1];
            _scriptLength = elementList.Length;

            if ((_type.Equals("custom") || _type.Equals("customb") || _type.Equals("base") || (_type.Equals("photon") && !_shape.Substring(0, 5).Equals("spawn"))) && _scriptLength >= 19)
            {
                _texture = elementList[2];
                _length = Convert.ToDouble(elementList[3]);
                _height = Convert.ToDouble(elementList[4]);
                _width = Convert.ToDouble(elementList[5]);
                _color = Convert.ToInt32(elementList[6]);
                _red = Convert.ToDouble(elementList[7]);
                _green = Convert.ToDouble(elementList[8]);
                _blue = Convert.ToDouble(elementList[9]);
                _tileX = Convert.ToDouble(elementList[10]);
                _tileY = Convert.ToDouble(elementList[11]);
                _Xpos = Convert.ToDouble(elementList[12]);
                _Ypos = Convert.ToDouble(elementList[13]);
                _Zpos = Convert.ToDouble(elementList[14]);
                _Xangle = Convert.ToDouble(elementList[15]);
                _Yangle = Convert.ToDouble(elementList[16]);
                _Zangle = Convert.ToDouble(elementList[17]);
                _Wangle = Convert.ToDouble(elementList[18]);
                _objectType = 0;
            }
            else if (_type.Equals("base") && _scriptLength >= 9)
            {
                _Xpos = Convert.ToDouble(elementList[2]);
                _Ypos = Convert.ToDouble(elementList[3]);
                _Zpos = Convert.ToDouble(elementList[4]);
                _Xangle = Convert.ToDouble(elementList[5]);
                _Yangle = Convert.ToDouble(elementList[6]);
                _Zangle = Convert.ToDouble(elementList[7]);
                _Wangle = Convert.ToDouble(elementList[8]);
            }
            else if (_type.Equals("racing") || _type.Equals("misc") && _shape.Equals("barrier") && _scriptLength >= 12)
            {
                _length = Convert.ToDouble(elementList[2]);
                _height = Convert.ToDouble(elementList[3]);
                _width = Convert.ToDouble(elementList[4]);
                _Xpos = Convert.ToDouble(elementList[5]);
                _Ypos = Convert.ToDouble(elementList[6]);
                _Zpos = Convert.ToDouble(elementList[7]);
                _Xangle = Convert.ToDouble(elementList[8]);
                _Yangle = Convert.ToDouble(elementList[9]);
                _Zangle = Convert.ToDouble(elementList[10]);
                _Wangle = Convert.ToDouble(elementList[11]);
            }
            else if (_type.Equals("misc") && _scriptLength >= 13)
            {
                _name = elementList[2];
                _length = Convert.ToDouble(elementList[3]);
                _height = Convert.ToDouble(elementList[4]);
                _width = Convert.ToDouble(elementList[5]);
                _Xpos = Convert.ToDouble(elementList[6]);
                _Ypos = Convert.ToDouble(elementList[7]);
                _Zpos = Convert.ToDouble(elementList[8]);
                _Xangle = Convert.ToDouble(elementList[9]);
                _Yangle = Convert.ToDouble(elementList[10]);
                _Zangle = Convert.ToDouble(elementList[11]);
                _Wangle = Convert.ToDouble(elementList[12]);
            }
            else if (_type.Equals("spawnpoint") && _scriptLength >= 9)
            {
                _Xpos = Convert.ToDouble(elementList[2]);
                _Ypos = Convert.ToDouble(elementList[3]);
                _Zpos = Convert.ToDouble(elementList[4]);
                _Xangle = Convert.ToDouble(elementList[5]);
                _Yangle = Convert.ToDouble(elementList[6]);
                _Zangle = Convert.ToDouble(elementList[7]);
                _Wangle = Convert.ToDouble(elementList[8]);
            }
            else if (_type.Equals("photon") && _scriptLength >= 11)
            {
                _spawnTime = Convert.ToDouble(elementList[2]);
                _endlessMode = Convert.ToInt32(elementList[3]);
                _Xpos = Convert.ToDouble(elementList[4]);
                _Ypos = Convert.ToDouble(elementList[5]);
                _Zpos = Convert.ToDouble(elementList[6]);
                _Xangle = Convert.ToDouble(elementList[7]);
                _Yangle = Convert.ToDouble(elementList[8]);
                _Zangle = Convert.ToDouble(elementList[9]);
                _Wangle = Convert.ToDouble(elementList[10]);
            }
            else
            {
                _type = "comment";
                _content = objectScript;
                _shape = null;
            }
        }

    //class functions \o/
    public bool IsComment()
    {
        return _type.Equals("comment");
    }

    public void SetSize(double length, double height, double width)
    {
        _length = length;
        _height = height;
        _width = width;
    }

    public void SetQuat(Quaternion quaternion)
    {
        _Xangle = quaternion.X;
        _Yangle = quaternion.Y;
        _Zangle = quaternion.Z;
        _Wangle = quaternion.W;
    }

    public void SetQuat(double x, double y, double z, double w)
    {
        _Xangle = x;
        _Yangle = y;
        _Zangle = z;
        _Wangle = w;
    }
        public override string ToString()
        {
            var objectScript = _type + "," + _shape;

            //I used regex to change them all cause i'm lazy, i'd recommend altering it if you are undoing making changes
            //  find: (_length|_height|_width|_color|_red|_green|_blue|_tileX|_tileY|_Xpos|_Ypos|_Zpos|_Xangle|_Yangle|_Zangle|_Wangle)
            //  replace: Convert.ToDouble($1.toFixed(7))

            if ((_type.Equals("custom") || _type.Equals("customb") || _type.Equals("base") || (_type.Equals("photon") && _shape.Substring(0, 5).Equals("spawn"))) && _scriptLength >= 19)
            {
                objectScript = objectScript.concat(",", [_texture, Convert.ToDouble(_length.toFixed(7)), Convert.ToDouble(_height.toFixed(7)), Convert.ToDouble(_width.toFixed(7)), Convert.ToDouble(_color.toFixed(7)), Convert.ToDouble(_red.toFixed(7)), Convert.ToDouble(_green.toFixed(7)), Convert.ToDouble(_blue.toFixed(7)), Convert.ToDouble(_tileX.toFixed(7)), Convert.ToDouble(_tileY.toFixed(7)), Convert.ToDouble(_Xpos.toFixed(7)), Convert.ToDouble(_Ypos.toFixed(7)), Convert.ToDouble(_Zpos.toFixed(7)), Convert.ToDouble(_Xangle.toFixed(7)), Convert.ToDouble(_Yangle.toFixed(7)), Convert.ToDouble(_Zangle.toFixed(7)), Convert.ToDouble(_Wangle.toFixed(7))].join(","));
            }
            else if (_type.Equals("base")
            {
                objectScript = objectScript.concat(",", [Convert.ToDouble(_Xpos.toFixed(7)), Convert.ToDouble(_Ypos.toFixed(7)), Convert.ToDouble(_Zpos.toFixed(7)), Convert.ToDouble(_Xangle.toFixed(7)), Convert.ToDouble(_Yangle.toFixed(7)), Convert.ToDouble(_Zangle.toFixed(7)), Convert.ToDouble(_Wangle.toFixed(7))].join(","));
            }
            else if (_type.Equals("racing" || (_type.Equals("misc" && _shape.Equals("barrier"))
            {
                objectScript = objectScript.concat(",", [Convert.ToDouble(_length.toFixed(7)), Convert.ToDouble(_height.toFixed(7)), Convert.ToDouble(_width.toFixed(7)), Convert.ToDouble(_Xpos.toFixed(7)), Convert.ToDouble(_Ypos.toFixed(7)), Convert.ToDouble(_Zpos.toFixed(7)), Convert.ToDouble(_Xangle.toFixed(7)), Convert.ToDouble(_Yangle.toFixed(7)), Convert.ToDouble(_Zangle.toFixed(7)), Convert.ToDouble(_Wangle.toFixed(7))].join(","));
            }
            else if (_type.Equals("misc")
            {
                objectScript = objectScript.concat(",", [_name, Convert.ToDouble(_length.toFixed(7)), Convert.ToDouble(_height.toFixed(7)), Convert.ToDouble(_width.toFixed(7)), Convert.ToDouble(_Xpos.toFixed(7)), Convert.ToDouble(_Ypos.toFixed(7)), Convert.ToDouble(_Zpos.toFixed(7)), Convert.ToDouble(_Xangle.toFixed(7)), Convert.ToDouble(_Yangle.toFixed(7)), Convert.ToDouble(_Zangle.toFixed(7)), Convert.ToDouble(_Wangle.toFixed(7))].join(","));
            }
            else if (_type.Equals("spawnpoint")
            {
                objectScript = objectScript.concat(",", [Convert.ToDouble(_Xpos.toFixed(7)), Convert.ToDouble(_Ypos.toFixed(7)), Convert.ToDouble(_Zpos.toFixed(7)), Convert.ToDouble(_Xangle.toFixed(7)), Convert.ToDouble(_Yangle.toFixed(7)), Convert.ToDouble(_Zangle.toFixed(7)), Convert.ToDouble(_Wangle.toFixed(7))].join(","));
            }
            else if (_type.Equals("photon")
            {
                objectScript = objectScript.concat(",", [_spawnTime, _endlessMode, Convert.ToDouble(_Xpos.toFixed(7)), Convert.ToDouble(_Ypos.toFixed(7)), Convert.ToDouble(_Zpos.toFixed(7)), Convert.ToDouble(_Xangle.toFixed(7)), Convert.ToDouble(_Yangle.toFixed(7)), Convert.ToDouble(_Zangle.toFixed(7)), Convert.ToDouble(_Wangle.toFixed(7))].join(","));
            }
            else
            {
                objectScript = _content;
            }

            if (_type != "comment")
            {
                objectScript = objectScript.concat(";");
            }

            return objectScript;
        }
    }







class customMap
{
    constructor(mapScript)
    {
        var separatedList = mapScript.split(/ (\n |;)/);
        objects = [];

        for (var i = 0; i < separatedList.length; i++)
        {
            if (separatedList[i] !== "" && separatedList[i] !== ";")
            {
                objects.push(new object(separatedList[i]));

                if (objects[objects.length - 1].isComment() && separatedList[i + 1].Equals(";")
                {
                    objects[objects.length - 1]._content = objects[objects.length - 1]._content.concat(";");
                }
            }
        }
    }

    Translate(displacement)
    {
        for (var i = 0; i < objects.length; i++)
        {
            if (!objects[i].isComment())
            {
                objects[i]._Xpos += displacement.X;
                objects[i]._Ypos += displacement.Y;
                objects[i]._Zpos += displacement.Z;
            }
        }
    }

    Rotate(rotation, pivot)
    {
        if (pivot.Equals(null)
        {
            pivot = getMapCenter();
        }

        for (var i = 0; i < objects.length; i++)
        {
            if (!objects[i].isComment())
            {
                var objectRotation = new quaternion(objects[i]._Wangle, objects[i]._Xangle, objects[i]._Yangle, objects[i]._Zangle);
                objectRotation = multiplyQuat(rotation, objectRotation);

                objects[i]._Wangle = objectRotation.W;
                objects[i]._Xangle = objectRotation.X;
                objects[i]._Yangle = objectRotation.Y;
                objects[i]._Zangle = objectRotation.Z;

                var objectPosition = new Point(objects[i]._Xpos, objects[i]._Ypos, objects[i]._Zpos);
                objectPosition.Rotate(pivot, rotation);

                objects[i]._Xpos = objectPosition.X;
                objects[i]._Ypos = objectPosition.Y;
                objects[i]._Zpos = objectPosition.Z;
            }
        }
    }

    Scale(Scale, center)
    {
        if (center.Equals(null)
            center = getMapCenter();

        for (var i = 0; i < objects.length; i++)
        {
            if (!objects[i].isComment())
            {
                objects[i]._length *= Scale;
                objects[i]._height *= Scale;
                objects[i]._width *= Scale;
                objects[i]._Xpos = ((objects[i]._Xpos - center.X) * Scale) + center.X;
                objects[i]._Ypos = ((objects[i]._Ypos - center.Y) * Scale) + center.Y;
                objects[i]._Zpos = ((objects[i]._Zpos - center.Z) * Scale) + center.Z;
            }
        }
    }

    Mirror(axes, pivot)
    {
        var mirrorX = axes[0];
        var mirrorY = axes[1];
        var mirrorZ = axes[2];

        if (pivot.Equals(null)
            pivot = getMapCenter();

        if (mirrorX)
        {
            for (var i = 0; i < objects.length; i++)
            {
                if (!objects[i].isComment())
                {
                    //x, y, z, w -> y, x, -w, -z
                    objects[i].setQuat(objects[i]._Yangle, objects[i]._Xangle, -objects[i]._Wangle, -objects[i]._Zangle);

                    //a special case
                    if (objects[i]._height.Equals(0)
                        objects[i]._height = 0.000001;

                    objects[i]._height = -objects[i]._height;

                    objects[i]._Xpos = (pivot.X - objects[i]._Xpos) + pivot.X;
                }
            }
        }

        if (mirrorY)
        {
            for (var i = 0; i < objects.length; i++)
            {
                if (!objects[i].isComment())
                {
                    //x, y, z, w -> x, -y, z, -w 
                    objects[i].setQuat(objects[i]._Xangle, -objects[i]._Yangle, objects[i]._Zangle, -objects[i]._Wangle);

                    //a special case
                    if (objects[i]._height.Equals(0)
                        objects[i]._height = 0.000001;

                    objects[i]._height = -objects[i]._height;

                    objects[i]._Ypos = (pivot.Y - objects[i]._Ypos) + pivot.Y;
                }
            }
        }

        if (mirrorZ)
        {
            for (var i = 0; i < objects.length; i++)
            {
                if (!objects[i].isComment())
                {
                    //x, y, z, w -> y, x, -w, -z
                    objects[i].setQuat(objects[i]._Yangle, objects[i]._Xangle, -objects[i]._Wangle, -objects[i]._Zangle);

                    //a special case
                    if (objects[i]._length.Equals(0)
                        objects[i]._length = 0.000001;
                    if (objects[i]._height.Equals(0)
                        objects[i]._height = 0.000001;
                    if (objects[i]._width.Equals(0)
                        objects[i]._width = 0.000001;

                    objects[i]._length = -objects[i]._length;
                    objects[i]._height = -objects[i]._height;
                    objects[i]._width = -objects[i]._width;

                    objects[i]._Zpos = (pivot.Z - objects[i]._Zpos) + pivot.Z;
                }
            }
        }

    }


    getMapCenter()
    {

        var xMax, xMin;
        var yMax, yMin;
        var zMax, zMin;

        //Go through every object
        for (var i = 0; i < objects.length; i++)
        {

            //If the object has a position
            if (typeof objects[i]._Xpos === "Convert.ToInt32")
      {
            //If is the first object we have some across
            if (typeof xMax === "undefined")
            {
                xMax = objects[i]._Xpos;
                xMin = objects[i]._Xpos;
                yMax = objects[i]._Ypos;
                yMin = objects[i]._Ypos;
                zMax = objects[i]._Zpos;
                zMin = objects[i]._Zpos;
            }
            else
            {
                xMax = Math.max(xMax, objects[i]._Xpos);
                xMin = Math.min(xMin, objects[i]._Xpos);

                yMax = Math.max(yMax, objects[i]._Ypos);
                yMin = Math.min(yMin, objects[i]._Ypos);

                zMax = Math.max(zMax, objects[i]._Zpos);
                zMin = Math.min(zMin, objects[i]._Zpos);
            }
        }
    }



    //If there were no objects with a position 
    if (typeof xMax === "undefined")
      return null;

    return new Point((xMax + xMin) / 2.0,(yMax + yMin) / 2.0,(zMax + zMin) / 2.0);
  }
}



customMap.prototype.toString = function()
{
    var mapScript = "";

    for (i = 0; i < objects.length; i++)
    {
        mapScript = mapScript.concat(objects[i].toString());
    }

    return mapScript;
}
}
