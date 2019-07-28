using Patterns.GameEvents;
using SpaceMarine.Model;

namespace SpaceMarine.Data
{
    public abstract class RuntimeEnemy : IEnemy
    {
        public EnemyId Id { get; }
        public EnemyData Data { get; }
        public bool IsDead { get; private set; }
        public int Health { get; private set; }
        
        protected RuntimeEnemy(EnemyData data)
        {
            Data = data;
            Id = data.Id;
            Health = data.Health;
        }
        
        public void TakeDamage(int amount)
        {
            Health -= amount;
            OnTakeDamage(amount);
            EvaluateDeath();
        }

        private void EvaluateDeath()
        {
            IsDead = Health <= 0;
            if(IsDead)
                Die();
        }

        public void Die()
        {
//            GameEvents.Instance.Notify<Events.IDestroyDoor>(i => i.OnDestroyDoor(this));
        }

        void OnTakeDamage(int damage)
        {
//            GameEvents.Instance.Notify<Events.IDoorTakeDamage>(i => i.OnTakeDamage(this, damage));
        }
    }
}