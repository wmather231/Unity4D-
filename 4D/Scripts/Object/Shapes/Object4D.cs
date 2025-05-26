using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace Unity4D
{
    public class Object4D 
    {
        public static float PHI = 1.61803398874989484820f;
        public Vector4 A, B, C, D;
        public int numVertex;
        public int numEdge;
        public List<Vertex> vertices;
        public List<Edge> edges;

        public Vector4 from;
        public Vector4 to;
        public Vector4 up;
        public Vector4 over;
        public float ViewingAngle;
        public float radius;

        public Object4D()
        {
            radius = 0;
            numVertex = 0;
            numEdge = 0;

            from.Set(4, 0, 0, 0);
            to.Set(0, 0, 0, 0);
            up.Set(0, 1, 0, 0);
            over.Set(0, 0, 1, 0);
            ViewingAngle = 45;

            vertices = new List<Vertex>();

            edges = new List<Edge>();
        }
    }
}