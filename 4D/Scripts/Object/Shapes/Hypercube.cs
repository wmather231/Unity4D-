using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Unity4D {
    [Serializable]
    public class Hypercube : Object4D
    {
        public Hypercube()
        {
            radius = 0;
            numVertex = 16;
            numEdge = 32;

            from.Set(4, 0, 0, 0);
            to.Set(0, 0, 0, 0);
            up.Set(0, 1, 0, 0);
            over.Set(0, 0, 1, 0);
            ViewingAngle = 45;

            vertices = new List<Vertex>();
            vertices.Add(new Vertex(-1, -1, -1, -1));
            vertices.Add(new Vertex(1, -1, -1, -1));
            vertices.Add(new Vertex(1, 1, -1, -1));
            vertices.Add(new Vertex(-1, 1, -1, -1));

            vertices.Add(new Vertex(-1, -1, 1, -1));
            vertices.Add(new Vertex(1, -1, 1, -1));
            vertices.Add(new Vertex(1, 1, 1, -1));
            vertices.Add(new Vertex(-1, 1, 1, -1));

            vertices.Add(new Vertex(-1, -1, -1, 1));
            vertices.Add(new Vertex(1, -1, -1, 1));
            vertices.Add(new Vertex(1, 1, -1, 1));
            vertices.Add(new Vertex(-1, 1, -1, 1));

            vertices.Add(new Vertex(-1, -1, 1, 1));
            vertices.Add(new Vertex(1, -1, 1, 1));
            vertices.Add(new Vertex(1, 1, 1, 1));
            vertices.Add(new Vertex(-1, 1, 1, 1));


            edges = new List<Edge>();
            edges.Add(new Edge(vertices[0], vertices[1]));
            edges.Add(new Edge(vertices[1], vertices[2]));
            edges.Add(new Edge(vertices[2], vertices[3]));
            edges.Add(new Edge(vertices[3], vertices[0]));

            edges.Add(new Edge(vertices[4], vertices[5]));
            edges.Add(new Edge(vertices[5], vertices[6]));
            edges.Add(new Edge(vertices[6], vertices[7]));
            edges.Add(new Edge(vertices[7], vertices[4]));

            edges.Add(new Edge(vertices[0], vertices[4]));
            edges.Add(new Edge(vertices[1], vertices[5]));
            edges.Add(new Edge(vertices[2], vertices[6]));
            edges.Add(new Edge(vertices[3], vertices[7]));

            edges.Add(new Edge(vertices[8], vertices[9]));
            edges.Add(new Edge(vertices[9], vertices[10]));
            edges.Add(new Edge(vertices[10], vertices[11]));
            edges.Add(new Edge(vertices[11], vertices[8]));

            edges.Add(new Edge(vertices[12], vertices[13]));
            edges.Add(new Edge(vertices[13], vertices[14]));
            edges.Add(new Edge(vertices[14], vertices[15]));
            edges.Add(new Edge(vertices[15], vertices[12]));

            edges.Add(new Edge(vertices[8], vertices[12]));
            edges.Add(new Edge(vertices[9], vertices[13]));
            edges.Add(new Edge(vertices[10], vertices[14]));
            edges.Add(new Edge(vertices[11], vertices[15]));

            edges.Add(new Edge(vertices[0], vertices[8]));
            edges.Add(new Edge(vertices[1], vertices[9]));
            edges.Add(new Edge(vertices[2], vertices[10]));
            edges.Add(new Edge(vertices[3], vertices[11]));
            edges.Add(new Edge(vertices[4], vertices[12]));
            edges.Add(new Edge(vertices[5], vertices[13]));
            edges.Add(new Edge(vertices[6], vertices[14]));
            edges.Add(new Edge(vertices[7], vertices[15]));

        }
    }
}
