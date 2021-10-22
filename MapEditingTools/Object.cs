using System;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace MapEditingTools
{
    public class Object
    {
        public string _type, _content, _shape, _texture, _name;
        public double _spawnTime;
        public int _endlessMode, _objectType, _scriptLength;
        public double _length, _height, _width;
        public int _color;
        public double _red, _green, _blue;
        public double _tileX, _tileY;
        public double _Xpos, _Ypos, _Zpos;
        public double _Xangle, _Yangle, _Zangle, _Wangle;

        public Object(string objectScript)
        {
            string[] elementList = objectScript.Split(',');

            _type = elementList[0];
            if (elementList.Length != 1) _shape = elementList[1];
            else _shape = "SOME TEST TEXT LMAO!!";

            _scriptLength = elementList.Length;

            if ((_type.Equals("custom") || _type.Equals("customb") || _type.Equals("base") || (_type.Equals("photon") && !_shape.Substring(0, 5).Equals("spawn"))) && _scriptLength >= 19)
            {
                _texture = elementList[2];
                _length = ToDouble(elementList[3]);
                _height = ToDouble(elementList[4]);
                _width = ToDouble(elementList[5]);
                _color = ToInt(elementList[6]);
                _red = ToDouble(elementList[7]);
                _green = ToDouble(elementList[8]);
                _blue = ToDouble(elementList[9]);
                _tileX = ToDouble(elementList[10]);
                _tileY = ToDouble(elementList[11]);
                _Xpos = ToDouble(elementList[12]);
                _Ypos = ToDouble(elementList[13]);
                _Zpos = ToDouble(elementList[14]);
                _Xangle = ToDouble(elementList[15]);
                _Yangle = ToDouble(elementList[16]);
                _Zangle = ToDouble(elementList[17]);
                _Wangle = ToDouble(elementList[18]);
                _objectType = 0;
            }
            else if (_type.Equals("base") && _scriptLength >= 9)
            {
                _Xpos = ToDouble(elementList[2]);
                _Ypos = ToDouble(elementList[3]);
                _Zpos = ToDouble(elementList[4]);
                _Xangle = ToDouble(elementList[5]);
                _Yangle = ToDouble(elementList[6]);
                _Zangle = ToDouble(elementList[7]);
                _Wangle = ToDouble(elementList[8]);
                _objectType = 1;
            }
            else if (_type.Equals("racing") || _type.Equals("misc") && _shape.Equals("barrier") && _scriptLength >= 12)
            {
                _length = ToDouble(elementList[2]);
                _height = ToDouble(elementList[3]);
                _width = ToDouble(elementList[4]);
                _Xpos = ToDouble(elementList[5]);
                _Ypos = ToDouble(elementList[6]);
                _Zpos = ToDouble(elementList[7]);
                _Xangle = ToDouble(elementList[8]);
                _Yangle = ToDouble(elementList[9]);
                _Zangle = ToDouble(elementList[10]);
                _Wangle = ToDouble(elementList[11]);
                _objectType = 2;
            }
            else if (_type.Equals("misc") && _scriptLength >= 13)
            {
                _name = elementList[2];
                _length = ToDouble(elementList[3]);
                _height = ToDouble(elementList[4]);
                _width = ToDouble(elementList[5]);
                _Xpos = ToDouble(elementList[6]);
                _Ypos = ToDouble(elementList[7]);
                _Zpos = ToDouble(elementList[8]);
                _Xangle = ToDouble(elementList[9]);
                _Yangle = ToDouble(elementList[10]);
                _Zangle = ToDouble(elementList[11]);
                _Wangle = ToDouble(elementList[12]);
                _objectType = 3;
            }
            else if (_type.Equals("spawnpoint") && _scriptLength >= 9)
            {
                _Xpos = ToDouble(elementList[2]);
                _Ypos = ToDouble(elementList[3]);
                _Zpos = ToDouble(elementList[4]);
                _Xangle = ToDouble(elementList[5]);
                _Yangle = ToDouble(elementList[6]);
                _Zangle = ToDouble(elementList[7]);
                _Wangle = ToDouble(elementList[8]);
                _objectType = 4;
            }
            else if (_type.Equals("photon") && _scriptLength >= 11)
            {
                _spawnTime = ToDouble(elementList[2]);
                _endlessMode = ToInt(elementList[3]);
                _Xpos = ToDouble(elementList[4]);
                _Ypos = ToDouble(elementList[5]);
                _Zpos = ToDouble(elementList[6]);
                _Xangle = ToDouble(elementList[7]);
                _Yangle = ToDouble(elementList[8]);
                _Zangle = ToDouble(elementList[9]);
                _Wangle = ToDouble(elementList[10]);
                _objectType = 5;
            }
            else
            {
                _type = "comment";
                _content = objectScript;
                _shape = null;
            }
        }
        public double ToDouble(string value)
        {
            return Convert.ToDouble(value);
        }
        public int ToInt(string value)
        {
            return Convert.ToInt32(value);
        }
        //class functions \o/
        public bool IsComment()
        {
            return _objectType == 6;
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
            string objectScript;

            if (_objectType == 0)
            {
                objectScript =
                    _type + "," +
                    _shape + "," +
                    _texture + "," +
                    _length.ToFixed(7) + "," +
                    _height.ToFixed(7) + "," +
                    _width.ToFixed(7) + "," +
                    _color.ToString() + "," +
                    _red.ToFixed(7) + "," +
                    _green.ToFixed(7) + "," +
                    _blue.ToFixed(7) + "," +
                    _tileX.ToFixed(7) + "," +
                    _tileY.ToFixed(7) + "," +
                    _Xpos.ToFixed(7) + "," +
                    _Ypos.ToFixed(7) + "," +
                    _Zpos.ToFixed(7) + "," +
                    _Xangle.ToFixed(7) + "," +
                    _Yangle.ToFixed(7) + "," +
                    _Zangle.ToFixed(7) + "," +
                    _Wangle.ToFixed(7);
            }
            else if (_objectType == 1)
            {
                objectScript =
                    _type + "," +
                    _shape + "," +
                    _Xpos.ToFixed(7) + "," +
                    _Ypos.ToFixed(7) + "," +
                    _Zpos.ToFixed(7) + "," +
                    _Xangle.ToFixed(7) + "," +
                    _Yangle.ToFixed(7) + "," +
                    _Zangle.ToFixed(7) + "," +
                   _Wangle.ToFixed(7);
            }
            else if (_objectType == 2)
            {
                objectScript =
                    _type + "," +
                    _shape + "," +
                    _length.ToFixed(7) + "," +
                    _height.ToFixed(7) + "," +
                    _width.ToFixed(7) + "," +
                    _Xpos.ToFixed(7) + "," +
                    _Ypos.ToFixed(7) + "," +
                    _Zpos.ToFixed(7) + "," +
                    _Xangle.ToFixed(7) + "," +
                    _Yangle.ToFixed(7) + "," +
                    _Zangle.ToFixed(7) + "," +
                    _Wangle.ToFixed(7);
            }
            else if (_objectType == 3)
            {
                objectScript =
                    _type + "," +
                    _shape + "," +
                    _name + "," +
                    _length.ToFixed(7) + "," +
                    _height.ToFixed(7) + "," +
                    _width.ToFixed(7) + "," +
                    _Xpos.ToFixed(7) + "," +
                    _Ypos.ToFixed(7) + "," +
                    _Zpos.ToFixed(7) + "," +
                    _Xangle.ToFixed(7) + "," +
                    _Yangle.ToFixed(7) + "," +
                    _Zangle.ToFixed(7) + "," +
                    _Wangle.ToFixed(7);
            }
            else if (_objectType == 4)
            {
                objectScript =
                    _type + "," +
                    _shape + "," +
                    _Xpos.ToFixed(7) + "," +
                    _Ypos.ToFixed(7) + "," +
                    _Zpos.ToFixed(7) + "," +
                    _Xangle.ToFixed(7) + "," +
                    _Yangle.ToFixed(7) + "," +
                    _Zangle.ToFixed(7) + "," +
                    _Wangle.ToFixed(7);
            }
            else if (_objectType == 5)
            {
                objectScript =
                    _type + "," +
                    _shape + "," +
                    _spawnTime + "," +
                    _endlessMode + "," +
                    _Xpos.ToFixed(7) + "," +
                    _Ypos.ToFixed(7) + "," +
                    _Zpos.ToFixed(7) + "," +
                    _Xangle.ToFixed(7) + "," +
                    _Yangle.ToFixed(7) + "," +
                    _Zangle.ToFixed(7) + "," +
                    _Wangle.ToFixed(7);
            }
            else
            {
                objectScript = _content;
            }

            if (!_type.Equals("comment"))
            {
                objectScript += ";";
            }

            return objectScript;
        }

    }
    public static class MyExtensionMethods
    {
        public static string ToFixed(this double number, uint decimals)
        {
            return number.ToString("N" + decimals);
        }
        public static string ToFixed(this double number, int decimals)
        {
            return number.ToString("N" + decimals);
        }
    }







    public class CustomMap
    {
        List<Object> objects = new List<Object>();
        public CustomMap(string mapScript)
        {
            string[] separatedList = Regex.Split(mapScript.Replace("\r", ""), "(\n)|(;)");

            for (int i = 0; i < separatedList.Length; i++)
            {
                if (!separatedList[i].Equals("") && !separatedList[i].Equals(";"))
                {
                    objects.Add(new Object(separatedList[i]));

                    if (objects[objects.Count() - 1].IsComment() && separatedList[i + 1].Equals(";"))
                    {
                        objects[objects.Count() - 1]._content = objects[objects.Count() - 1] + ";";
                    }
                }
            }
        }
        public override string ToString()
        {
            string mapScript = "";

            for (int i = 0; i < objects.Count(); i++)
            {
                mapScript += objects[i].ToString();
            }

            return mapScript;
        }

        public void Translate(Point displacement)
        {
            for (int i = 0; i < objects.Count(); i++)
            {
                if (objects[i] != null)
                {
                    if (!objects[i].IsComment())
                    {
                        objects[i]._Xpos += displacement.X;
                        objects[i]._Ypos += displacement.Y;
                        objects[i]._Zpos += displacement.Z;
                    }
                }
            }
        }
        public void Rotate(Quaternion rotation, Point pivot)
        {
            for (var i = 0; i < objects.Count(); i++)
            {
                if (!objects[i].IsComment())
                {
                    var objectRotation = new Quaternion(objects[i]._Wangle, objects[i]._Xangle, objects[i]._Yangle, objects[i]._Zangle);
                    objectRotation = Quaternion.MultiplyQuat(rotation, objectRotation);

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

        public void Rotate(Quaternion rotation)
        {
            Point pivot = GetMapCenter();

            for (var i = 0; i < objects.Count(); i++)
            {
                if (!objects[i].IsComment())
                {
                    var objectRotation = new Quaternion(objects[i]._Wangle, objects[i]._Xangle, objects[i]._Yangle, objects[i]._Zangle);
                    objectRotation = Quaternion.MultiplyQuat(rotation, objectRotation);

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

        //Scale is not working for some reason :/
        public void Scale(double Scale, Point center)
        {
            for (var i = 0; i < objects.Count(); i++)
            {
                if (!objects[i].IsComment())
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
        public void Scale(double Scale)
        {
            Point center = GetMapCenter();

            for (var i = 0; i < objects.Count(); i++)
            {
                if (!objects[i].IsComment())
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

        public void Mirror(bool[] axes, Point pivot)
        {
            var mirrorX = axes[0];
            var mirrorY = axes[1];
            var mirrorZ = axes[2];

            if (mirrorX)
            {
                for (var i = 0; i < objects.Count(); i++)
                {
                    if (!objects[i].IsComment())
                    {
                        //x, y, z, w -> y, x, -w, -z
                        objects[i].SetQuat(objects[i]._Yangle, objects[i]._Xangle, -objects[i]._Wangle, -objects[i]._Zangle);

                        //a special case
                        if (objects[i]._height.Equals(0))
                            objects[i]._height = 0.000001;

                        objects[i]._height = -objects[i]._height;

                        objects[i]._Xpos = (pivot.X - objects[i]._Xpos) + pivot.X;
                    }
                }
            }

            if (mirrorY)
            {
                for (var i = 0; i < objects.Count(); i++)
                {
                    if (!objects[i].IsComment())
                    {
                        //x, y, z, w -> x, -y, z, -w 
                        objects[i].SetQuat(objects[i]._Xangle, -objects[i]._Yangle, objects[i]._Zangle, -objects[i]._Wangle);

                        //a special case
                        if (objects[i]._height.Equals(0))
                            objects[i]._height = 0.000001;

                        objects[i]._height = -objects[i]._height;

                        objects[i]._Ypos = (pivot.Y - objects[i]._Ypos) + pivot.Y;
                    }
                }
            }

            if (mirrorZ)
            {
                for (var i = 0; i < objects.Count(); i++)
                {
                    if (!objects[i].IsComment())
                    {
                        //x, y, z, w -> y, x, -w, -z
                        objects[i].SetQuat(objects[i]._Yangle, objects[i]._Xangle, -objects[i]._Wangle, -objects[i]._Zangle);

                        //a special case
                        if (objects[i]._length.Equals(0))
                            objects[i]._length = 0.000001;
                        if (objects[i]._height.Equals(0))
                            objects[i]._height = 0.000001;
                        if (objects[i]._width.Equals(0))
                            objects[i]._width = 0.000001;

                        objects[i]._length = -objects[i]._length;
                        objects[i]._height = -objects[i]._height;
                        objects[i]._width = -objects[i]._width;

                        objects[i]._Zpos = (pivot.Z - objects[i]._Zpos) + pivot.Z;
                    }
                }
            }

        }
        public void Mirror(bool[] axes)
        {
            bool mirrorX = axes[0];
            bool mirrorY = axes[1];
            bool mirrorZ = axes[2];

            Point pivot = GetMapCenter();

            if (mirrorX)
            {
                for (var i = 0; i < objects.Count(); i++)
                {
                    if (!objects[i].IsComment())
                    {
                        //x, y, z, w -> y, x, -w, -z
                        objects[i].SetQuat(objects[i]._Yangle, objects[i]._Xangle, -objects[i]._Wangle, -objects[i]._Zangle);

                        //a special case
                        if (objects[i]._height.Equals(0))
                            objects[i]._height = 0.000001;

                        objects[i]._height = -objects[i]._height;

                        objects[i]._Xpos = (pivot.X - objects[i]._Xpos) + pivot.X;
                    }
                }
            }

            if (mirrorY)
            {
                for (var i = 0; i < objects.Count(); i++)
                {
                    if (!objects[i].IsComment())
                    {
                        //x, y, z, w -> x, -y, z, -w 
                        objects[i].SetQuat(objects[i]._Xangle, -objects[i]._Yangle, objects[i]._Zangle, -objects[i]._Wangle);

                        //a special case
                        if (objects[i]._height.Equals(0))
                            objects[i]._height = 0.000001;

                        objects[i]._height = -objects[i]._height;

                        objects[i]._Ypos = (pivot.Y - objects[i]._Ypos) + pivot.Y;
                    }
                }
            }

            if (mirrorZ)
            {
                for (var i = 0; i < objects.Count(); i++)
                {
                    if (!objects[i].IsComment())
                    {
                        //x, y, z, w -> y, x, -w, -z
                        objects[i].SetQuat(objects[i]._Yangle, objects[i]._Xangle, -objects[i]._Wangle, -objects[i]._Zangle);

                        //a special case
                        if (objects[i]._length.Equals(0))
                            objects[i]._length = 0.000001;
                        if (objects[i]._height.Equals(0))
                            objects[i]._height = 0.000001;
                        if (objects[i]._width.Equals(0))
                            objects[i]._width = 0.000001;

                        objects[i]._length = -objects[i]._length;
                        objects[i]._height = -objects[i]._height;
                        objects[i]._width = -objects[i]._width;

                        objects[i]._Zpos = (pivot.Z - objects[i]._Zpos) + pivot.Z;
                    }
                }
            }

        }


        public Point GetMapCenter()
        {
            double xMax = 0; double yMax = 0; double zMax = 0;
            double xMin = 0; double yMin = 0; double zMin = 0;

            //Go through every object
            for (int i = 0; i < objects.Count(); i++)
            {
                if (!objects[i].IsComment())
                {
                    xMax = objects[i]._Xpos; yMax = objects[i]._Ypos; zMax = objects[i]._Zpos;
                    xMin = objects[i]._Xpos; yMin = objects[i]._Ypos; zMin = objects[i]._Zpos;

                    xMax = Math.Max(xMax, objects[i]._Xpos);
                    xMin = Math.Min(xMin, objects[i]._Xpos);

                    yMax = Math.Max(yMax, objects[i]._Ypos);
                    yMin = Math.Min(yMin, objects[i]._Ypos);

                    zMax = Math.Max(zMax, objects[i]._Zpos);
                    zMin = Math.Min(zMin, objects[i]._Zpos);
                }
            }

            return new Point((xMax + xMin) / 2f, (yMax + yMin) / 2f, (zMax + zMin) / 2f);
        }

    }
}




