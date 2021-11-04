using GrafikaDLL.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class HermiteArc
    {
        public Vector2 p0, p1, t0, t1;
        public double weight;

        public HermiteArc(double weight)
        {
            this.weight = weight;
            p0 = new Vector2(0.0, 0.0);
            p1 = new Vector2(0.0, 0.0);
            t0 = new Vector2(0.0, 0.0);
            t1 = new Vector2(0.0, 0.0);
        }
        public HermiteArc(Vector2 p0, Vector2 p1, Vector2 t0, Vector2 t1, double weight)
        {
            this.weight = weight;
            this.p0 = new Vector2(p0.x, p0.y);
            this.p1 = new Vector2(p1.x, p1.y);
            this.t0 = new Vector2(t0.x, t0.y);
            this.t1 = new Vector2(t1.x, t1.y);
        }
    }
}
