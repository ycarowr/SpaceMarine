using Tools.EditorComponent;
using UnityEngine;

namespace SpaceMarine.Rooms
{
    [ExecuteInEditMode]
    public class UiRoomCollisionBinder : EditorComponent
    {
        public enum BoundEdge
        {
            Bottom,
            Top,
            Left,
            Right
        }

        public BoundEdge Bound;

        Collider2D Room { get; set; }
        Bounds RoomBounds => Room.bounds;
        EdgeCollider2D Ground { get; set; }

        void Awake()
        {
            Ground = GetComponent<EdgeCollider2D>();
            var room = transform.parent.GetComponentInChildren<UiRoom>();
            Room = room.GetComponent<Collider2D>();
        }

        void Update()
        {
            BindPositions();
            GeneratePoins();
        }

        void GeneratePoins()
        {
            var delta = 0f;
            var x = new Vector2();
            var y = new Vector2();

            if (Bound == BoundEdge.Top || Bound == BoundEdge.Bottom)
            {
                delta = RoomBounds.size.x / 2;
                x = new Vector2(-delta, 0);
                y = new Vector2(delta, 0);
            }
            else
            {
                delta = RoomBounds.size.y / 2;
                x = new Vector2(0, delta);
                y = new Vector2(0, -delta);
            }

            Ground.points = new[] {x, y};
        }

        void BindPositions()
        {
            Ground.offset = Vector3.zero;
            Ground.transform.localScale = Vector3.one;
            var offset = new Vector3();
            switch (Bound)
            {
                case BoundEdge.Bottom:
                    offset = new Vector3(0, -RoomBounds.size.y / 2);
                    break;
                case BoundEdge.Top:
                    offset = new Vector3(0, RoomBounds.size.y / 2);
                    break;
                case BoundEdge.Left:
                    offset = new Vector3(-RoomBounds.size.x / 2, 0);
                    break;
                case BoundEdge.Right:
                    offset = new Vector3(RoomBounds.size.x / 2, 0);
                    break;
            }

            Ground.transform.position = Room.transform.position + offset;
        }

        void OnDrawGizmos()
        {
            const float sphereSize = 0.1f;
            Gizmos.color = Color.cyan;
            var edge = GetComponent<EdgeCollider2D>();
            var from = edge.points[0] + (Vector2) transform.position;
            var to = edge.points[1] + (Vector2) transform.position;
            Gizmos.DrawLine(from, to);
            Gizmos.DrawSphere(from, sphereSize);
            Gizmos.DrawSphere(to, sphereSize);
        }
    }
}