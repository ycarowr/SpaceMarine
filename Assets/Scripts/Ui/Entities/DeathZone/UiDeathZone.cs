using UnityEngine;

namespace SpaceMarine
{
    public class UiDeathZone : UiBaseEntity
    {
        protected override void OnTriggerEnterPlayer()
        {
            GameController.Instance.Player.Die();
        }
    }
}