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
    public class UiRoom : UiBaseEntity, IListener, Events.ICreateGame
    {
        private IRoomMechanics RoomMechanics => GameController.Instance.Game.RoomMechanics;
        
        [Tooltip("The id of this room.")]
        public RoomId RoomId;

        private IRoom Room { get; set; }

        protected override void Awake()
        {
            base.Awake();
            GameEvents.Instance.AddListener(this);
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
            var room = game.RoomMechanics.Get(RoomId);
            Room = room;
            
            Debug.Log("Room: "+ RoomId);
            Debug.Log("Room1: "+ room.Id);
            foreach (var door in room.Doors)
            {
                var id = door.Id;
                var prefab = door.Data.DoorPrefab;
                var uiDoorGo = UiObjectsPooler.Instance.Get(prefab);
                var uiDoor = uiDoorGo.GetComponent<UiDoor>();
                var pair = room.Data.Doors.ToList().Find(x => x.Door.Id == id);
                foreach(var p in room.Data.Doors)
                    Debug.Log(p.Door +" "+p.Position);
                
                Debug.Log("Pair: "+ room.Data.Doors.Length);
                
                uiDoor.Id = id;
                uiDoor.Door = door; 
                uiDoor.transform.SetParent(transform.parent);
                uiDoor.transform.localPosition = pair.Position;
            }
        }
    }
}