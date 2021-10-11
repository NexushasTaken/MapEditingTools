
namespace MapEditingTools
{
    public class PointsM
    {
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
