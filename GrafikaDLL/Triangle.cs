using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class Triangle
    {
        public Vector4 v0, v1, v2;

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

        public Vector4 NormalAtV0
        {
            get
            {
                Vector4 cross = (v1 - v0) ^ (v2 - v0);
                cross.Nomalize();
                return cross;
            }
        }
        public bool IsVisible(Vector4 viewVector)
        {
            return (NormalAtV0 * viewVector) / (NormalAtV0.Length * viewVector.Length) > 0;
        }

        public double WeightZ
        {
            get { return (v0.z + v1.z + v2.z) / 3.0; }
        }
    }
}
