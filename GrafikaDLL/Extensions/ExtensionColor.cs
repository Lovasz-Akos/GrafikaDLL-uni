using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public static class ExtensionColor
    {
        public static bool IsTheSameAs(this Color color, Color other)
        {
            return color.R == other.R &&
                   color.G == other.G &&
                   color.B == other.B;
        }
    }
}
