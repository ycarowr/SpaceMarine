using SpaceMarine.Data;
using Tools;
using UnityEngine;

namespace SpaceMarine.Rooms
{
    public class UiRoomGizmos : EditorComponent
    {
        readonly Vector3 gizmosDoorSize = new Vector3(0.4f, 3.5f);
        readonly Vector3 size = new Vector2(2, -2.3f);
        public RoomData Data;

        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            foreach (var doorSpot in Data?.Doors)
            {
                var position = (Vector3) doorSpot.Position;
                Gizmos.DrawCube(position + transform.position, gizmosDoorSize);
            }

            Gizmos.color = Color.red;
            foreach (var enemySpot in Data?.Enemies)
            {
                var position = (Vector3) enemySpot.Position;
                var rect = new Rect(position + transform.position - size / 2, size);
                Gizmos.DrawGUITexture(rect, enemySpot.Enemy.Icon);
                Gizmos.DrawWireSphere(position + transform.position, 0.2f);
            }
        }
    }
}