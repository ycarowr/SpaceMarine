using UnityEngine;

namespace SpaceMarine
{
    public class UiGroundFloor : UiBaseEntity
    {
        protected override void OnCollisionStayPlayer()
        {
            MyUiPlayer.Attributes.SetGrounded(true);
        }

        protected override void OnCollisionExitPlayer()
        {
            MyUiPlayer.Attributes.SetGrounded(false);
        }
        
        void OnDrawGizmos()
        {
            const float sphereSize = 0.1f;
            Gizmos.color = Color.cyan;
            var collider2d = GetComponent<Collider2D>();
            var highestPointY = collider2d.bounds.max.y;
            var highestPointX = collider2d.bounds.max.x;
            var lowestPointX = collider2d.bounds.min.x;
            var from = new Vector3(lowestPointX, highestPointY);
            var to = new Vector3(highestPointX, highestPointY);
            Gizmos.DrawLine(from, to);
            Gizmos.DrawSphere(from, sphereSize);
            Gizmos.DrawSphere(to, sphereSize);
        }
    }
}