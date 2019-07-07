using System.Diagnostics.Tracing;
using Patterns.GameEvents;
using Tools;
using Tools.UI;
using UnityEditor;
using UnityEngine;

namespace SpaceMarine
{
    public class UiElevatorSwitcher : UiGameEventListener, Events.IElevatorControl
    {
        private UiElevator UiElevator { get; set; }

        private void Awake()
        {
            UiElevator = GetComponent<UiElevator>();
        }

        void Events.IElevatorControl.OnSwitch(bool isEnabled)
        {
            SwitchElevator(isEnabled);
        }
        
        void SwitchElevator(bool isEnabled)
        {
            if(isEnabled)
                UiElevator.Activate();
            else
                UiElevator.Deactivate();
        }
    }
}