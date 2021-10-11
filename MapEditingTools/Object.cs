using System;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace MapEditingTools
{
    public class Object
    {
        public string _type;
        public string _content;
        public string _shape;
        public int _scriptLength;
        public string _texture;
        public string _name;
        public double _length;
        public double _height;
        public double _width;
        public int _color;
        public double _red;
        public double _green;
        public double _blue;
        public double _tileX;
        public double _tileY;
        public double _Xpos;
        public double _Ypos;
        public double _Zpos;
        public double _Xangle;
        public double _Yangle;
        public double _Zangle;
        public double _Wangle;
        public double _spawnTime;
        public int _endlessMode;
        public int _objectType;

        public Object(string objectScript)
        {
            string[] elementList = objectScript.Split(',');

            _type = elementList[0];
            if (elementList.Length != 1)
            {
                _shape = elementList[1];
            }
            else
            {
                _shape = "SOME TEST TEXT LMAO!!";
            }
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
                _objectType = 1;
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
                _objectType = 2;
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
                _objectType = 3;
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
                _objectType = 4;
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
                _objectType = 5;
            }
            else
            {
                _type = "comment";
                _content = objectScript;
                _shape = null;
                _objectType = 6;
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
            string objectScript;

            if ((_type.Equals("custom") || _type.Equals("customb") || _type.Equals("base") || (_type.Equals("photon") && _shape.Substring(0, 5).Equals("spawn"))) && _scriptLength >= 19)
            {
                objectScript =
                    _type + "," + 
                    _shape + "," +
                    _texture + "," +
                    _length.toFixed(7) + "," +
                    _height.toFixed(7) + "," +
                    _width.toFixed(7) +"," +
                    _color.ToString() + "," +
                    _red.toFixed(7) + "," +
                    _green.toFixed(7) + "," +
                    _blue.toFixed(7) + "," +
                    _tileX.toFixed(7) + "," +
                    _tileY.toFixed(7) + "," +
                    _Xpos.toFixed(7) + "," +
                    _Ypos.toFixed(7) + "," +
                    _Zpos.toFixed(7) + "," +
                    _Xangle.toFixed(7) + "," +
                    _Yangle.toFixed(7) + "," +
                    _Zangle.toFixed(7) + "," +
                    _Wangle.toFixed(7);
            }
            else if (_type.Equals("base"))
            {
                objectScript =
                    _type + "," +
                    _shape + "," +
                    _Xpos.toFixed(7) + "," +
                    _Ypos.toFixed(7) + "," +
                    _Zpos.toFixed(7) + "," +
                    _Xangle.toFixed(7) + "," +
                    _Yangle.toFixed(7) + "," +
                    _Zangle.toFixed(7) + "," +
                   _Wangle.toFixed(7);
            }
            else if (_type.Equals("racing") || (_type.Equals("misc") && _shape.Equals("barrier")))
            {
                objectScript =
                    _type + "," +
                    _shape + "," +
                    _length.toFixed(7) + "," +
                    _height.toFixed(7) + "," +
                    _width.toFixed(7) + "," +
                    _Xpos.toFixed(7) + "," +
                    _Ypos.toFixed(7) + "," +
                    _Zpos.toFixed(7) + "," +
                    _Xangle.toFixed(7) + "," +
                    _Yangle.toFixed(7) + "," +
                    _Zangle.toFixed(7) + "," +
                    _Wangle.toFixed(7);
            }
            else if (_type.Equals("misc"))
            {
                objectScript =
                    _type + "," +
                    _shape + "," +
                    _name + "," +
                    _length.toFixed(7) + "," +
                    _height.toFixed(7) + "," +
                    _width.toFixed(7) + "," +
                    _Xpos.toFixed(7) + "," +
                    _Ypos.toFixed(7) + "," +
                    _Zpos.toFixed(7) + "," +
                    _Xangle.toFixed(7) + "," +
                    _Yangle.toFixed(7) + "," +
                    _Zangle.toFixed(7) + "," +
                    _Wangle.toFixed(7);
            }
            else if (_type.Equals("spawnpoint"))
            {
                objectScript =
                    _type + "," +
                    _shape + "," +
                    _Xpos.toFixed(7) + "," +
                    _Ypos.toFixed(7) + "," +
                    _Zpos.toFixed(7) + "," +
                    _Xangle.toFixed(7) + "," +
                    _Yangle.toFixed(7) + "," +
                    _Zangle.toFixed(7) + "," +
                    _Wangle.toFixed(7);
            }
            else if (_type.Equals("photon"))
            {
                objectScript =
                    _type + "," +
                    _shape + "," +
                    _spawnTime + "," +
                    _endlessMode + "," +
                    _Xpos.toFixed(7) + "," +
                    _Ypos.toFixed(7) + "," +
                    _Zpos.toFixed(7) + "," +
                    _Xangle.toFixed(7) + "," +
                    _Yangle.toFixed(7) + "," +
                    _Zangle.toFixed(7) + "," +
                    _Wangle.toFixed(7);
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
        public static string toFixed(this double number, uint decimals)
        {
            return number.ToString("N" + decimals);
        }
        public static string toFixed(this double number, int decimals)
        {
            return number.ToString("N" + decimals);
        }
    }







    public class CustomMap
    {
        List<Object> objects = new List<Object>();
        public CustomMap(string mapScript)
        {
            mapScript = mapScript.Replace("\r", "");
            string[] separatedList = Regex.Split(mapScript, "(\n)|(;)");

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
            //if (pivot.Equals(null))
            //{
            //    pivot = getMapCenter();
            //}

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
            Point pivot = getMapCenter();

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

        public Point getMapCenter()
        {
            double xMax = 0;
            double xMin = 0;
            double yMax = 0;
            double yMin = 0;
            double zMax = 0;
            double zMin = 0;

            //Go through every object
            for (int i = 0; i < objects.Count(); i++)
            {
                xMax = objects[i]._Xpos;
                xMin = objects[i]._Xpos;
                yMax = objects[i]._Ypos;
                yMin = objects[i]._Ypos;
                zMax = objects[i]._Zpos;
                zMin = objects[i]._Zpos;
                xMax = Math.Max(xMax, objects[i]._Xpos);
                xMin = Math.Min(xMin, objects[i]._Xpos);

                yMax = Math.Max(yMax, objects[i]._Ypos);
                yMin = Math.Min(yMin, objects[i]._Ypos);

                zMax = Math.Max(zMax, objects[i]._Zpos);
                zMin = Math.Min(zMin, objects[i]._Zpos);
            }
            //If there were no objects with a position 
            //if (xMax == null) return null;

            return new Point((xMax + xMin) / 2.0, (yMax + yMin) / 2.0, (zMax + zMin) / 2.0);
        }
    }



        //Scale(Scale, center)
        //{
        //    if (center.Equals(null)
        //        center = getMapCenter();

        //    for (var i = 0; i < objects.length; i++)
        //    {
        //        if (!objects[i].isComment())
        //        {
        //            objects[i]._length *= Scale;
        //            objects[i]._height *= Scale;
        //            objects[i]._width *= Scale;
        //            objects[i]._Xpos = ((objects[i]._Xpos - center.X) * Scale) + center.X;
        //            objects[i]._Ypos = ((objects[i]._Ypos - center.Y) * Scale) + center.Y;
        //            objects[i]._Zpos = ((objects[i]._Zpos - center.Z) * Scale) + center.Z;
        //        }
        //    }
        //}

        //Mirror(axes, pivot)
        //{
        //    var mirrorX = axes[0];
        //    var mirrorY = axes[1];
        //    var mirrorZ = axes[2];

        //    if (pivot.Equals(null)
        //        pivot = getMapCenter();

        //    if (mirrorX)
        //    {
        //        for (var i = 0; i < objects.length; i++)
        //        {
        //            if (!objects[i].isComment())
        //            {
        //                //x, y, z, w -> y, x, -w, -z
        //                objects[i].setQuat(objects[i]._Yangle, objects[i]._Xangle, -objects[i]._Wangle, -objects[i]._Zangle);

        //                //a special case
        //                if (objects[i]._height.Equals(0)
        //                    objects[i]._height = 0.000001;

        //                objects[i]._height = -objects[i]._height;

        //                objects[i]._Xpos = (pivot.X - objects[i]._Xpos) + pivot.X;
        //            }
        //        }
        //    }

        //    if (mirrorY)
        //    {
        //        for (var i = 0; i < objects.length; i++)
        //        {
        //            if (!objects[i].isComment())
        //            {
        //                //x, y, z, w -> x, -y, z, -w 
        //                objects[i].setQuat(objects[i]._Xangle, -objects[i]._Yangle, objects[i]._Zangle, -objects[i]._Wangle);

        //                //a special case
        //                if (objects[i]._height.Equals(0)
        //                    objects[i]._height = 0.000001;

        //                objects[i]._height = -objects[i]._height;

        //                objects[i]._Ypos = (pivot.Y - objects[i]._Ypos) + pivot.Y;
        //            }
        //        }
        //    }

        //    if (mirrorZ)
        //    {
        //        for (var i = 0; i < objects.length; i++)
        //        {
        //            if (!objects[i].isComment())
        //            {
        //                //x, y, z, w -> y, x, -w, -z
        //                objects[i].setQuat(objects[i]._Yangle, objects[i]._Xangle, -objects[i]._Wangle, -objects[i]._Zangle);

        //                //a special case
        //                if (objects[i]._length.Equals(0)
        //                    objects[i]._length = 0.000001;
        //                if (objects[i]._height.Equals(0)
        //                    objects[i]._height = 0.000001;
        //                if (objects[i]._width.Equals(0)
        //                    objects[i]._width = 0.000001;

        //                objects[i]._length = -objects[i]._length;
        //                objects[i]._height = -objects[i]._height;
        //                objects[i]._width = -objects[i]._width;

        //                objects[i]._Zpos = (pivot.Z - objects[i]._Zpos) + pivot.Z;
        //            }
        //        }
        //    }

        //}







    }




