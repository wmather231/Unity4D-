using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Mathf;



namespace Unity4D
{
    public class ObjectGenerator : MonoBehaviour
    {
        public Object4D object4D;
        public ViewportQuad viewport;
        private Vector4 from, to, up, over;
        private float viewingAngle;
        private bool wireFrameCreated = false;

        //Uncomment if you wish to use DrawGizmos() to display object
        //private Color lerped;
        //private Color color1 = Color.red;
        //private Color color2 = Color.blue;

        private void Start()
        {
            object4D = new Hexadecachoron();
                viewport = new ViewportQuad(object4D.to);
                Projection4D.DoMaths4DTo3D(object4D, viewport);
                from = object4D.from;
                to = object4D.to;
                up = object4D.up;
                over = object4D.over;
                viewingAngle = object4D.ViewingAngle;
        }

        void SetObjectParam()
        {
            object4D.from = from;
            object4D.to = to;
            object4D.up = up;
            object4D.over = over;
            object4D.ViewingAngle = viewingAngle;

            viewport.Center = object4D.to;
        }


        private void Update()
        {
            if (Input.GetButton("RotateXY"))//Press up                
                Rotate4D.RotateView(object4D, viewport, Cos(0.01f), Sin(0.01f), 0, 1);

            if (Input.GetButton("RotateYZ"))//Press Q
                Rotate4D.RotateView(object4D, viewport, Cos(0.01f), Sin(0.01f), 1, 2);

            if (Input.GetButton("RotateZX"))//Press right
                Rotate4D.RotateView(object4D, viewport, Cos(0.01f), Sin(0.01f), 2, 0);

            if (Input.GetButton("RotateXW")) //Press j
                Rotate4D.RotateView(object4D, viewport, Cos(0.01f), Sin(0.01f), 0, 3);

            if (Input.GetButton("RotateYW")) //Press W
                Rotate4D.RotateView(object4D, viewport, Cos(-0.01f), Sin(-0.01f), 1, 3);

            if (Input.GetButton("RotateZW")) //Press D
                Rotate4D.RotateView(object4D, viewport, Cos(0.01f), Sin(0.01f), 2, 3);

            if (Input.GetButton("RotateNegXY"))//Press down
                Rotate4D.RotateView(object4D, viewport, Cos(-0.01f), Sin(-0.01f), 0, 1);

            if (Input.GetButton("RotateNegYZ"))//Press E
                Rotate4D.RotateView(object4D, viewport, Cos(-0.01f), Sin(-0.01f), 1, 2);

            if (Input.GetButton("RotateNegZX"))//Press left
                Rotate4D.RotateView(object4D, viewport, Cos(-0.01f), Sin(-0.01f), 2, 0);

            if (Input.GetButton("RotateNegXW")) //Press k
                Rotate4D.RotateView(object4D, viewport, Cos(-0.01f), Sin(-0.01f), 0, 3);

            if (Input.GetButton("RotateNegYW")) //Press S
                Rotate4D.RotateView(object4D, viewport, Cos(0.01f), Sin(0.01f), 1, 3);

            if (Input.GetButton("RotateNegZW")) //Press A
                Rotate4D.RotateView(object4D, viewport, Cos(-0.01f), Sin(-0.01f), 2, 3);

            if (Input.GetButtonDown("Reset")) //Press space
            {
                SetObjectParam();
                Projection4D.Calc4Matrix(object4D);
                Projection4D.Project4DTo3D(object4D, viewport);
            }

            if (Input.GetButtonDown("Create") && wireFrameCreated == false)// Press 0
            {
                MeshCreation.MakeWireFrame(object4D, this.gameObject);
                wireFrameCreated = true;
            }
            MeshCreation.UpdateWireFrame(object4D);
        }

        //Uncomment if you want to use Unity Gizmos to draw the object
        //void OnDrawGizmos()
        //{
        //    if (object4D == null)
        //    {
        //        return;
        //    }
        //    ////Gizmo that generates spheres on each of the object's vertexes
        //    //for (int i = 0; i < TestArray.Length; i++)
        //    //{
        //    //    Gizmos.color = new Color(c, c, c, 1);
        //    //    Gizmos.DrawSphere(TestArray[i], 0.05f);
        //    //}
        //
        //    //Gizmo that generates a wirefraame cube using edge mapping
        //    int count = 0;
        //    foreach (Edge edge in object4D.edges)
        //    {
        //        Debug.Log("Vertex depth 1 and 2 " + edge.vertex1.depth + " " + edge.vertex2.depth);
        //        lerped = Color.Lerp(color1, color2, ((((edge.vertex1.depth + edge.vertex2.depth)) - 6) / (10 - 6)));
        //        Gizmos.color = lerped;
        //        Gizmos.DrawLine(edge.vertex1.project, edge.vertex2.project);
        //        count++;
        //    }
        //    Debug.Log("Drew " + count + "Gizmos");
        //}
    }
}


