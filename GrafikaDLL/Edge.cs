using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class Edge
    {
        public Vector4 v0, v1;

        public Edge()
        {
            this.v0 = new Vector4(0.0, 0.0, 0.0, 1.0);
            this.v1 = new Vector4(0.0, 0.0, 0.0, 1.0);
        }
        public Edge(Vector4 v0, Vector4 v1)
        {
            this.v0 = new Vector4(v0);
            this.v1 = new Vector4(v1);
        }
    }
}
