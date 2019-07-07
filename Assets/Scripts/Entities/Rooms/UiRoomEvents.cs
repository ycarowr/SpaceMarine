using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools.UI;
using UnityEngine;

namespace SpaceMarine.Rooms
{
    public class UiRoomEvents : UiGameEventListener, Events.IRoom
    {
        protected const float CameraSpeed = 3;
        protected const float CameraZ = -10;
        private UiRoom UiRoom { get; set; }
        public Transform CameraPosition;
        private UiMotion CameraMotion => GameCamera.Instance.Motion;

        private void Awake()
        {
            UiRoom = GetComponent<UiRoom>();
        }
        
        void Events.IRoom.OnEnterRoom(RoomId id)
        {
            if(UiRoom.RoomId == id)
                MoveCamera();
        }

        void Events.IRoom.OnLeaveRoom(RoomId id)
        {
            
        }
        
        [Button("MoveCameraHere")]
        private void MoveCamera()
        {
            CameraMotion.MoveToWithZ(CameraPosition.position, CameraSpeed, CameraZ);
        }

    }
}