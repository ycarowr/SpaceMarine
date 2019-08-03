using Patterns;
using Patterns.GameEvents;
using SpaceMarine.Model;

namespace SpaceMarine
{
    public class GameController : SingletonMB<GameController>, GameEvent.ICreateGame, IListener
    {
        IGameData GameData => SpaceMarine.GameData.Instance;
        IGame Game => GameData?.Game;

        public void OnCreateGame(IGame runtimeGame)
        {
            StartGame();
        }

        void Start()
        {
            GameEvents.Instance.AddListener(this);
        }

        void StartGame()
        {
            Game.Attributes.StartGame();
        }

        void EndGame()
        {
            Game.Attributes.EndGame();
        }
    }
}