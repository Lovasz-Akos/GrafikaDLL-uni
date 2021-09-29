using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class Line
    {
        public Line()
        {
            p0 = new PointF(0f, 0f);
            p1 = new PointF(0f, 0f);
        }
        public Line(float x0, float y0, float x1, float y1)
        {
            p0 = new PointF(x0, y0);
            p1 = new PointF(x1, y1);
        }
        public Line(PointF p0, PointF p1)
            : this(p0.X, p0.Y, p1.X, p1.Y)
        { }

        public PointF p0, p1;

        public int Sign(PointF p)
        {
            throw new NotImplementedException();
        }
        public bool IsParallelTo(Line line)
        {
            throw new NotImplementedException();
        }
        public PointF Intersection(Line line)
        {
            throw new NotImplementedException();
        }
    }
}
