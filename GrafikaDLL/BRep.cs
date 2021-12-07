using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class BRep
    {
        public List<Vector4> vertices;
        public List<Edge> edges;
        public List<Triangle> triangles;

        public BRep()
        {
            vertices = new List<Vector4>();
            edges = new List<Edge>();
            triangles = new List<Triangle>();
        }

        private void ClearModel()
        {
            vertices.Clear();
            edges.Clear();
            triangles.Clear();
        }

        public void LoadFromFile(string path, ModelFileType type)
        {
            switch (type)
            {
                case ModelFileType.Wavefront: LoadFromWavefront(path); break;
                case ModelFileType.Polygon: LoadFromPolygon(path); break;
                default: break;
            }
        }

        private void LoadFromWavefront(string path)
        {
            ClearModel();
            StreamReader sr = new StreamReader(path);
            while(!sr.EndOfStream)
            {
                string row = sr.ReadLine();
                string[] data = row.Split(' ');
                switch (data[0])
                {
                    case "v":
                        vertices.Add(new Vector4(double.Parse(data[1], CultureInfo.InvariantCulture),
                                                 double.Parse(data[2], CultureInfo.InvariantCulture),
                                                 double.Parse(data[3], CultureInfo.InvariantCulture)));
                        break;
                    case "f": 
                        edges.Add(new Edge(vertices[int.Parse(data[1]) - 1], 
                                           vertices[int.Parse(data[2]) - 1]));
                        edges.Add(new Edge(vertices[int.Parse(data[2]) - 1],
                                           vertices[int.Parse(data[3]) - 1]));
                        edges.Add(new Edge(vertices[int.Parse(data[3]) - 1],
                                           vertices[int.Parse(data[1]) - 1]));
                        
                        triangles.Add(new Triangle(vertices[int.Parse(data[1]) - 1],
                                                   vertices[int.Parse(data[2]) - 1],
                                                   vertices[int.Parse(data[3]) - 1]));
                        break;
                    default: break;
                }
            }
            sr.Close();
        }
        private void LoadFromPolygon(string path)
        {
            throw new NotImplementedException();
        }
    }
}
