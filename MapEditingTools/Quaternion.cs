using System;

namespace MapEditingTools
{
    public class Quaternion
    {
        public double W { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Quaternion()
        {
            W = 1;
            X = 0;
            Y = 0;
            Z = 0;
        }
        public Quaternion(double x, double y, double z)
        {
            double cosx = Math.Cos(ToRadians(x));
            double cosy = Math.Cos(ToRadians(y));
            double cosz = Math.Cos(ToRadians(z));
            double sinx = Math.Sin(ToRadians(x));
            double siny = Math.Sin(ToRadians(y));
            double sinz = Math.Sin(ToRadians(z));

            W = cosx * cosy * cosz - sinx * siny * sinz;
            X = sinx * cosy * cosz + cosx * siny * sinz;
            Y = siny * cosx * cosz - sinx * sinz * cosy;
            Z = cosx * cosy * sinz + sinx * siny * cosz;
        }
        public Quaternion(double w, double x, double y, double z)
        {
            if (w == 0 && x == 0 && y == 0 && z == 0)
            {
                W = 1;
                X = 0;
                Y = 0;
                Z = 0;
            }
            else
            {
                double magnitude = Math.Sqrt(Math.Pow(w, 2) + Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));

                W /= magnitude;
                X /= magnitude;
                Y /= magnitude;
                Z /= magnitude;
            }
        }
        public static Quaternion MultiplyQuat(Quaternion quat1, Quaternion quat2)
        {
            Quaternion multipliedQuat = new Quaternion
            {
                W = -quat1.X * quat2.X - quat1.Y * quat2.Y - quat1.Z * quat2.Z + quat1.W * quat2.W,
                X = quat1.X * quat2.W + quat1.Y * quat2.Z - quat1.Z * quat2.Y + quat1.W * quat2.X,
                Y = -quat1.X * quat2.Z + quat1.Y * quat2.W + quat1.Z * quat2.X + quat1.W * quat2.Y,
                Z = quat1.X * quat2.Y - quat1.Y * quat2.X + quat1.Z * quat2.W + quat1.W * quat2.Z
            };

            return multipliedQuat;
        }
        public double ToRadians(double angle)
        {
            return (Math.PI / 180) *
                   (angle * 0.5); //Some Additional :D
        }
    }
}
