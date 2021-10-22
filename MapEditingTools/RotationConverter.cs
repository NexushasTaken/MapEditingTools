using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditingTools
{
    class RotationConverter
    {
		double heading, attitude, bank;

        public RotationConverter(Quat4d q1)
		{
			double test = q1.x * q1.y + q1.z * q1.w;
			if (test > 0.499)
			{ // singularity at north pole
				heading = 2 * Math.Atan2(q1.x, q1.w);
				attitude = Math.PI / 2;
				bank = 0;
				return;
			}
			if (test < -0.499)
			{ // singularity at south pole
				heading = -2 * Math.Atan2(q1.x, q1.w);
				attitude = -Math.PI / 2;
				bank = 0;
				return;
			}
			double sqx = q1.x * q1.x;
			double sqy = q1.y * q1.y;
			double sqz = q1.z * q1.z;
			heading = Math.Atan2(2 * q1.y * q1.w - 2 * q1.x * q1.z, 1 - 2 * sqy - 2 * sqz);
			attitude = Math.Asin(2 * test);
			bank = Math.Atan2(2 * q1.x * q1.w - 2 * q1.y * q1.z, 1 - 2 * sqx - 2 * sqz);
		}
	}

    public class Quat4d
	{
		public int w, x, y, z;

        public Quat4d(int w, int x, int y, int z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
