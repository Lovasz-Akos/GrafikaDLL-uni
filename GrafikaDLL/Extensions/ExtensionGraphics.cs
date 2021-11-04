using GrafikaDLL.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public static class ExtensionGraphics
    {
        #region DrawLine
        public static void DrawLine(this Graphics g, Pen pen,
            Vector2 v1, Vector2 v2)
        {
            g.DrawLine(pen, (float)v1.x, (float)v1.y, (float)v2.x, (float)v2.y);
        }
        #endregion

        #region DrawLineDDA
        public static void DrawLineDDA(this Graphics g,
            Pen pen, float x1, float y1, float x2, float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            float length = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);
            float incX = dx / length;
            float incY = dy / length;
            float x = x1, y = y1;
            g.DrawRectangle(pen, x, y, 0.5f, 0.5f);
            for (int i = 0; i < length; i++)
            {
                x += incX;
                y += incY;
                g.DrawRectangle(pen, x, y, 0.5f, 0.5f);
            }
        }
        public static void DrawLineDDA(this Graphics g,
            Pen pen, int x1, int y1, int x2, int y2)
        {
            g.DrawLineDDA(pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }
        public static void DrawLineDDA(this Graphics g,
            Pen pen, PointF p1, PointF p2)
        {
            g.DrawLineDDA(pen, p1.X, p1.Y, p2.X, p2.Y);
        }
        public static void DrawLineDDA(this Graphics g,
            Pen pen, Point p1, Point p2)
        {
            g.DrawLineDDA(pen, p1.X, p1.Y, p2.X, p2.Y);
        }

        public static void DrawLineDDA(this Graphics g,
            Color c1, Color c2, float x1, float y1, float x2, float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            float length = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);
            float incX = dx / length;
            float incY = dy / length;
            float incR = (c2.R - c1.R) / length;
            float incG = (c2.G - c1.G) / length;
            float incB = (c2.B - c1.B) / length;
            float x = x1, y = y1;
            float R = c1.R, G = c1.G, B = c1.B;
            g.DrawRectangle(new Pen(Color.FromArgb((int)R, (int)G, (int)B)), x, y, 0.5f, 0.5f);
            for (int i = 0; i < length; i++)
            {
                x += incX; y += incY;
                R += incR; G += incG; B += incB;
                g.DrawRectangle(new Pen(Color.FromArgb((int)R, (int)G, (int)B)), x, y, 0.5f, 0.5f);
            }
        }
        public static void DrawLineDDA(this Graphics g,
            Color c1, Color c2, PointF p1, PointF p2)
        {
            g.DrawLineDDA(c1, c2, p1.X, p1.Y, p2.X, p2.Y);
        }
        #endregion

        #region DrawLineMiPoint
        public static void DrawLineMidPoint(this Graphics g,
            Pen pen, float x1, float y1, float x2, float y2)
        {
            throw new NotImplementedException();
        }
        public static void DrawLineMidPoint(this Graphics g,
            Pen pen, PointF p1, PointF p2)
        {
            g.DrawLineMidPoint(pen, p1.X, p1.Y, p2.X, p2.Y);
        }
        public static void DrawLineMidPoint(this Graphics g,
            Color c1, Color c2, float x1, float y1, float x2, float y2)
        {
            throw new NotImplementedException();
        }
        public static void DrawLineMidPoint(this Graphics g,
            Color c1, Color c2, PointF p1, PointF p2)
        {
            g.DrawLineMidPoint(c1, c2, p1.X, p1.Y, p2.X, p2.Y);
        }
        #endregion

        #region DrawPoint
        public static void DrawPoint(this Graphics g, Pen pen, Brush brush,
            Vector2 v, float r)
        {
            g.FillEllipse(brush, (float)(v.x - r), (float)(v.y - r), 2 * r, 2 * r);
            g.DrawEllipse(pen, (float)(v.x - r), (float)(v.y - r), 2 * r, 2 * r);
        }
        #endregion

        #region DrawPolygon
        public static void DrawPolygonDDA(this Graphics g, Pen pen, PointF[] points, bool closed = false)
        {
            if (points.Length < 2)
                throw new Exception();

            for (int i = 0; i < points.Length - 1; i++)
                g.DrawLineDDA(pen, points[i], points[i + 1]);
            if (closed)
                g.DrawLineDDA(pen, points[points.Length - 1], points[0]);
        }
        public static void DrawPolygon(this Graphics g, Color[] colors, PointF[] points, bool closed = false)
        {
            if (points.Length < 2)
                throw new Exception();

            for (int i = 0; i < points.Length - 1; i++)
                g.DrawLineDDA(colors[i], colors[i + 1], points[i], points[i + 1]);
            if (closed)
                g.DrawLineDDA(colors[colors.Length - 1], colors[0], points[points.Length - 1], points[0]);
        }
        #endregion

        #region DrawCircle
        public static void DrawCircle(this Graphics g, Pen pen, PointF C, float r)
        {

        }
        public static void DrawCircle(this Graphics g, Color c1, Color c2, PointF C, float r)
        {

        }
        #endregion

        #region DrawParametricCurve2D
        //public delegate double RtoR(double x); //valós változós valós értékű
        //public delegate double R2toR(double x, double y); //két valós változós valós értékű
        public static void DrawParametricCurve2D(this Graphics g, Pen pen,
            Func<double, double> X, Func<double, double> Y,
            double a, double b, int n = 500)
        {
            double t = a;
            double h = (b - a) / n;
            Vector2 v0 = new Vector2(X(t), Y(t));
            while (t < b)
            {
                t += h;
                Vector2 v1 = new Vector2(X(t), Y(t));
                g.DrawLine(pen, v0, v1);
                v0 = v1;
            }
        }
        #endregion

        #region DrawHemiteArc
        public static void DrawHermiteArc(this Graphics g, Pen pen,
            Vector2 p0, Vector2 p1, Vector2 t0, Vector2 t1)
        {
            g.DrawParametricCurve2D(pen,
                t => Hermite.H0(t) * p0.x + Hermite.H1(t) * p1.x +
                     Hermite.H2(t) * t0.x + Hermite.H3(t) * t1.x,
                t => Hermite.H0(t) * p0.y + Hermite.H1(t) * p1.y +
                     Hermite.H2(t) * t0.y + Hermite.H3(t) * t1.y,
                     0.0, 1.0);
        }
        public static void DrawHermiteArc(this Graphics g, Pen pen, HermiteArc arc)
        {
            g.DrawParametricCurve2D(pen,
                t => Hermite.H0(t) * arc.p0.x + Hermite.H1(t) * arc.p1.x +
                     Hermite.H2(t) * arc.t0.x * arc.weight + Hermite.H3(t) * arc.t1.x * arc.weight,
                t => Hermite.H0(t) * arc.p0.y + Hermite.H1(t) * arc.p1.y +
                     Hermite.H2(t) * arc.t0.y * arc.weight + Hermite.H3(t) * arc.t1.y * arc.weight,
                     0.0, 1.0);
        }
        #endregion

        #region Clip
        private const byte TOP = 8;     //1000
        private const byte BOTTOM = 4;  //0100
        private const byte LEFT = 2;    //0010
        private const byte RIGHT = 1;   //0001

        private static byte OutCode(Rectangle window, PointF p)
        {
            byte code = 0;
            if (p.X < window.Left) code |= LEFT;
            else if (p.X > window.Right) code |= RIGHT;
            if (p.Y < window.Top) code |= TOP;
            else if (p.Y > window.Bottom) code |= BOTTOM;
            return code;
        }

        public static void Clip(this Graphics g, Pen pen,
            Rectangle window, PointF p0, PointF p1)
        {
            byte code0 = OutCode(window, p0);
            byte code1 = OutCode(window, p1);
            bool accept = false;

            while (true)
            {
                if ((code0 | code1) == 0)
                {
                    accept = true;
                    break;
                }
                else if ((code0 & code1) != 0)
                {
                    break;
                }
                else
                {
                    byte code = code0 != 0 ? code0 : code1;
                    float x = 0, y = 0;

                    if ((code & TOP) != 0)
                    {
                        x = p0.X + (p1.X - p0.X) * (window.Top - p0.Y) / (p1.Y - p0.Y);
                        y = window.Top;
                    }
                    else if ((code & BOTTOM) != 0)
                    {
                        x = p0.X + (p1.X - p0.X) * (window.Bottom - p0.Y) / (p1.Y - p0.Y);
                        y = window.Bottom;
                    }
                    else if ((code & LEFT) != 0)
                    {
                        x = window.Left;
                        y = p0.Y + (p1.Y - p0.Y) * (window.Left - p0.X) / (p1.X - p0.X);
                    }
                    else if ((code & RIGHT) != 0)
                    {
                        x = window.Right;
                        y = p0.Y + (p1.Y - p0.Y) * (window.Right - p0.X) / (p1.X - p0.X);
                    }

                    if (code == code0)
                    {
                        p0.X = x; p0.Y = y;
                        code0 = OutCode(window, p0);
                    }
                    else
                    {
                        p1.X = x; p1.Y = y;
                        code1 = OutCode(window, p1);
                    }
                }
            }

            if (accept)
                g.DrawLine(pen, p0, p1);
        }
        public static void Clip(this Graphics g, Pen pen,
            Rectangle window, Line line)
        {
            g.Clip(pen, window, line.p0, line.p1);
        }

        public static void ClipToConvex(this Graphics g, Pen pen,
            PointF[] window, Line line)
        {
            throw new NotImplementedException();
        }
        public static void ClipToConcave(this Graphics g, Pen pen,
            PointF[] window, Line line)
        {
            throw new NotImplementedException();
        }
        public static void Clip(this Graphics g, Pen pen,
            PointF[] window, Line line)
        {
            g.ClipToConcave(pen, window, line);
        }
        #endregion
    }
}
