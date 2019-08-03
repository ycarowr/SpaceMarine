using System.Collections.Generic;
using Patterns;
using SpaceMarine.Model;
using SpaceMarine.Rooms;

namespace SpaceMarine
{
    public class UiRoomsRegister : SingletonMB<UiRoomsRegister>
    {
        Dictionary<RoomId, UiRoom> Rooms { get; } = new Dictionary<RoomId, UiRoom>();

        protected override void OnAwake()
        {
            var rooms = GetComponentsInChildren<UiRoom>();
            foreach (var room in rooms)
                AddRoom(room.RoomId, room);
        }


        public UiRoom Get(RoomId id)
        {
            return Rooms?[id];
        }

        public void AddRoom(RoomId id, UiRoom room)
        {
            if (Rooms.ContainsKey(id))
                return;

            Rooms?.Add(room.RoomId, room);
        }
    }
}