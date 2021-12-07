using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    /// <summary>
    /// 3 dimenziós vektor homogén koordinátákkal
    /// </summary>
    public class Vector4
    {
        public double x, y, z, w;

        public Vector4()
        {
            this.x = 0.0; this.y = 0.0; this.z = 0.0; this.w = 1.0;
        }
        public Vector4(double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z; this.w = 1.0;
        }
        public Vector4(double x, double y, double z, double w)
        {
            this.x = x; this.y = y; this.z = z; this.w = w;
        }
        public Vector4(Vector4 v)
        {
            this.x = v.x; this.y = v.y; this.z = v.z; this.w = v.w;
        }

        public static Vector4 operator +(Vector4 v0, Vector4 v1)
        {
            return new Vector4(v0.x + v1.x, v0.y + v1.y, v0.z + v1.z, 1.0);
        }
        public static Vector4 operator -(Vector4 v0, Vector4 v1)
        {
            return new Vector4(v0.x - v1.x, v0.y - v1.y, v0.z - v1.z, 1.0);
        }
        public static Vector4 operator *(Vector4 v0, double l)
        {
            return new Vector4(v0.x * l, v0.y * l, v0.z * l, 1.0);
        }
        public static Vector4 operator *(double l, Vector4 v0)
        {
            return new Vector4(v0.x * l, v0.y * l, v0.z * l, 1.0);
        }

        public static Vector4 operator +(Vector4 v0, Vector2 v1)
        {
            return new Vector4(v0.x + v1.x, v0.y + v1.y, v0.z, 1.0);
        }
        public static Vector4 operator +(Vector2 v0, Vector4 v1)
        {
            return new Vector4(v0.x + v1.x, v0.y + v1.y, v1.z, 1.0);
        }

        public static implicit operator Vector2(Vector4 v)
        {
            return new Vector2(v.x, v.y);
        }
    }
}
