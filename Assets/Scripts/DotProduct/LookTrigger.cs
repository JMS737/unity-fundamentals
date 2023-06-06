using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTrigger : MonoBehaviour
{
    public Transform target;

    [Range(0f, 1f)]
    public float Threshold = 0.95f;

    bool IsLookingAtObject()
    {
        if (target == null) return false;
        var directionToObject = (target.position - transform.position).normalized;

        var playerDirection = transform.up;
        return Vector3.Dot(directionToObject, playerDirection) >= Threshold;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (IsLookingAtObject())
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawSphere(transform.position + Vector3.down, 0.1f);
    }
}
