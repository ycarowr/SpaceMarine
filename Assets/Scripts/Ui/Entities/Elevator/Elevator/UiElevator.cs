using Patterns.GameEvents;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiElevator : UiGameEventListener, GameEvent.IStartGame
    {
        public SpriteRenderer ElevatorSprite;

        [Range(0, 20)] public float MovingSpeed;

        [Tooltip("Position of the player inside the elevator.")]
        public Transform PlayerPosition;

        [Tooltip("All the world positions where the elevator can stop.")]
        public UiElevatorStop[] uiElevatorStops;

        public Animations ElevatorAnimations { get; private set; }

        public RoomId CurrentRoom { get; set; }

        void GameEvent.IStartGame.OnStartGame(IGame game)
        {
            ElevatorAnimations.GoToWithNoPlayer();
        }

        protected override void Awake()
        {
            base.Awake();
            CurrentRoom = RoomId.Elevator0;
            ElevatorAnimations = new Animations(this, uiElevatorStops);
        }

        void Update()
        {
            ElevatorAnimations?.Update();
        }
    }
}