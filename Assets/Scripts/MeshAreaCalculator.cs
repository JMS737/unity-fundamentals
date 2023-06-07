using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MeshAreaCalculator : MonoBehaviour
{
    public Mesh mesh;

    public float area;

    private void OnValidate()
    {
        if (mesh != null)
        {
            area = GetArea(mesh.vertices, mesh.triangles);
        }
    }

    private float GetArea(Vector3[] verts, int[] tris)
    {
        var meshArea = 0f;

        for (int i = 0; i < tris.Length; i += 3)
        {
            Vector3 a = verts[tris[i]];
            Vector3 b = verts[tris[i + 1]];
            Vector3 c = verts[tris[i + 2]];

            Vector3 ab = b - a;
            Vector3 ac = c - a;

            meshArea += Vector3.Cross(ab, ac).magnitude;
        }

        return meshArea / 2;
    }
}
