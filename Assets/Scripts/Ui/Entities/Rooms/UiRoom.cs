using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using Patterns;
using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools.UI;
using UnityEngine;

namespace SpaceMarine.Rooms
{
    public class UiRoom : UiBaseEntity, IListener, GameEvent.ICreateGame
    {
        private IRoomMechanics RoomMechanics => GameData.Instance.Game.RoomMechanics;
        public UiCameraPoint CameraPoint { get; private set; }

        [Tooltip("The id of this room.")]
        public RoomId RoomId;

        private IRoom Room { get; set; }

        protected override void Awake()
        {
            base.Awake();
            GameEvents.Instance.AddListener(this);
            CameraPoint = GetComponentInChildren<UiCameraPoint>();
        }

        protected override void OnTriggerEnterPlayer()
        {
            RoomMechanics.PlayerEnter(RoomId);
        }

        protected override void OnTriggerExitPlayer()
        {
            RoomMechanics.PlayerLeave(RoomId);
        }
        
        //--------------------------------------------------------------------------------------------------------------

        public void OnCreateGame(IGame game)
        {
            Room = game.RoomMechanics.Get(RoomId);
            CreateUiDoors();
            CreateUiEnemies();
        }

        private void CreateUiEnemies()
        {
            foreach (var enemy in Room.Enemies)
            {
                var id = enemy.Id;
                var prefab = enemy.Data.Model;
                var uiEnemyGo = UiObjectsPooler.Instance.Get(prefab);
                var uiEnemy = uiEnemyGo.GetComponent<UiEnemy>();
                var pair = Room.Data.Enemies.ToList().Find(x => x.Enemy.Id == id);    
                uiEnemy.Id = id;
                uiEnemy.Enemy = enemy; 
                uiEnemy.transform.SetParent(transform.parent);
                uiEnemy.transform.localPosition = pair.Position;
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