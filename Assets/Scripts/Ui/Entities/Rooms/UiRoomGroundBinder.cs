using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Patterns;
using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools.UI;
using UnityEngine;

namespace SpaceMarine.Rooms
{
    [ExecuteInEditMode]
    public class UiRoomGroundBinder : MonoBehaviour
    {
        private Collider2D Room { get; set; }
        private EdgeCollider2D Ground { get; set; }

        private void OnEnable()
        {
            Room = GetComponent<Collider2D>();
            var ground = transform.parent.GetComponentInChildren<UiGroundFloor>();
            Ground = ground.GetComponent<EdgeCollider2D>();
        }

        void Update()
        {
            BindGroundAccordingRoom();
        }

        void BindGroundAccordingRoom()
        {
            var offsetY = new Vector3(0, 0.15f);
            var roomBounds = Room.bounds;
            var roomMaxX = roomBounds.max.x;
            var roomMinX = roomBounds.min.x;
            var roomMinY = roomBounds.min.y;
            var groundBounds = Ground.bounds;
            var boundMin = roomBounds.center - new Vector3(roomMinX, roomMinY);
            var boundMax = roomBounds.center - new Vector3(roomMaxX, roomMinY);
            
            Ground.transform.localScale = Vector3.one;
            Ground.transform.position = Room.transform.position - new Vector3(0, roomBounds.size.y / 2) - offsetY;
            Ground.offset = Vector3.zero;            
            Ground.points = new Vector2[]{new Vector2(-roomBounds.size.x/2, 0), new Vector2(roomBounds.size.x/2, 0)};
        }
    }
}