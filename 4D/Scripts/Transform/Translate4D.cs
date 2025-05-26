using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity4D
{
    public static class Translate4D
    {
        public static void Translate(Object4D object4D, ViewportQuad viewport, Vector3 transform)
        {
            viewport.Center = viewport.Center + transform;

            Projection4D.Calc4Matrix(object4D);
            Projection4D.Project4DTo3D(object4D, viewport);
        }
    }
}