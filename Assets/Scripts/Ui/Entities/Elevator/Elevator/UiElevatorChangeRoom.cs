using SpaceMarine.Model;
using Tools.Patterns.GameEvents;

namespace SpaceMarine
{
    public class UiElevatorChangeRoom : UiGameEventListener, GameEvent.IOnElevatorChangeRoom
    {
        UiElevator UiElevator { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        void GameEvent.IOnElevatorChangeRoom.OnChangeRoom(RoomId id)
        {
            UiElevator.CurrentRoom = id;
            UiElevator.ElevatorAnimations.GoTo(id);
        }

        protected override void Awake()
        {
            base.Awake();
            UiElevator = GetComponent<UiElevator>();
        }
    }
}