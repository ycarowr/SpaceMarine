namespace SpaceMarine.Model
{
    public abstract class BaseGameMechanic
    {
        protected BaseGameMechanic(IGame game)
        {
            Game = game;
        }

        public IGame Game { get; }
    }
}