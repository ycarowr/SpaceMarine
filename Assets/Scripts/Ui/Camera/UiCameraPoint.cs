using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMarine
{
    public class UiCameraPoint : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.4f);
        }
    }
}