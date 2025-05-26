using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using static UnityEngine.Mathf;

namespace Unity4D
{
    public static class MeshCreation
    {
        public static void MakeWireFrame(Object4D object4D, GameObject gameObject)
        {
            float minDepth = 1000, maxDepth = 0;

            //Generates the min and max depth for depth cueing
            foreach (Edge edge in object4D.edges)
            {
                if ((edge.vertex1.depth + edge.vertex2.depth) > maxDepth) maxDepth = (edge.vertex1.depth + edge.vertex2.depth);
                else if ((edge.vertex1.depth + edge.vertex2.depth) < minDepth) minDepth = (edge.vertex1.depth + edge.vertex2.depth);
            }
            //Creates the objects and sets their transformations to match the edge by iterating through the edge list
                foreach (Edge edge in object4D.edges)
            {    
                edge.edgeCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                edge.edgeCube.transform.parent = gameObject.transform;
                edge.edgeCube.transform.position = edge.edgeCube.transform.position + (new Vector3(
                    (edge.vertex1.project.x + edge.vertex2.project.x) / 2,
                    (edge.vertex1.project.y + edge.vertex2.project.y) / 2,
                    (edge.vertex1.project.z + edge.vertex2.project.z) / 2
                    ));
                edge.edgeCube.transform.localScale = new Vector3(0.1f, 0.1f, Vector3.Distance(edge.vertex1.project, edge.vertex2.project));
                edge.edgeCube.transform.LookAt(edge.vertex2.project);
                edge.edgeCube.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.blue, Color.red, ((((edge.vertex1.depth + edge.vertex2.depth)) - minDepth) / (maxDepth - minDepth)));
            }
        }
        public static void UpdateWireFrame(Object4D object4D)
        {
            if (object4D.edges[0].edgeCube == null) return;
            float minDepth = 1000, maxDepth = 0;

            //Generates the new min and max depth for depth cueing
            foreach (Edge edge in object4D.edges)
            {
                if ((edge.vertex1.depth + edge.vertex2.depth) > maxDepth) maxDepth = (edge.vertex1.depth + edge.vertex2.depth);
                if ((edge.vertex1.depth + edge.vertex2.depth) < minDepth) minDepth = (edge.vertex1.depth + edge.vertex2.depth);
            }

            //Updates each edge's GameObject by iterating through the edge list
            foreach (Edge edge in object4D.edges)
            {
                edge.edgeCube.transform.position = new Vector3(
                    (edge.vertex1.project.x + edge.vertex2.project.x) / 2,
                    (edge.vertex1.project.y + edge.vertex2.project.y) / 2,
                    (edge.vertex1.project.z + edge.vertex2.project.z) / 2
                    );
                edge.edgeCube.transform.localScale = new Vector3(0.1f, 0.1f, Vector3.Distance(edge.vertex1.project, edge.vertex2.project));
                edge.edgeCube.transform.LookAt(edge.vertex2.project);
                edge.edgeCube.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.red, Color.blue, ((((edge.vertex1.depth + edge.vertex2.depth)) - minDepth) / (maxDepth - minDepth)));
            }
        }
    }
}