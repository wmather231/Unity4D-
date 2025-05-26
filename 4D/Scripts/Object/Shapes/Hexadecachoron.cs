using System.Collections.Generic;
using UnityEngine;

namespace Unity4D
{
    public class Hexadecachoron : Object4D
    {
        public Hexadecachoron() 
        {
            radius = 0;
            numVertex = 8;
            numEdge = 24;

            from.Set(4, 0, 0, 0);
            to.Set(0, 0, 0, 0);
            up.Set(0, 1, 0, 0);
            over.Set(0, 0, 1, 0);
            ViewingAngle = 45;

            vertices = new List<Vertex>();
            vertices.Add(new Vertex(+1, 0, 0, 0)); //Middle
            vertices.Add(new Vertex(0, +1, 0, 0)); //Bottom
            vertices.Add(new Vertex(0, 0, +1, 0)); //Right
            vertices.Add(new Vertex(0, 0, 0, +1)); //Back
            vertices.Add(new Vertex(0, 0, 0, -1)); //Front
            vertices.Add(new Vertex(0, 0, -1, 0)); //Left
            vertices.Add(new Vertex(0, -1, 0, 0)); //Top
            vertices.Add(new Vertex(-1, 0, 0, 0)); //Middle
            

            edges = new List<Edge>();

            edges.Add(new Edge(vertices[0], vertices[1]));
            edges.Add(new Edge(vertices[0], vertices[2]));
            edges.Add(new Edge(vertices[0], vertices[3]));
            edges.Add(new Edge(vertices[0], vertices[4]));
            edges.Add(new Edge(vertices[0], vertices[5]));
            edges.Add(new Edge(vertices[0], vertices[6]));

            edges.Add(new Edge(vertices[1], vertices[2]));
            edges.Add(new Edge(vertices[1], vertices[3]));
            edges.Add(new Edge(vertices[1], vertices[4]));
            edges.Add(new Edge(vertices[1], vertices[5]));
            edges.Add(new Edge(vertices[1], vertices[7]));

            edges.Add(new Edge(vertices[2], vertices[3]));
            edges.Add(new Edge(vertices[2], vertices[4]));
            edges.Add(new Edge(vertices[2], vertices[6]));
            edges.Add(new Edge(vertices[2], vertices[7]));

            edges.Add(new Edge(vertices[3], vertices[5]));
            edges.Add(new Edge(vertices[3], vertices[6]));
            edges.Add(new Edge(vertices[3], vertices[7]));

            edges.Add(new Edge(vertices[4], vertices[5]));
            edges.Add(new Edge(vertices[4], vertices[6]));
            edges.Add(new Edge(vertices[4], vertices[7]));

            edges.Add(new Edge(vertices[5], vertices[6]));
            edges.Add(new Edge(vertices[5], vertices[7]));
            edges.Add(new Edge(vertices[6], vertices[7]));



            Debug.Log("Edge count" + edges.Count);

        }
    }
}
