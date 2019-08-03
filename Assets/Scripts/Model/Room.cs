using System.Collections.Generic;
using SpaceMarine.Data;

namespace SpaceMarine.Model
{
    public class Room : IRoom
    {
        public Room(RoomData data)
        {
            Data = data;
            Id = data.Id;
            Enemies = new List<IEnemy>();
            Doors = new List<IDoor>();
        }

        public RoomData Data { get; }
        public RoomId Id { get; }
        public List<IEnemy> Enemies { get; }
        public List<IDoor> Doors { get; }

        public void AddEnemy(IEnemy enemy)
        {
            Enemies.Add(enemy);
        }

        public void AddDoor(IDoor door)
        {
            Doors.Add(door);
        }
    }
}