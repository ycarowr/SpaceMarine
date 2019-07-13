using SpaceMarine.Model;
using Tools.UI;
using UnityEngine;

namespace SpaceMarine.Rooms
{
    public class UiRoom : BaseEntity
    {
        [Tooltip("The id of this room.")]
        public RoomId RoomId;
        
        private IRoomMechanics Room => GameController.Instance.Game.RoomMechanics;
        
                
        protected override void OnTriggerEnterPlayer()
        {
            Room.PlayerEnter(RoomId);
        }

        protected override void OnTriggerExitPlayer()
        {
            Room.PlayerLeave(RoomId);
        }
    }
}