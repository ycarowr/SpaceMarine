using System.Collections.Generic;
using Tools.Patterns.GameEvents;

namespace SpaceMarine.Model
{
    public interface IDoorMechanics
    {
        bool HasQuickFirstDoor { get; }
        void CreateDoors(IRoom room);
        IDoor Get(DoorId id);
        void LockDoor(DoorId id);
        void UnLockDoor(DoorId id);
    }

    public class DoorMechanics : BaseGameMechanic, IDoorMechanics
    {
        public DoorMechanics(IGame game) : base(game) => Doors = new Dictionary<DoorId, IDoor>();

        public Dictionary<DoorId, IDoor> Doors { get; }
        public bool HasQuickFirstDoor { get; private set; }

        public void CreateDoors(IRoom room)
        {
            if (room.Data.Doors == null)
                return;

            if (room.Data.Doors.Length < 1)
                return;

            foreach (var data in room.Data.Doors)
            {
                var door = new Door(room, data.Door);
                room.AddDoor(door);
            }
        }

        public IDoor Get(DoorId id) => Doors?[id];

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

        public void QuickFirstDoor()
        {
            HasQuickFirstDoor = true;
            OnQuickFirstDoor();
        }

        //--------------------------------------------------------------------------------------------------------------

        void OnQuickFirstDoor() => GameEvents.Instance.Notify<GameEvent.IQuickFirstDoor>(i => i.OnQuickFirstDoor());

        void OnSwitchDoor(IDoor door) => GameEvents.Instance.Notify<GameEvent.IDoors>(i => i.OnSwitchDoor(door));
    }
}