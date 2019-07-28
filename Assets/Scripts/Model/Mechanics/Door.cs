using Patterns.GameEvents;
using SpaceMarine.Data;

namespace SpaceMarine.Model
{
    public class Door : IDoor
    {
        public DoorId Id { get; private set; }
        public DoorData Data { get; private set; }
        public IRoom Room { get; private set; }
        public bool IsLocked { get; private set; }
        public bool IsDead { get; private set; }
        public int Health { get; private set; }


        public Door(IRoom room, DoorData data)
        {
            Room = room;
            Data = data;
            Id = data.Id;
            Health = data.Health;
        }
        
        public void Lock()
        {
            IsLocked = true;
        }

        public void UnLock()
        {
            IsLocked = false;
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
            GameEvents.Instance.Notify<Events.IDestroyDoor>(i => i.OnDestroyDoor(this));
        }

        void OnTakeDamage(int damage)
        {
            GameEvents.Instance.Notify<Events.IDoorTakeDamage>(i => i.OnTakeDamage(this, damage));
        }
    }
}