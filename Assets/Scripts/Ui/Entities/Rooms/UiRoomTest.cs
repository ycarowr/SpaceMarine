using Patterns.GameEvents;
using SpaceMarine.Data;
using SpaceMarine.Model;
using Tools.UI;
using UnityEngine;

namespace SpaceMarine.Rooms
{
    public class UiRoomTest : MonoBehaviour
    {
        public RoomData Data;
        readonly Vector3 gizmosDoorSize = new Vector3(0.4f, 3.5f);
        const float gizmosEnemySize = 0.4f;
        
        void OnEnable()
        {
            if(!Application.isEditor)
                Destroy(gameObject);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            foreach (var doorSpot in Data?.Doors)
            {
                var position = (Vector3)doorSpot.Position;
                Gizmos.DrawCube(position + transform.position, gizmosDoorSize);
            }
            
            Gizmos.color = Color.red;
            foreach (var enemySpot in Data?.Enemies)
            {
                var position = (Vector3)enemySpot.Position;
                Gizmos.DrawWireSphere(position + transform.position, gizmosEnemySize);
            }
        }
    }
}