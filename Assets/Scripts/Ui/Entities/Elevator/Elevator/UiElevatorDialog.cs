using System;
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
    public class UiElevatorDialog : UiGameEventListener
    {
        private ElevatorMechanics Elevator => GameController.Instance.Game.ElevatorMechanics;
        private UiElevator UiElevator { get; set; }
        private UiButtonTriggerZone ButtonETrigger { get; set; }
        
        [Header("Dialog Parameters")]
        public TextButton ButtonDown;
        public TextButton ButtonUp;
        public TextSequence TextSequence;
        private IDialogSystem DialogSystem { get; set; }

        protected override void Awake()
        {
            base.Awake();
            UiElevator = GetComponent<UiElevator>();
            DialogSystem = GetComponentInChildren<IDialogSystem>();
            ButtonETrigger = GetComponentInChildren<UiButtonTriggerZone>();
            ButtonDown.OnPress.AddListener(PressDown);
            ButtonUp.OnPress.AddListener(PressUp);
        }

        private void Start()
        {
            ButtonETrigger.AddListener(ToggleDialog);
            ButtonETrigger.Window.OnHidden += DialogSystem.Hide;
        }

        public void ToggleDialog()
        {
            if(!DialogSystem.IsOpened)
                DialogSystem.Write(TextSequence);
            else
                DialogSystem.Hide();
        }
        
        void PressDown()
        {
            var current = UiElevator.CurrentRoom;
            var nextRoom = GetNextDown(current);
            DialogSystem.OnHide += GoTo;

            void GoTo()
            {
                DialogSystem.OnHide -= GoTo;
                Elevator.GoTo(nextRoom);
            }
        }

        void PressUp()
        {
            var current = UiElevator.CurrentRoom;
            var nextRoom = GetNextUp(current);
            DialogSystem.OnHide += GoTo;

            void GoTo()
            {
                DialogSystem.OnHide -= GoTo;
                Elevator.GoTo(nextRoom);
            }
        }

        RoomId GetNextDown(RoomId current)
        {
            var nextRoom = RoomId.Level0;
            switch (current)
            {
                case RoomId.Level0: nextRoom = RoomId.Level1; break;
                case RoomId.Level1: nextRoom = RoomId.Level2; break;
                case RoomId.Level2: nextRoom = RoomId.Level3; break;
                case RoomId.Level3: nextRoom = RoomId.Level2; break;
            }

            return nextRoom;
        }
        
        RoomId GetNextUp(RoomId current)
        {
            var nextRoom = RoomId.Level0;
            switch (current)
            {
                case RoomId.Level0: nextRoom = RoomId.Level1; break;
                case RoomId.Level1: nextRoom = RoomId.Level0; break;
                case RoomId.Level2: nextRoom = RoomId.Level1; break;
                case RoomId.Level3: nextRoom = RoomId.Level2; break;
            }

            return nextRoom;
        }
    }
}