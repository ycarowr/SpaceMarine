using Patterns.GameEvents;
using SpaceMarine.Data;

namespace SpaceMarine.Model
{
    public class Door : IDoor
    {
        public Door(IRoom room, DoorData data)
        {
            Room = room;
            Data = data;
            Id = data.Id;
            Health = data.Health;
        }

        public IRoom Room { get; }
        public DoorId Id { get; }
        public DoorData Data { get; }
        public bool IsLocked { get; private set; }
        public bool IsDead { get; private set; }
        public int Health { get; private set; }

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

        public void Die()
        {
            GameEvents.Instance.Notify<GameEvent.IDestroyDoor>(i => i.OnDestroyDoor(this));
        }

        void EvaluateDeath()
        {
            IsDead = Health <= 0;
            if (IsDead)
                Die();
        }

        void OnTakeDamage(int damage)
        {
            GameEvents.Instance.Notify<GameEvent.IDoorTakeDamage>(i => i.OnTakeDamage(this, damage));
        }
    }
}