using System.Collections.Generic;
using Patterns.GameEvents;
using SpaceMarine.Data;
using UnityEngine;

namespace SpaceMarine.Model
{
    public class RoomMechanics : BaseGameMechanic, IRoomMechanics
    {
        public Dictionary<RoomId, IRoom> Rooms { get; }
        
        public RoomMechanics(IGame game, RoomData[] roomData) : base(game)
        {
            Rooms = new Dictionary<RoomId, IRoom>();
            CreateRooms(roomData);
        }

        public void CreateRooms(RoomData[] roomData)
        {
            foreach (var data in roomData)
            {
                var id = data.Id;
                var room = new Room(data);
                Rooms.Add(id, room);
                Game.DoorsMechanics.CreateDoors(room);
                Game.EnemyMechanics.CreateEnemies(room);
            }
        }

        public IRoom Get(RoomId id)
        {
            return Rooms?[id];
        }

        public void PlayerEnter(RoomId id)
        {
            Game.Player.EnterRoom(id);
        }

        public void PlayerLeave(RoomId id)
        {
            Game.Player.LeaveRoom(id);
        }
    }
}