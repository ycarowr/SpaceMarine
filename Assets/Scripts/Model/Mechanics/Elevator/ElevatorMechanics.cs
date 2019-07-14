using Patterns.GameEvents;

namespace SpaceMarine.Model
{
   
    public class ElevatorMechanics : BaseGameMechanic
    {
        public IElevator Elevator { get; }
        
        
        public ElevatorMechanics(IGame game) : base(game)
        {
            Elevator = new Elevator();
        }

        public void PlayerEmbark()
        {
            Game.Player.IsInsideElevator = true;
        }

        public void PlayerDisembark()
        {
            Game.Player.IsInsideElevator = false;
        }
        
        public void GoTo(RoomId id)
        {
            Elevator.GoTo(id);
            PlayerEmbark();
        }
        
        //--------------------------------------------------------------------------------------------------------------

        void OnEmbark()
        {
            GameEvents.Instance.Notify<Events.IPlayerEmbark>(i => i.OnEmbark(Elevator, Game.Player));
        }
        
        void OnDisembark()
        {
            GameEvents.Instance.Notify<Events.IPlayerDisembark>(i => i.OnDisembark(Elevator, Game.Player));
        }
        
    }
}