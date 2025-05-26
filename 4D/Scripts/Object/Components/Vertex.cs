using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;

namespace Unity4D
{
    public class Vertex
    {
        public Vector4 positon;
        public Vector3 project;
        public float depth;

        public Vertex(float x, float y, float z, float w)
        {
            this.positon = new Vector4(x, y, z, w);
        }    
    }
}
