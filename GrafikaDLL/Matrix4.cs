using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    /// <summary>
    /// 4x4-es négyzetes mátrix
    /// </summary>
    public class Matrix4
    {
        public double[,] m = new double[4, 4];

        public Matrix4() { }
        public Matrix4(Matrix4 m)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    this[i, j] = m[i, j];
        }

        private double this[int i, int j]
        {
            get { return this.m[i, j]; }
            set { this.m[i, j] = value; }
        }

        public void LoadIdentity()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    this[i, j] = 0.0;
            m[0, 0] = 1.0;
            m[1, 1] = 1.0;
            m[2, 2] = 1.0;
            m[3, 3] = 1.0;
        }
        public static Matrix4 GetIdentity()
        {
            Matrix4 res = new Matrix4();
            res.LoadIdentity();
            return res;
        }

        public static Matrix4 operator *(Matrix4 m0, Matrix4 m1)
        {
            Matrix4 res = new Matrix4();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    double sum = 0.0;
                    for (int p = 0; p < 4; p++)
                        sum += m0[i, p] * m1[p, j];
                    res[i, j] = sum;
                }
            return res;
        }
        public static Vector4 operator*(Matrix4 m, Vector4 v)
        {
            Vector4 res = new Vector4();
            res.x = m[0, 0] * v.x + m[0, 1] * v.y + m[0, 2] * v.z + m[0, 3] * v.w;
            res.y = m[1, 0] * v.x + m[1, 1] * v.y + m[1, 2] * v.z + m[1, 3] * v.w;
            res.z = m[2, 0] * v.x + m[2, 1] * v.y + m[2, 2] * v.z + m[2, 3] * v.w;
            res.w = m[3, 0] * v.x + m[3, 1] * v.y + m[3, 2] * v.z + m[3, 3] * v.w;
            return res;
        }

        public static Matrix4 Parallel(Vector4 v)
        {
            Matrix4 res = new Matrix4();
            res.LoadIdentity();
            res[0, 2] = -v.x / v.z;
            res[1, 2] = -v.y / v.z;
            res[2, 2] = 0.0;
            return res;
        }

        public static Matrix4 RotX(double alpha)
        {
            Matrix4 res = new Matrix4();
            res.LoadIdentity();
            res[1, 1] = Math.Cos(alpha);
            res[1, 2] = -Math.Sin(alpha);
            res[2, 1] = Math.Sin(alpha);
            res[2, 2] = Math.Cos(alpha);
            return res;
        }
        public static Matrix4 Scale(double lambda)
        {
            Matrix4 res = new Matrix4();
            res.LoadIdentity();
            res[0, 0] = lambda;
            res[1, 1] = lambda;
            res[2, 2] = lambda;
            return res;
        }
    }
}
