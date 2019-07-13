using Patterns.GameEvents;

namespace SpaceMarine.Model
{
    public class Elevator : IElevator
    {
        public bool IsLocked { get; private set; }
        
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

        void OnSwitch(bool isLocked)
        {
            GameEvents.Instance.Notify<Events.IElevatorControl>(i => i.OnSwitch(isLocked));
        }
    }
}