namespace SpaceMarine.Model
{
   
    public class ElevatorMechanics : BaseGameMechanic
    {
        public IElevatorControl ElevatorControl { get; }
        public ElevatorMechanics(IGame game) : base(game)
        {
            ElevatorControl = new ElevatorControl();
        }
    }
}