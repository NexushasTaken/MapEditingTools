﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditingTools
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        public Point(Point _value)
        {
            X = _value.X;
            Y = _value.Y;
            Z = _value.Z;
        }
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void ScalarAdd(double scalar)
        {
            X += scalar;
            Y += scalar;
            Z += scalar;
        }

        public void ScalarMultiply(double scalar)
        {
            X *= scalar;
            Y *= scalar;
            Z *= scalar;
        }

        public void Rotate(Point pivot, Quaternion rotation)
        {
            Point tempPosition = PointsM.PointSubtract(this, pivot);
            Point quatImaginary = new Point(rotation.X, rotation.Y, rotation.Z);

            Point vector1 = new Point(quatImaginary);
            vector1.ScalarMultiply(2 * PointsM.Dot(quatImaginary, tempPosition));

            Point vector2 = new Point(tempPosition);
            vector2.ScalarMultiply(Math.Pow(rotation.W, 2) - PointsM.Dot(quatImaginary, quatImaginary));

            Point vector3 = PointsM.Cross(quatImaginary, tempPosition);
            vector3.ScalarMultiply(2 * rotation.W);

            X = vector1.X + vector2.X + vector3.X + pivot.X;
            Y = vector1.Y + vector2.Y + vector3.Y + pivot.Y;
            Z = vector1.Z + vector2.Z + vector3.Z + pivot.Z;
        }
    }
}
