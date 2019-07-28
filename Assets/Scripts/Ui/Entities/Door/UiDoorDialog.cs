using System.Collections;
using System.Collections.Generic;
using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools.Dialog;
using UnityEngine;

namespace SpaceMarine
{
    public class UiDoorDialog : UiGameEventListener
    {
        UiDoor UiDoor { get; set; }
        UiButtonTriggerZone ButtonETrigger { get; set; }
        
        [Header("Dialog Parameters")]
        public TextButton ButtonOpenDoor;
        public TextButton ButtonNevermind;
        public TextSequence OpenDoorSequence;
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

        private void Start()
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
