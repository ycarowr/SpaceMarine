using SpaceMarine.Model;

namespace SpaceMarine
{
    /// <summary>
    ///     Interface for the game data.
    /// </summary>
    public interface IGameData
    {
        
        IGame Game { get; }
        void CreateGame();
        void LoadGame();
    }
}