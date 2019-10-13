using SpaceMarine.Model;
using Tools.Patterns.GameEvents;
using Tools.Patterns.Observer;
using Tools.Patterns.Singleton;

namespace SpaceMarine
{
    public class GameController : SingletonMB<GameController>, GameEvent.ICreateGame, IListener
    {
        IGameData GameData => SpaceMarine.GameData.Instance;
        IGame Game => GameData?.Game;

        public void OnCreateGame(IGame runtimeGame) => StartGame();

        protected override void OnAwake() => GameEvents.Instance.AddListener(this);

        void StartGame() => Game.Attributes.StartGame();

        void EndGame() => Game.Attributes.EndGame();
    }
}