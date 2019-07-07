using UnityEngine;

namespace SpaceMarine
{
    public class GroundFloor : BaseEntity
    {
        protected override void OnCollisionStayPlayer()
        {
            MyUiPlayer.Attributes.SetGrounded(true);
        }

        protected override void OnCollisionExitPlayer()
        {
            MyUiPlayer.Attributes.SetGrounded(false);
        }
    }
}