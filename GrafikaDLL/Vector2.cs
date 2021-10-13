using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL.Extensions
{
    public struct Vector2
    {
        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        public double x, y;

        public static Vector2 operator +(Vector2 a, Vector2 b) { return new Vector2(a.x + b.x, a.y + b.y); }

        public static Vector2 operator -(Vector2 a, Vector2 b) { return new Vector2(a.x - b.x, a.y - b.y); }

        public static Vector2 operator *(Vector2 a, double l) { return new Vector2(a.x * l, a.y * l); }

        public static Vector2 operator *(double l, Vector2 a) { return new Vector2(a.x *l, a.y *l); }

        public override string ToString()
        {
            return string.Format("({0:0.00};{1:0.00})", x, y);
        }
    }
}
