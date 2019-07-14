using System.Diagnostics.Tracing;
using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools;
using Tools.Dialog;
using Tools.UI;
using UnityEditor;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiElevator : UiGameEventListener, Events.IStartGame
    {
        [Tooltip("All the world positions where the elevator can stop.")]
        public UiElevatorStop [] uiElevatorStops;
        
        [Tooltip("Position of the player inside the elevator.")]
        public Transform PlayerPosition;
        
        [Range(0, 20)] public float MovingSpeed;
        public Animations ElevatorAnimations { get; private set; }

        public RoomId CurrentRoom { get; set; }

        protected override void Awake()
        {
            base.Awake();
            CurrentRoom = RoomId.Level0;
            ElevatorAnimations = new Animations(this, uiElevatorStops);
        }

        void Events.IStartGame.OnStartGame(IGame game)
        {
            ElevatorAnimations.GoToWithNoPlayer();
        }
        
        void Update()
        {
            ElevatorAnimations?.Update();    
        }
    }
}