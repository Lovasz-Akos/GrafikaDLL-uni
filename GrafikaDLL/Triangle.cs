using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class Triangle
    {
        Vector4 v0, v1, v2;

        public Triangle()
        {
            this.v0 = new Vector4(0.0, 0.0, 0.0, 1.0);
            this.v1 = new Vector4(0.0, 0.0, 0.0, 1.0);
            this.v2 = new Vector4(0.0, 0.0, 0.0, 1.0);
        }
        public Triangle(Vector4 v0, Vector4 v1, Vector4 v2)
        {
            this.v0 = new Vector4(v0);
            this.v1 = new Vector4(v1);
            this.v2 = new Vector4(v2);
        }
    }
}
