using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    class BSpline
    {
        public static double N0(double t) { return 1.0 / 6.0 * (1 - t) * (1 - t) * (1 - t); }
        public static double N1(double t) { return 0.5 * t * t * t - t * t + 2.0 / 3.0; }
        public static double N2(double t) { return -0.5 * t * t * t + 0.5 * t * t + 0.5 * t + 1.0 / 6.0; }
        public static double N3(double t) { return 1.0 / 6.0 * t * t * t; }
    }
}
