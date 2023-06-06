using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransform : MonoBehaviour
{
    public Vector2 localSpacePoint;
    public Vector2 worldSpacePoint;
    public Transform localObjTransform;

    private void OnDrawGizmos()
    {
        Vector2 spacePosition = transform.position;
        Vector2 spaceRight = transform.right;
        Vector2 spaceUp = transform.up;

        /*
         * To convert from a local Vector value to it's world Vector you need to:
         *  - Multiple the basis axis vectors (i.e. x, y (and z)) of your local space, by the local x and y components of your local vector.
         *      - This will give you two world space vectors that can be added up to create the world space vector from the local origin to the point.
         *  - Then simply add this onto the position of the local space to get the world space of your point.
         */
        Vector2 LocalToWorld(Vector2 localPt)
        {
            return spacePosition + localPt.x * spaceRight + localPt.y * spaceUp;
        }

        /*
         * To convert from world space to local space you need to do the reverse.
         *  - First subtract the local space position from your point (you can think of this as aligning the two spaces positionally)
         *  - Then to solve the rotational differences, you want to project the resultant vector onto the two basis axis vectors of your local space.
         *      - You can do this using the Dot product.
         *  - The two values you get from the x and y basis vectors of your local space will be the local x and y components respectively.
         */
        Vector2 WorldToLocal(Vector2 worldPt)
        {
            Vector2 worldOffset = worldPt - spacePosition;
            return new Vector2(
                Vector2.Dot(spaceRight, worldOffset),
                Vector2.Dot(spaceUp, worldOffset));
        }

        DrawBasisVectors(transform.position, transform.right, transform.up);
        DrawBasisVectors(Vector2.zero, Vector2.right, Vector2.up);

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(LocalToWorld(localSpacePoint), 0.1f);


        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(worldSpacePoint, 0.1f);

        var localWorldPos = WorldToLocal(worldSpacePoint);
        localObjTransform.localPosition = localWorldPos;
    }

    void DrawBasisVectors(Vector2 pos, Vector2 right, Vector2 up)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(pos, pos + right);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pos, pos + up);
        Gizmos.color = Color.white;
    }
}
