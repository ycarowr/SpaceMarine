using Tools;
using UnityEngine;

namespace SpaceMarine
{
    public class UiCameraPointGizmos : EditorComponent
    {
        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.4f);
        }
    }
}