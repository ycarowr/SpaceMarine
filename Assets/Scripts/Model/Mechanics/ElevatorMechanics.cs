using Tools.Patterns.GameEvents;

namespace SpaceMarine.Model
{
    public class ElevatorMechanics : BaseGameMechanic
    {
        public ElevatorMechanics(IGame game) : base(game) => Elevator = new Elevator();

        public IElevator Elevator { get; }

        public void PlayerEmbark() => Game.Player.IsInsideElevator = true;

        public void PlayerDisembark() => Game.Player.IsInsideElevator = false;

        public void GoTo(RoomId id)
        {
            Elevator.GoTo(id);
            PlayerEmbark();
        }

        //--------------------------------------------------------------------------------------------------------------

        void OnEmbark() => GameEvents.Instance.Notify<GameEvent.IPlayerEmbark>(i => i.OnEmbark(Elevator, Game.Player));

        void OnDisembark() =>
            GameEvents.Instance.Notify<GameEvent.IPlayerDisembark>(i => i.OnDisembark(Elevator, Game.Player));
    }
}