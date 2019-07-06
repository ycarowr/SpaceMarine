using Tools;
using Tools.UI.Fade;
using UnityEditor;
using UnityEngine;

namespace SpaceMarine
{
    public class Elevator : MonoBehaviour
    {
        private const float LightsOn = 0f;
        private const float LightsOff = 0.8f;
        PressButtonNotification PlayerInteraction { get; set; }
        private FadeComponent Lights { get; set; }
        

        void Awake()
        {
            PlayerInteraction = GetComponentInChildren<PressButtonNotification>();
            Lights = GetComponentInChildren<FadeComponent>();
            ElevatorControl.OnSwitchElevator += SwitchElevator;
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
            Lights.SetAlpha(LightsOn);
        }

        void Deactivate()
        {
            PlayerInteraction.SetState(StateEntity.State.Inactive);
            Lights.SetAlpha(LightsOff);
        }
    }
    
}