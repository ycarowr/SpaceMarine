using Tools;
using Tools.UI;
using UnityEditor;
using UnityEngine;

namespace SpaceMarine
{
    public partial class Elevator : MonoBehaviour
    {
        public Transform[] ElevatorStops;
        [Range(0, 20)] public float MovingSpeed;
        PressButtonNotification PlayerInteraction { get; set; }
        private Animations AnimationElevator { get; set; }       

        void Awake()
        {
            AnimationElevator = new Animations(this, ElevatorStops);
            PlayerInteraction = GetComponentInChildren<PressButtonNotification>();
            ElevatorControl.OnSwitchElevator += SwitchElevator;
            GoStop1();
            Deactivate();
        }
        
        void Update()
        {
            AnimationElevator?.Update();    
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
            AnimationElevator.Activate();
        }

        void Deactivate()
        {
            PlayerInteraction.SetState(StateEntity.State.Inactive);
            AnimationElevator.Deactivate();
        }
        
        //--------------------------------------------------------------------------------------------------------------

        [Button]
        public void GoStop1()
        {
            AnimationElevator.GoStop1();
        }
        
        [Button]
        public void GoStop2()
        {
            AnimationElevator.GoStop2();
        }
        
        [Button]
        public void GoStop3()
        {
            AnimationElevator.GoStop3();
        }
        
        [Button]
        public void GoStop4()
        {
            AnimationElevator.GoStop4();
        }
        

    }
}