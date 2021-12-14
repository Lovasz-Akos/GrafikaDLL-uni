using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class Bezier
    {
        public static double B(int i, int n, double t)
        {
            return Binom(n, i) * Math.Pow(1 - t, n - i) * Math.Pow(t, i);
        }
        private static int Binom(int n, int k)
        {
            if (k == 0 || k == n) return 1;
            if (n == 0) return 0;
            return Binom(n - 1, k - 1) + Binom(n - 1, k);
        }
    }
}
