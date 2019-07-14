using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Model;
using Tools.Dialog;
using UnityEngine;

namespace SpaceMarine
{
    public class UiDoorDialog : MonoBehaviour
    {
        private readonly int open = Animator.StringToHash("Open");
        private readonly int close = Animator.StringToHash("Close");
        
        private UiButtonTriggerZone ButtonETrigger { get; set; }
        
        [Header("Dialog Parameters")]
        public TextButton ButtonOpenDoor;
        public TextSequence OpenDoorSequence;
        private IDialogSystem DialogSystem { get; set; }
        private Animator Animation { get; set; }

        protected void Awake()
        {
            Animation = GetComponent<Animator>();
            DialogSystem = GetComponentInChildren<IDialogSystem>();
            ButtonETrigger = GetComponentInChildren<UiButtonTriggerZone>();
            ButtonOpenDoor.OnPress.AddListener(OpenDoor);
        }

        private void Start()
        {
            ButtonETrigger.AddListener(ToggleDialog);
            ButtonETrigger.Window.OnHidden += DialogSystem.Hide;
        }

        public void ToggleDialog()
        {
            if (!DialogSystem.IsOpened)
                DialogSystem.Write(OpenDoorSequence);
            else
                DialogSystem.Hide();
        }

        void OpenDoor()
        {
            Animation.Play(open);
            ButtonETrigger.Window.Hide();
            ButtonETrigger.SetState(UiStateEntity.State.Inactive);
        }
    }
}
