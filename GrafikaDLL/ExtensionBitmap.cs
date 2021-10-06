using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public static class ExtensionBitmap
    {
        public static void SetLine(this Bitmap bmp,
            float x1, float y1, float x2, float y2, Color color)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            float length = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);
            float incX = dx / length;
            float incY = dy / length;
            float x = x1, y = y1;
            bmp.SetPixel((int)x, (int)y, color);
            for (int i = 0; i < length; i++)
            {
                x += incX;
                y += incY;
                bmp.SetPixel((int)x,(int)y, color);
            }
        }

        public static void FillEdgeFlag(this Bitmap bmp, Color background, Color fillColor)
        {
            bool inside = false;
            for (int y = 0; y < bmp.Height; y++)
            {
                inside = false;
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (bmp.GetPixel(x, y).IsTheSameAs(background))
                    {
                        inside = true;
                    }
                    if (inside)
                    {
                        bmp.SetPixel(x, y, fillColor);
                    }
                }
            }
        }
    }
}
