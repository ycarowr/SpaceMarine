using Patterns;
using SpaceMarine.Model;

namespace SpaceMarine
{
    public class GameController : SingletonMB<GameController>
    {
        public IGameData GameData => SpaceMarine.GameData.Instance;
        public IGame Game => GameData?.RuntimeGame;
        public IPlayer Player => GameData?.RuntimeGame.Player;

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            Game.Attributes.StartGame();
        }

        private void EndGame()
        {
            Game.Attributes.EndGame();
        }
    }
}