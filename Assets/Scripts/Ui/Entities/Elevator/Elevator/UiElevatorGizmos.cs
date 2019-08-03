using Tools;
using UnityEngine;

namespace SpaceMarine
{
    public class UiElevatorGizmos : EditorComponent
    {
        UiElevator UiElevator { get; set; }

        void Awake()
        {
            UiElevator = GetComponent<UiElevator>();
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            foreach(var s in UiElevator.uiElevatorStops)
                Gizmos.DrawCube(s.Position.position, Vector3.one * 0.5f);

            for (var i = 1; i < UiElevator.uiElevatorStops.Length; i++)
            {
                var from = UiElevator.uiElevatorStops[i - 1].Position.position;
                var to = UiElevator.uiElevatorStops[i].Position.position;
                Gizmos.DrawLine(from, to);
            }
        }
    }
}