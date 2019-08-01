using Patterns;
using Patterns.GameEvents;
using SpaceMarine.Model;

namespace SpaceMarine
{
    public class GameController : SingletonMB<GameController>, Events.ICreateGame, IListener
    {
        private IGameData GameData => SpaceMarine.GameData.Instance;
        private IGame Game => GameData?.Game;

        void Start()
        {
            GameEvents.Instance.AddListener(this);
        }

        private void StartGame()
        {
            Game.Attributes.StartGame();
        }

        private void EndGame()
        {
            Game.Attributes.EndGame();
        }

        public void OnCreateGame(IGame runtimeGame)
        {
            StartGame();
        }
    }
}