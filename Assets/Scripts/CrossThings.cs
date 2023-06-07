using UnityEngine;

public class CrossThings : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        var position = transform.position;
        var lookDir = transform.forward;

        if (Physics.Raycast(position, lookDir, out var hit))
        {
            Vector3 hitPos = hit.point;
            
            Gizmos.color = Color.white;
            Gizmos.DrawLine(position, hitPos);
            
            Vector3 up = hit.normal;
            Vector3 right = Vector3.Cross(up, lookDir).normalized;
            Vector3 forward = Vector3.Cross(right, up);

            Matrix4x4 turretToWorld = Matrix4x4.TRS(hitPos, Quaternion.LookRotation(forward, up), Vector3.one);

            // Set a matrix to be applied to any points drawn by Gizmos after this point.
            // This is like applying `turretToWorld.MultiplyPoint3x4(point)` to all points you're trying to draw.
            Gizmos.matrix = turretToWorld;

            void DrawBoundingBox()
            {
                Vector3[] pts = new Vector3[]
                {
                    new Vector3(1, 0, 1),
                    new Vector3(-1, 0, 1),
                    new Vector3(-1, 0, -1),
                    new Vector3(1, 0, -1),
                    new Vector3(1, 2, 1),
                    new Vector3(-1, 2, 1),
                    new Vector3(-1, 2, -1),
                    new Vector3(1, 2, -1)
                };

                Gizmos.color = Color.red;

                for (int i = 0; i < pts.Length; i++)
                {
                    Gizmos.DrawSphere(pts[i], 0.05f);
                }
            }

            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, Vector3.right);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(Vector3.zero, Vector3.up);
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(Vector3.zero, Vector3.forward);

            DrawBoundingBox();

            Gizmos.matrix = Matrix4x4.identity;
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(position, lookDir);
        }
    }
}
