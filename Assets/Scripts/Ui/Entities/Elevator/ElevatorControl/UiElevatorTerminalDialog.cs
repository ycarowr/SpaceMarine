using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools.Dialog;
using UnityEngine;

namespace SpaceMarine
{
    public class UiElevatorTerminalDialog : UiGameEventListener
    {
        public TextButton ButtonForgetIt;
        public TextButton ButtonToggleOff;

        [Header("Dialog Parameters")] public TextButton ButtonToggleOn;

        public TextSequence TextSequenceOff;

        public TextSequence TextSequenceOn;
        IElevator Elevator => GameData.Instance.Game.ElevatorMechanics.Elevator;
        UiButtonTriggerZone ButtonETrigger { get; set; }
        IDialogSystem DialogSystem { get; set; }

        protected override void Awake()
        {
            base.Awake();
            DialogSystem = GetComponentInChildren<IDialogSystem>();
            ButtonETrigger = GetComponentInChildren<UiButtonTriggerZone>();
            ButtonToggleOn.OnClick.Add(DialogSystem, ToggleElevator);
            ButtonToggleOff.OnClick.Add(DialogSystem, ToggleElevator);
            ButtonForgetIt.OnClick.Add(DialogSystem, DialogSystem.Hide);
        }

        void Start()
        {
            ButtonETrigger.AddListener(ToggleDialog);
            ButtonETrigger.Window.OnHidden += DialogSystem.Hide;
        }

        public void ToggleDialog()
        {
            if (!DialogSystem.IsOpened)
            {
                if (Elevator.IsLocked)
                    DialogSystem.Write(TextSequenceOff);
                else
                    DialogSystem.Write(TextSequenceOn);
            }
            else
            {
                DialogSystem.Hide();
            }
        }

        void ToggleElevator()
        {
            DialogSystem.Hide();
            Elevator.Switch();
        }
    }
}