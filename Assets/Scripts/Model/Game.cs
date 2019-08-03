using SpaceMarine.Data;

namespace SpaceMarine.Model
{
    /// <summary>
    ///     Concrete game class.
    /// </summary>
    public class Game : IGame
    {
        public Game(RoomData[] roomData)
        {
            EnemyMechanics = new EnemyMechanics(this);
            DoorsMechanics = new DoorMechanics(this);
            RoomMechanics = new RoomMechanics(this, roomData);
            ElevatorMechanics = new ElevatorMechanics(this);
            Attributes = new GameAttributes(this);
            Player = new PlayerMechanics(this);
        }

        #region Mechanics

        public IPlayer Player { get; }
        public ElevatorMechanics ElevatorMechanics { get; }
        public IRoomMechanics RoomMechanics { get; }
        public EnemyMechanics EnemyMechanics { get; }
        public IDoorMechanics DoorsMechanics { get; }
        public GameAttributes Attributes { get; }

        #endregion
    }
}