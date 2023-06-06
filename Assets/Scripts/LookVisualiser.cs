using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookVisualiser : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position + gameObject.transform.up * 3);
    }
}
