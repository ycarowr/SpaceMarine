using SpaceMarine.Model;

namespace SpaceMarine
{
    /// <summary>
    ///     Interface for the game data.
    /// </summary>
    public interface IGameData
    {
        IGame RuntimeGame { get; }
        void CreateGame();
        void LoadGame();
    }
}