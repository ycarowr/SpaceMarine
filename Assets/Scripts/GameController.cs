using Patterns;
using SpaceMarine.Model;

namespace SpaceMarine
{
    public class GameController : SingletonMB<GameController>
    {
        private IGameData GameData => SpaceMarine.GameData.Instance;
        private IGame Game => GameData?.Game;

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