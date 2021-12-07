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
                bmp.SetPixel((int)x, (int)y, color);
            }
        }

        public static void FillEdgeFlag(this Bitmap bmp,
            Color background, Color fillColor)
        {
            bool inside = false;
            for (int y = 0; y < bmp.Height; y++)
            {
                inside = false;
                for (int x = 0; x < bmp.Width; x++)
                {
                    //Figyelni, hogy hány pixel van egymás mellet, mert így most
                    //vannak olyan sávok, amik fehérek maradnak
                    if (!bmp.GetPixel(x, y).IsTheSameAs(background))
                    {
                        inside = !inside;
                        continue;
                    }
                    if (inside)
                        bmp.SetPixel(x, y, fillColor);
                }
            }
        }

        public static void FillRec4(this Bitmap bmp,
            Color background, Color fillColor, int x, int y)
        {
            if (bmp.GetPixel(x, y).IsTheSameAs(background))
            {
                bmp.SetPixel(x, y, fillColor);
                bmp.FillRec4(background, fillColor, x + 1, y);
                bmp.FillRec4(background, fillColor, x - 1, y);
                bmp.FillRec4(background, fillColor, x, y + 1);
                bmp.FillRec4(background, fillColor, x, y - 1);
            }
        }
        public static void FillRec8(this Bitmap bmp,
            Color background, Color fillColor, int x, int y)
        {
            throw new NotImplementedException();
            //if (bmp.GetPixel(x, y).IsTheSameAs(background))
            //{
            //    bmp.SetPixel(x, y, fillColor);
            //    bmp.FillRec8(background, fillColor, x + 1, y);
            //    bmp.FillRec8(background, fillColor, x - 1, y);
            //    bmp.FillRec8(background, fillColor, x, y + 1);
            //    bmp.FillRec8(background, fillColor, x, y - 1);
            //    bmp.FillRec8(background, fillColor, x + 1, y + 1);
            //    bmp.FillRec8(background, fillColor, x - 1, y + 1);
            //    bmp.FillRec8(background, fillColor, x + 1, y - 1);
            //    bmp.FillRec8(background, fillColor, x - 1, y - 1);
            //}
        }

        public static void FillStack4(this Bitmap bmp,
            Color background, Color fillColor, int x, int y)
        {
            int[] dx = new int[] { 0, 1, 0, -1 };
            int[] dy = new int[] { 1, 0, -1, 0 };
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(x, y));
            Point p;
            while(stack.Count > 0)
            {
                p = stack.Pop();
                bmp.SetPixel(p.X, p.Y, fillColor);
                for (int i = 0; i < 4; i++)
                {
                    if (bmp.GetPixel(p.X + dx[i], p.Y + dy[i]).IsTheSameAs(background))
                        stack.Push(new Point(p.X + dx[i], p.Y + dy[i]));
                }
            }
        }
        public static void FillStack8(this Bitmap bmp,
            Color background, Color fillColor, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
