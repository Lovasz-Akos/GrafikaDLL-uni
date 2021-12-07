using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class ObjectBRep
    {
        public BRep model;
        public Matrix4 transformation;
        public Color color;

        public ObjectBRep()
        {
            model = new BRep();
            transformation = new Matrix4();
            transformation.LoadIdentity();
            color = Color.Black;
        }
    }
}
