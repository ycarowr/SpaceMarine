using UnityEngine;

namespace SpaceMarine
{
    public class DeathZone : BaseEntity
    {
        protected override void OnCollisionStayPlayer()
        {
            MyUiPlayer.Die();
        }

        protected override void OnCollisionExitPlayer()
        {
            MyUiPlayer.Die();
        }
    }
}