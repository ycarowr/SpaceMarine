using UnityEngine;

namespace SpaceMarine.Rooms
{
    public class Room : BaseEntity
    {
        [SerializeField] protected string Name;
        [SerializeField] protected Transform CameraPosition;
        protected const float CameraSpeed = 3;
        
        
        protected override void OnTriggerEnterPlayer()
        {
            MoveCamera();
        }

        protected override void OnTriggerExitPlayer()
        {
            
        }

        [Button("MoveCameraHere")]
        private void MoveCamera()
        {
            GameCamera.Instance.Motion.MoveToWithZ(CameraPosition.position, CameraSpeed, -10);
        }
    }
}