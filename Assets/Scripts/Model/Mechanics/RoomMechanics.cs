using System.Collections.Generic;

namespace SpaceMarine.Model
{
    public class Room : IRoom
    {
        public RoomId Id { get; }
        public List<IEnemy> Enemies { get; } 
        public List<IDoor> Doors { get; }

        public Room()
        {
            Enemies = new List<IEnemy>();
            Doors = new List<IDoor>();
        }
    }

    
    public interface IRoomMechanics
    {
        void CreateRooms();
        IRoom Get(RoomId id);
        void PlayerEnter(RoomId id);
        void PlayerLeave(RoomId id);
    }
    
    public class RoomMechanics : BaseGameMechanic, IRoomMechanics
    {
        public Dictionary<RoomId, IRoom> Rooms { get; }
        
        public RoomMechanics(IGame game) : base(game)
        {
            Rooms = new Dictionary<RoomId, IRoom>();
        }

        public void CreateRooms()
        {
            
        }

        public IRoom Get(RoomId id)
        {
            return Rooms?[id];
        }

        public void PlayerEnter(RoomId id)
        {
            var room = Get(id);
            Game.Player.EnterRoom(id);
        }

        public void PlayerLeave(RoomId id)
        {
            Game.Player.LeaveRoom(id);
        }
    }
}