using UnityEngine;

namespace Unity4D
{
    public class Edge
    {
        public Vertex vertex1;
        public Vertex vertex2;
        public GameObject edgeCube;

        public Edge(Vertex v1, Vertex v2)
        {
            vertex1 = v1;
            vertex2 = v2;
        }
    }
}
