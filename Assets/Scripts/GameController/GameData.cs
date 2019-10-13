using SpaceMarine.Data;
using SpaceMarine.Model;
using Tools.Patterns.GameEvents;
using Tools.Patterns.Singleton;

namespace SpaceMarine
{
    /// <summary>
    ///     Realization of the game data interface.
    /// </summary>
    public class GameData : SingletonMB<GameData>, IGameData
    {
        /// <summary>
        ///     All the static data about the rooms.
        /// </summary>
        public RoomData[] Rooms;

        public IGame Game { get; private set; }

        public void CreateGame()
        {
            Game = new Game(Rooms);
            OnCreateGame();
        }

        public void LoadGame()
        {
            //TODO:
        }

        void Start() => CreateGame();

        void OnCreateGame() => GameEvents.Instance.Notify<GameEvent.ICreateGame>(i => i.OnCreateGame(Game));
    }
}