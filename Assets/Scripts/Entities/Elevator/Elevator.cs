using Tools;
using UnityEngine;

namespace SpaceMarine
{
    public class Elevator : StateEntity
    {
        protected override void Awake()
        {
            base.Awake();
            ElevatorControl.OnSwitchElevator += SwitchElevator;
        }


        public void SwitchElevator(bool isEnabled)
        {
            Debug.Log("Elevator: " + isEnabled);
        }
    }
    
}