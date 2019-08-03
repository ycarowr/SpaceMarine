using Patterns.GameEvents;

namespace SpaceMarine.Model
{
    public class Elevator : IElevator
    {
        public bool IsLocked { get; private set; }
        public RoomId CurrentRoom { get; private set; } = RoomId.Elevator0;
        
        public void Lock()
        {
            IsLocked = true;
            OnSwitch(IsLocked);
        }

        public void UnLock()
        {
            IsLocked = false;
            OnSwitch(IsLocked);
        }

        public void Switch()
        {
            IsLocked = !IsLocked;
            OnSwitch(IsLocked);
        }

        public void GoTo(RoomId id)
        {
            CurrentRoom = id;
            OnChangeRoom();
        }

        void OnSwitch(bool isLocked)
        {
            GameEvents.Instance.Notify<GameEvent.IOnSwitchElevator>(i => i.OnSwitch(isLocked));
        }

        void OnChangeRoom()
        {
            GameEvents.Instance.Notify<GameEvent.IOnElevatorChangeRoom>(i => i.OnChangeRoom(CurrentRoom));
        }
    }
}