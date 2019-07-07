namespace SpaceMarine.Model
{
    public abstract class BaseGameMechanic
    {
        public IGame Game { get; }
        
        protected BaseGameMechanic(IGame game)
        {
            Game = game;
        }
    }
}