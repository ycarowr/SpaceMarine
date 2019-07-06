using UnityEngine;

namespace SpaceMarine
{
    public class GroundFloor : BaseEntity
    {
        protected override void OnCollisionStayPlayer()
        {
            MyPlayer.Attributes.SetGrounded(true);
        }

        protected override void OnCollisionExitPlayer()
        {
            MyPlayer.Attributes.SetGrounded(false);
        }
    }
}