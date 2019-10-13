using SpaceMarine.Model;
using Tools.DialogSystem;
using Tools.Patterns.GameEvents;
using UnityEngine;

namespace SpaceMarine
{
    public class UiElevatorDialog : UiGameEventListener
    {
        [Header("Dialog Parameters")] public TextButton ButtonDown;

        public TextButton ButtonForgetIt;
        public TextButton ButtonUp;
        public TextSequence TextSequence;
        ElevatorMechanics Elevator => GameData.Instance.Game.ElevatorMechanics;
        UiElevator UiElevator { get; set; }
        UiButtonTriggerZone ButtonETrigger { get; set; }
        IDialogSystem DialogSystem { get; set; }

        protected override void Awake()
        {
            base.Awake();
            UiElevator = GetComponent<UiElevator>();
            DialogSystem = GetComponentInChildren<IDialogSystem>();
            ButtonETrigger = GetComponentInChildren<UiButtonTriggerZone>();
        }

        void Start()
        {
            ButtonDown.OnClick.Add(DialogSystem, PressDown);
            ButtonUp.OnClick.Add(DialogSystem, PressUp);
            ButtonForgetIt.OnClick.Add(DialogSystem, DialogSystem.Hide);
            ButtonETrigger.AddListener(ToggleDialog);
            ButtonETrigger.Window.OnHidden += DialogSystem.Hide;
        }

        public void ToggleDialog()
        {
            if (!DialogSystem.IsOpened)
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

            DialogSystem.Hide();
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

            DialogSystem.Hide();
        }

        RoomId GetNextDown(RoomId current)
        {
            var nextRoom = RoomId.Elevator0;
            switch (current)
            {
                case RoomId.Elevator0:
                    nextRoom = RoomId.Elevator1;
                    break;
                case RoomId.Elevator1:
                    nextRoom = RoomId.Elevator2;
                    break;
                case RoomId.Elevator2:
                    nextRoom = RoomId.Elevator3;
                    break;
                case RoomId.Elevator3:
                    nextRoom = RoomId.Elevator2;
                    break;
            }

            return nextRoom;
        }

        RoomId GetNextUp(RoomId current)
        {
            var nextRoom = RoomId.Elevator0;
            switch (current)
            {
                case RoomId.Elevator0:
                    nextRoom = RoomId.Elevator1;
                    break;
                case RoomId.Elevator1:
                    nextRoom = RoomId.Elevator0;
                    break;
                case RoomId.Elevator2:
                    nextRoom = RoomId.Elevator1;
                    break;
                case RoomId.Elevator3:
                    nextRoom = RoomId.Elevator2;
                    break;
            }

            return nextRoom;
        }
    }
}