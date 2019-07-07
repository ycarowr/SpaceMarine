using System;
using System.Collections.Generic;
using Patterns.GameEvents;

namespace SpaceMarine.Model
{
    public interface IDoorMechanics
    {
        void CreateDoors();
        IDoor Get(DoorId id);
        void LockDoor(DoorId id);
        void UnLockDoor(DoorId id);
    }
    
    public class DoorMechanics : BaseGameMechanic, IDoorMechanics
    {
        public Dictionary<DoorId, IDoor> Doors { get; }
        public DoorMechanics(IGame game) : base(game)
        {
            Doors = new Dictionary<DoorId, IDoor>();
        }

        public void CreateDoors()
        {
            
        }

        public IDoor Get(DoorId id)
        {
            return Doors?[id];
        }

        public void LockDoor(DoorId id)
        {
            var door = Get(id);
            door?.Lock();
            OnSwitchDoor(door);
        }

        public void UnLockDoor(DoorId id)
        {
            var door = Get(id);
            door?.UnLock();
            OnSwitchDoor(door);
        }

        
        void OnSwitchDoor(IDoor door)
        {
            GameEvents.Instance.Notify<Events.IDoors>(i => i.OnSwitchDoor(door));
        }
    }
}