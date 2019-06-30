using UnityEngine;

namespace SpaceMarine.Rooms
{
    public class ArrivalRoom : Room
    {
        private void Start()
        {
            GameCamera.Instance.Motion.Teleport(CameraPosition.position);
        }
    }
}