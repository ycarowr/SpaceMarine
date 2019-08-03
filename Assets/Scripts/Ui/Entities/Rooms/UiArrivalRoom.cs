namespace SpaceMarine.Rooms
{
    public class UiArrivalRoom : UiRoom
    {
        void Start()
        {
            UiCamera.Instance.Motion.Teleport(CameraPoint.transform.position);
        }
    }
}