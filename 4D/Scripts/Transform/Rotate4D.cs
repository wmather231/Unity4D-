using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;


namespace Unity4D
{

    static class Rotate4D
    {
        public static void RotateView(Object4D object4D, ViewportQuad viewport, float Cos, float Sin, int rotatePlane1, int rotatePlane2)
        {
            float result1, result2;
            Vector4 from, to, up, over;
            from = object4D.from;
            to = object4D.to;
            up = object4D.up;
            over = object4D.over;

            result1 = Cos * (object4D.from[rotatePlane1] - object4D.to[rotatePlane1]) + Sin * (object4D.from[rotatePlane2] - object4D.to[rotatePlane2]);
            result2 = Cos * (object4D.from[rotatePlane2] - object4D.to[rotatePlane2]) - Sin * (object4D.from[rotatePlane1] - object4D.to[rotatePlane1]);
            object4D.from[rotatePlane1] = result1 + object4D.to[rotatePlane1];
            object4D.from[rotatePlane2] = result2 + object4D.to[rotatePlane2];

            result1 = Cos * object4D.up[rotatePlane1] + Sin * object4D.up[rotatePlane2];
            result2 = Cos * object4D.up[rotatePlane2] - Sin * object4D.up[rotatePlane1];
            object4D.up[rotatePlane1] = result1;
            object4D.up[rotatePlane2] = result2;

            result1 = Cos * object4D.over[rotatePlane1] + Sin * object4D.over[rotatePlane2];
            result2 = Cos * object4D.over[rotatePlane2] - Sin * object4D.over[rotatePlane1];
            object4D.over[rotatePlane1] = result1;
            object4D.over[rotatePlane2] = result2;

            Debug.Log("Rotated");
            Projection4D.Calc4Matrix(object4D);
            Projection4D.Project4DTo3D(object4D, viewport);
        }
    }
}
