using System.Collections;
using System.Collections.Generic;
using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools.Dialog;

namespace SpaceMarine
{
    public partial class UiDoor : UiGameEventListener, Events.IQuickFirstDoor
    {
        public bool HasQuickedFirstDoor =>
            GameData.Instance.Game.DoorsMechanics.HasQuickFirstDoor;
        
        UiButtonTriggerZone ButtonETrigger { get; set; }
        UiDoorAnimation Animation { get; set; }
        public DoorId Id { get; set; }
        public IDoor Door { get; set; }

        protected override void Awake()
        {
            base.Awake();
            Animation = new UiDoorAnimation(this);
            ButtonETrigger = GetComponentInChildren<UiButtonTriggerZone>();
        }

        private void Start()
        {
            ButtonETrigger.SetState(UiStateEntity.State.Inactive);
        }

        public void OpenDoor()
        {
            if (!HasQuickedFirstDoor)
                return;
            
            Animation.Open();
            ButtonETrigger.Window.Hide();
            ButtonETrigger.SwitchOff();
            ButtonETrigger.SetState(UiStateEntity.State.Inactive);
        }

        //--------------------------------------------------------------------------------------------------------------

        public void OnQuickFirstDoor()
        {
            ButtonETrigger.SetState(UiStateEntity.State.Off);
        }
    }
}
