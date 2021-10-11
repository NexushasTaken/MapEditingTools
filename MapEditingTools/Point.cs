using System;

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
            Point tempPosition = PointSubtract(this, pivot);
            Point quatImaginary = new Point(rotation.X, rotation.Y, rotation.Z);

            Point vector1 = new Point(quatImaginary);
            vector1.ScalarMultiply(2 * Dot(quatImaginary, tempPosition));

            Point vector2 = new Point(tempPosition);
            vector2.ScalarMultiply(Math.Pow(rotation.W, 2) - Dot(quatImaginary, quatImaginary));

            Point vector3 = Cross(quatImaginary, tempPosition);
            vector3.ScalarMultiply(2 * rotation.W);

            X = vector1.X + vector2.X + vector3.X + pivot.X;
            Y = vector1.Y + vector2.Y + vector3.Y + pivot.Y;
            Z = vector1.Z + vector2.Z + vector3.Z + pivot.Z;
        }
        public static Point PointAdd(Point point1, Point point2)
        {
            Point addedPoint = new Point
            {
                X = point1.X + point2.X,
                Y = point1.Y + point2.Y,
                Z = point1.Z + point2.Z
            };

            return addedPoint;
        }

        public static Point PointSubtract(Point point1, Point point2)
        {
            Point subtractedPoint = new Point
            {
                X = point1.X - point2.X,
                Y = point1.Y - point2.Y,
                Z = point1.Z - point2.Z
            };

            return subtractedPoint;
        }

        public static double Dot(Point vector1, Point vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
        }

        public static Point Cross(Point vector1, Point vector2)
        {
            Point crossProduct = new Point
            {
                X = vector1.Y * vector2.Z - vector1.Z * vector2.Y,
                Y = vector1.Z * vector2.X - vector1.X * vector2.Z,
                Z = vector1.X * vector2.Y - vector1.Y * vector2.X
            };

            return crossProduct;
        }
    }
}
