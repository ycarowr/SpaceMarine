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
    }
}