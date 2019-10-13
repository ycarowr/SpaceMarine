using Tools.EditorComponent;
using UnityEngine;

namespace SpaceMarine
{
    public class UiCameraPointGizmos : EditorComponent
    {
        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 0.4f);
        }
    }
}