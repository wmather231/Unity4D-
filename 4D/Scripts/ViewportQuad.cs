using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity4D
{
    [Serializable]
    public class ViewportQuad
    {
        public Vector3 Center;
        public Vector3 length;

        public ViewportQuad(Vector3 center)
        { 
            this.Center = center; 
            length.x = 5;
            length.y = 5;
            length.z = 5;
        }
    }
}
