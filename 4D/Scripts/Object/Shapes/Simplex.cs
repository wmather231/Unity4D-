using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.Mathf;

namespace Unity4D
{
    public class Simplex : Object4D
    {
        public Simplex() 
        {
            radius = 0;
            numVertex = 5;
            numEdge = 10;

            from.Set(4, 0, 0, 0);
            to.Set(0, 0, 0, 0);
            up.Set(0, 1, 0, 0);
            over.Set(0, 0, 1, 0);
            ViewingAngle = 45;

            float tempf1 = 2 / PHI;
            float tempf2 = 1 / PHI - 2;
            float result1 = 1 / tempf2;
            float result2 = (tempf1 - 3) / tempf2;

            vertices = new List<Vertex>();
            vertices.Add(new Vertex(result2, result1, result1, result1));
            vertices.Add(new Vertex(result1, result2, result1, result1));
            vertices.Add(new Vertex(result1, result1, result2, result1));
            vertices.Add(new Vertex(result1, result1, result1, result2));
            vertices.Add(new Vertex((tempf1/tempf2), (tempf1 / tempf2), (tempf1 / tempf2), (tempf1 / tempf2)));

            edges = new List<Edge>();
            edges.Add(new Edge(vertices[0], vertices[1]));
            edges.Add(new Edge(vertices[1], vertices[2]));
            edges.Add(new Edge(vertices[2], vertices[3]));
            edges.Add(new Edge(vertices[3], vertices[4]));
            edges.Add(new Edge(vertices[4], vertices[0]));
            edges.Add(new Edge(vertices[0], vertices[2]));
            edges.Add(new Edge(vertices[0], vertices[3]));
            edges.Add(new Edge(vertices[1], vertices[3]));
            edges.Add(new Edge(vertices[1], vertices[4]));
            edges.Add(new Edge(vertices[2], vertices[4]));


        }
    }
}
