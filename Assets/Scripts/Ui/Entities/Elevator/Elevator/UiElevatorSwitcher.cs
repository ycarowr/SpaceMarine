using System.Diagnostics.Tracing;
using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools;
using Tools.UI;
using UnityEditor;
using UnityEngine;

namespace SpaceMarine
{
    public class UiElevatorSwitcher : UiGameEventListener, Events.IOnSwitchElevator, Events.IStartGame
    {
        private UiElevator UiElevator { get; set; }
        private UiButtonTriggerZone ButtonETrigger { get; set; }

        protected override void Awake()
        {
            base.Awake();
            UiElevator = GetComponent<UiElevator>();
            ButtonETrigger = GetComponentInChildren<UiButtonTriggerZone>();
        }
        
        //--------------------------------------------------------------------------------------------------------------
        
        void Events.IStartGame.OnStartGame(IGame game)
        {
            SwitchOff();
        }

        void Events.IOnSwitchElevator.OnSwitch(bool isEnabled)
        {
            SwitchElevator(isEnabled);
        }
        
        //--------------------------------------------------------------------------------------------------------------
        
        public void SwitchElevator(bool isEnabled)
        {
            if(isEnabled)
                SwitchOn();
            else
                SwitchOff();
        }
        
        public void SwitchOn()
        {
            ButtonETrigger.SetState(UiStateEntity.State.Off);
            UiElevator.ElevatorAnimations.SwitchOn();
        }

        public void SwitchOff()
        {
            ButtonETrigger.SetState(UiStateEntity.State.Inactive);
            UiElevator.ElevatorAnimations.SwitchOff();
        }
    }
}