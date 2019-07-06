using System;

namespace SpaceMarine
{
    public class Death
    {
        public static event Action OnDie = () => { };
        private IPlayer Player { get; }

        
        public Death(IPlayer player)
        {
            Player = player;
        }

        public void Die()
        {
            Player.Attributes.IsDead = true;
            OnDie.Invoke();
        }
    }
}