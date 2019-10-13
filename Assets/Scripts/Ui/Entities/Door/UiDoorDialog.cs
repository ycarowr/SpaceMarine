using Tools.DialogSystem;
using Tools.Patterns.GameEvents;
using UnityEngine;

namespace SpaceMarine
{
    public class UiDoorDialog : UiGameEventListener
    {
        public TextButton ButtonNevermind;

        [Header("Dialog Parameters")] public TextButton ButtonOpenDoor;

        public TextSequence OpenDoorSequence;
        UiDoor UiDoor { get; set; }
        UiButtonTriggerZone ButtonETrigger { get; set; }
        IDialogSystem DialogSystem { get; set; }

        protected override void Awake()
        {
            base.Awake();
            UiDoor = GetComponent<UiDoor>();
            DialogSystem = GetComponentInChildren<IDialogSystem>();
            ButtonETrigger = GetComponentInChildren<UiButtonTriggerZone>();
            ButtonOpenDoor.OnClick.Add(DialogSystem, UiDoor.OpenDoor);
            ButtonNevermind.OnClick.Add(DialogSystem, DialogSystem.Hide);
        }

        void Start()
        {
            ButtonETrigger.AddListener(ToggleDialog);
            ButtonETrigger.Window.OnHidden += DialogSystem.Hide;
        }

        public void ToggleDialog()
        {
            if (!UiDoor.HasQuickedFirstDoor)
                return;

            if (!DialogSystem.IsOpened)
                DialogSystem.Write(OpenDoorSequence);
            else
                DialogSystem.Hide();
        }
    }
}