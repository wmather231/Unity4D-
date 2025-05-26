//These functions are the resultants of the work done by Hollash for his thesis ‘Four-Space Visualization of 4D Objects' in 1991
//They have been refactored, optimised and adapted for unity and use in this program
//Most of the functions have been altered, however the unaltered ones are marked as such

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Mathf;



namespace Unity4D
{
    public static class Projection4D
    {

        public static void DoMaths4DTo3D(Object4D object4D, ViewportQuad viewport)
        {
            CalculateRadius(object4D);
            Calc4Matrix(object4D);
            Project4DTo3D(object4D, viewport);
        }

        public static async void Project4DTo3D(Object4D object4D, ViewportQuad viewport) {
            int IsParallel = 0;
            int IsPerspective = 1;
            float projConst = 0;

            if (IsPerspective == 1)
            {
                IsPerspective = 1;
                IsParallel = 0;
            }
            else
            {
                IsParallel = 1;
                IsPerspective = 0;
            }
            projConst = 1 / Tan(object4D.ViewingAngle / 2);

            await Task.Run(() => Parallel.ForEach(object4D.vertices, vert =>
            {
                Debug.Log($"Thread started: {Thread.CurrentThread.ManagedThreadId}");

                Vector4 V = vert.positon - object4D.from; //4D world coordinates to 4D eye coordinates (step 1)

                vert.depth = Vector4.Dot(V, object4D.D);

                //Branchless Statement to avoid using an if statement to calculate the depth of perspective projection
                float S = ((projConst / vert.depth) * IsPerspective) + ((1 / object4D.radius) * IsParallel);


                //Map the coordinates to the viewport
                vert.project.x = viewport.Center.x + (viewport.length.x / 2) * (S * Vector4.Dot(V, object4D.A));
                vert.project.y = viewport.Center.y + (viewport.length.y / 2) * (S * Vector4.Dot(V, object4D.B));
                vert.project.z = viewport.Center.z + (viewport.length.z / 2) * (S * Vector4.Dot(V, object4D.C));
                //Debug.Log("4D vertices new project " + vert.project);
            }));

        }



        //Function that creates a 4 dimensional viewing matrix in the form A, B, C, and D. 
        // A: X axis basis vector, B: Up vector, C: Over vector, D: 4th coordinate basis vector + line of sight
        public static void Calc4Matrix(Object4D Object4D)
        {
           
            //Get the normalised D column - Vector
            Object4D.D = Object4D.to - Object4D.from;
            Debug.Log("D start: " + Object4D.D);
            if (Object4D.D.magnitude == 0) { Debug.Log("To and From point are equal"); return; }
            Object4D.D.Normalize();
            Debug.Log("D column vector" + Object4D.D);

            //Calculate to get the normalised A column Vector
            Object4D.A = Cross4(Object4D.up, Object4D.over, Object4D.D);
            Debug.Log("A start: " + Object4D.D);
            if (Object4D.A.magnitude == 0) { Debug.Log("Invalid up Vector"); return; }
            Object4D.A.Normalize();
            Debug.Log("A column vector" + Object4D.A);

            //Calculate to get the normalised B column vector
            Object4D.B = Cross4(Object4D.over, Object4D.D, Object4D.A);
            Debug.Log("B start: " + Object4D.B);
            if (Object4D.B.magnitude == 0) { Debug.Log("Invalid Over Vector"); return; }
            Object4D.B.Normalize();
            Debug.Log("B column vector" + Object4D.B);

            //Calculate the C column Vector
            Object4D.C = Cross4(Object4D.D, Object4D.A, Object4D.B);
            Debug.Log("C column vector" + Object4D.C);
        }

        //A function to calculate the max radius of the object created by Hollash for his thesis
        //S.R Hollasch, ‘Four-Space Visualization of 4D Objects’, Arizona State University, 1991
        public static void CalculateRadius(Object4D Object4D)
        {
            Vector4 temp;

            for (int i = 0; i < Object4D.numVertex; i++)
            {
                float distance;
                temp = Object4D.vertices[i].positon - Object4D.to;
                distance = Vector4.Dot(temp, temp);
                if (distance > Object4D.radius)
                    Object4D.radius = distance;
            }
            Object4D.radius = Sqrt(Object4D.radius);
        }


        //A function to calculate the cross product of Vector4 variables created by Hollash for his thesis
        //S.R Hollasch, ‘Four-Space Visualization of 4D Objects’, Arizona State University, 1991
        public static Vector4 Cross4(Vector4 U, Vector4 V, Vector4 W)
        {
            float A, B, C, D, E, F;       // Intermediate Values
            Vector4 result = Vector4.zero;

            // Calculate intermediate values.

            A = (V[0] * W[1]) - (V[1] * W[0]);
            B = (V[0] * W[2]) - (V[2] * W[0]);
            C = (V[0] * W[3]) - (V[3] * W[0]);
            D = (V[1] * W[2]) - (V[2] * W[1]);
            E = (V[1] * W[3]) - (V[3] * W[1]);
            F = (V[2] * W[3]) - (V[3] * W[2]);

            // Calculate the result-vector components.

            result[0] = (U[1] * F) - (U[2] * E) + (U[3] * D);
            result[1] = -(U[0] * F) + (U[2] * C) - (U[3] * B);
            result[2] = (U[0] * E) - (U[1] * C) + (U[3] * A);
            result[3] = -(U[0] * D) + (U[1] * B) - (U[2] * A);

            return result;
        }

    }
}