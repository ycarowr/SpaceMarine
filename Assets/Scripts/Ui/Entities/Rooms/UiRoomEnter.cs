using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools.UI;

namespace SpaceMarine.Rooms
{
    public class UiRoomEnter : UiGameEventListener, GameEvent.IEnterRoom
    {
        //TODO: provide configurations for the values below.
        protected const float CameraSpeed = 3;
        protected const float CameraZ = -10;

        UiRoom UiRoom { get; set; }

        UiMotion CameraMotion => UiCamera.Instance.Motion;

        void GameEvent.IEnterRoom.OnEnterRoom(RoomId id)
        {
            if (UiRoom.RoomId == id)
                MoveCameraHere();
        }

        protected override void Awake()
        {
            base.Awake();
            UiRoom = GetComponent<UiRoom>();
        }

        [Button]
        void MoveCameraHere()
        {
            var cameraPoint = UiRoom.CameraPoint.transform.position;
            CameraMotion.Movement.StopMotion();
            CameraMotion.MoveToWithZ(cameraPoint, CameraSpeed, CameraZ);
        }
    }
}