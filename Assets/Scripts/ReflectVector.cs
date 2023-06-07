using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectVector : MonoBehaviour
{
    public Vector3 worldPoint;

    private void OnDrawGizmos()
    {
        var normal = transform.up;
        var hitPosition = transform.position;

        /*
         * Calculate the reflected direction by projecting the ray direction onto the normal axis to give us a component vector
         * of the ray direction in terms of the normal. I.e. Dot(normal, direction) to get a scalar and multiple this by the normal vector of the "hit".
         * 
         * If you were to subtract this vector from the direction (magenta line) twice it will result in the reflected ray direction.
         */
        Vector3 Reflect(Vector3 direction, Vector3 normal)
        {
            return hitPosition + direction - 2 * Vector3.Dot(normal, direction) * normal;
        }

        // We only need to ray direction to calculate the reflected direction with this method.
        var rayDirection = (hitPosition - worldPoint).normalized;

        // Reflect the direction around the normal.
        var reflectedWorldPoint = Reflect(rayDirection, normal);

        // Draw the originating point.
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(worldPoint, 0.1f);

        // Draw the surface
        Gizmos.color = Color.white;
        Gizmos.DrawLine(hitPosition - transform.right, hitPosition + transform.right);

        // Draw the normal
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(hitPosition, hitPosition + normal);

        // Draw the incident ray
        Gizmos.color = Color.grey;
        Gizmos.DrawLine(worldPoint, hitPosition);

        // Draw the direction in the context of the hit.
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(hitPosition, hitPosition + rayDirection);

        // Draw the reflected point and ray
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(reflectedWorldPoint, 0.1f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(hitPosition, reflectedWorldPoint);


    }
}
