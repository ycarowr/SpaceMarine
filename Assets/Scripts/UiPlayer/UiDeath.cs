using System;

namespace SpaceMarine
{
    public class UiDeath
    {
        public static event Action OnDie = () => { };
        private IUiPlayer UiPlayer { get; }

        
        public UiDeath(IUiPlayer uiPlayer)
        {
            UiPlayer = uiPlayer;
        }

        public void Die()
        {
            UiPlayer.Attributes.IsDead = true;
            OnDie.Invoke();
        }
    }
}