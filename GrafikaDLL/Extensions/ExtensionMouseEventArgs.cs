using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafikaDLL
{
    public static class ExtensionMouseEventArgs
    {
        public static float eps = 5f;
        public static bool CloseEnough(this MouseEventArgs e, PointF p)
        {
            return Math.Abs(e.X - p.X) <= eps && Math.Abs(e.Y - p.Y) <= eps;            
        }
        public static bool CloseEnough(this MouseEventArgs e, Vector2 v)
        {
            return Math.Abs(e.X - v.x) <= eps && Math.Abs(e.Y - v.y) <= eps;
        }

        public static bool Catch(this MouseEventArgs e, Rectangle rect, 
            out float dx, out float dy)
        {
            dx = 0; dy=0;
            if (rect.Left <= e.X && e.X < rect.Right &&
                rect.Top <= e.Y && e.Y < rect.Bottom)
            {
                dx = e.X - rect.Left;
                dy = e.Y - rect.Top;
                return true;
            }
            return false;
        }
    }
}
