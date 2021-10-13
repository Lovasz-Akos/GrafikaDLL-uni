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
    }
}
