using Tools;
using UnityEditor;
using UnityEngine;

namespace SpaceMarine
{
    public class Elevator : MonoBehaviour
    {
        PressButtonNotification PlayerInteraction { get; set; }

        void Awake()
        {
            ElevatorControl.OnSwitchElevator += SwitchElevator;
            PlayerInteraction = GetComponentInChildren<PressButtonNotification>();
            Deactivate();
        }

        //--------------------------------------------------------------------------------------------------------------
        
        void SwitchElevator(bool isEnabled)
        {
            if(isEnabled)
                Activate();
            else
                Deactivate();
        }

        void Activate()
        {
            PlayerInteraction.SetState(StateEntity.State.Off);
        }

        void Deactivate()
        {
            PlayerInteraction.SetState(StateEntity.State.Inactive);
        }
    }
    
}