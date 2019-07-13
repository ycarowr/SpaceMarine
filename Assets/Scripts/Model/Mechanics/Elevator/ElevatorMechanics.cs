namespace SpaceMarine.Model
{
   
    public class ElevatorMechanics : BaseGameMechanic
    {
        public IElevator Elevator { get; }
        
        
        public ElevatorMechanics(IGame game) : base(game)
        {
            Elevator = new Elevator();
        }
    }
}