using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools.UI;
using UnityEngine;

namespace SpaceMarine.Rooms
{
    public class UiRoomEnter : UiGameEventListener, Events.IEnterRoom
    {
        //TODO: provide configurations for the values below.
        protected const float CameraSpeed = 3;
        protected const float CameraZ = -10;

        [Tooltip("Position of the camera in this room.")] [SerializeField]
        protected Transform CameraPosition;
        
        private UiRoom UiRoom { get; set; }
        
        private UiMotion CameraMotion => GameCamera.Instance.Motion;

        private void Awake()
        {
            UiRoom = GetComponent<UiRoom>();
        }
        
        void Events.IEnterRoom.OnEnterRoom(RoomId id)
        {
            if(UiRoom.RoomId == id)
                MoveCameraHere();
        }
        
        [Button]
        private void MoveCameraHere()
        {
            CameraMotion.Movement.StopMotion();
            CameraMotion.MoveToWithZ(CameraPosition.position, CameraSpeed, CameraZ);
        }
    }
}