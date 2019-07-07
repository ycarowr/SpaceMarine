using UnityEngine;

namespace SpaceMarine.Rooms
{
    public class ArrivalUiRoom : UiRoom
    {
        private void Start()
        {
            var position = GameCamera.Instance.transform.position;
            GameCamera.Instance.Motion.Teleport(position);
        }
    }
}