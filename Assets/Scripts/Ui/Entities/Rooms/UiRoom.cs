using System.Linq;
using SpaceMarine.Model;
using Tools.Patterns.GameEvents;
using Tools.Patterns.Observer;
using UnityEngine;

namespace SpaceMarine.Rooms
{
    public class UiRoom : UiBaseEntity, IListener, GameEvent.ICreateGame
    {
        [Tooltip("The id of this room.")] public RoomId RoomId;

        IRoom Room { get; set; }
        IRoomMechanics RoomMechanics => GameData.Instance.Game.RoomMechanics;
        public UiCameraPoint CameraPoint { get; private set; }

        //--------------------------------------------------------------------------------------------------------------

        public void OnCreateGame(IGame game)
        {
            Room = game.RoomMechanics.Get(RoomId);
            CreateUiDoors();
            CreateUiEnemies();
        }


        protected override void Awake()
        {
            base.Awake();
            GameEvents.Instance.AddListener(this);
            CameraPoint = GetComponentInChildren<UiCameraPoint>();
        }

        protected override void OnTriggerEnterPlayer() => RoomMechanics.PlayerEnter(RoomId);

        protected override void OnTriggerExitPlayer() => RoomMechanics.PlayerLeave(RoomId);

        void CreateUiEnemies()
        {
            foreach (var enemy in Room.Enemies)
            {
                var id = enemy.Id;
                var prefab = enemy.Data.Model;
                var uiEnemyGo = UiObjectsPooler.Instance.Get(prefab);
                var uiEnemy = uiEnemyGo.GetComponent<UiEnemy>();
                uiEnemy.Id = id;
                uiEnemy.Enemy = enemy;
                uiEnemy.transform.SetParent(transform.parent);
                uiEnemy.transform.localPosition = enemy.StartLocalPosition;
                uiEnemy.Initialize(enemy);
            }
        }

        void CreateUiDoors()
        {
            foreach (var door in Room.Doors)
            {
                var id = door.Id;
                var prefab = door.Data.Model;
                var uiDoorGo = UiObjectsPooler.Instance.Get(prefab);
                var uiDoor = uiDoorGo.GetComponent<UiDoor>();
                var pair = Room.Data.Doors.ToList().Find(x => x.Door.Id == id);
                uiDoor.Id = id;
                uiDoor.Door = door;
                uiDoor.transform.SetParent(transform.parent);
                uiDoor.transform.localPosition = pair.Position;
            }
        }
    }
}