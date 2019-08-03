using UnityEngine;

namespace SpaceMarine.Rooms
{
    public class UiArrivalRoom : UiRoom
    {   
        private void Start()
        {
            UiCamera.Instance.Motion.Teleport(CameraPoint.transform.position);
        }
    }
}