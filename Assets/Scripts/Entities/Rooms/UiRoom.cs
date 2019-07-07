using SpaceMarine.Model;
using Tools.UI;
using UnityEngine;

namespace SpaceMarine.Rooms
{
    public class UiRoom : BaseEntity
    {
        private IRoomMechanics Room => GameData.Instance.RuntimeGame.RoomMechanics;
        protected const float CameraSpeed = 3;
        protected const float CameraZ = -10;
        public RoomId RoomId;
                
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