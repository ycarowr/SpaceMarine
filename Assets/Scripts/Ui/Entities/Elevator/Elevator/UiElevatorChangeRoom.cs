using System.Diagnostics.Tracing;
using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools;
using Tools.UI;
using UnityEditor;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiElevatorChangeRoom : UiGameEventListener, Events.IOnElevatorChangeRoom
    {      
        private UiElevator UiElevator { get; set; }

        protected override void Awake()
        {
            base.Awake();
            UiElevator = GetComponent<UiElevator>();
        }
        
        //--------------------------------------------------------------------------------------------------------------
        
        void Events.IOnElevatorChangeRoom.OnChangeRoom(RoomId id)
        {
            UiElevator.CurrentRoom = id;
            UiElevator.ElevatorAnimations.GoTo(id);
        }
    }
}