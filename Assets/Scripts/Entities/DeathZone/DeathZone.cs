using UnityEngine;

namespace SpaceMarine
{
    public class DeathZone : BaseEntity
    {
        protected override void OnCollisionStayPlayer()
        {
            MyPlayer.Die();
        }

        protected override void OnCollisionExitPlayer()
        {
            MyPlayer.Die();
        }
    }
}