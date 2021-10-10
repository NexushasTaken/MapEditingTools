using System;

namespace MapEditingTools
{
    public class QuaternionMethods
    {
        public static double ToRadians(double angle)
        {
            return angle % 360 * (Math.PI / 180);
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
    }
}