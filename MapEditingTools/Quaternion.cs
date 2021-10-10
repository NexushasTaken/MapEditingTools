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
            double cosx = Math.Cos(QuaternionMethods.ToRadians(x * 0.5));
            double cosy = Math.Cos(QuaternionMethods.ToRadians(y * 0.5));
            double cosz = Math.Cos(QuaternionMethods.ToRadians(z * 0.5));
            double sinx = Math.Sin(QuaternionMethods.ToRadians(x * 0.5));
            double siny = Math.Sin(QuaternionMethods.ToRadians(y * 0.5));
            double sinz = Math.Sin(QuaternionMethods.ToRadians(z * 0.5));

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
    }
}
