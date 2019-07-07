using System.Diagnostics.Tracing;
using Tools;
using Tools.UI;
using UnityEditor;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiElevator : MonoBehaviour
    {
        public Transform[] ElevatorStops;
        public Transform PlayerPosition;
        [Range(0, 20)] public float MovingSpeed;
        PressButtonNotification PlayerInteraction { get; set; }
        Animations AnimationElevator { get; set; }       

        void Awake()
        {
            AnimationElevator = new Animations(this, ElevatorStops);
            PlayerInteraction = GetComponentInChildren<PressButtonNotification>();
            PlayerInteraction.AddListener(PlayerEmbark);
            GoStop1();
            Deactivate();
        }
        
        void Update()
        {
            AnimationElevator?.Update();    
        }

        //--------------------------------------------------------------------------------------------------------------

        public void Activate()
        {
            PlayerInteraction.SetState(StateEntity.State.Off);
            AnimationElevator.Activate();
        }

        public void Deactivate()
        {
            PlayerInteraction.SetState(StateEntity.State.Inactive);
            AnimationElevator.Deactivate();
        }
        
        //--------------------------------------------------------------------------------------------------------------

        private void PlayerEmbark()
        {
            UiPlayer.Instance.Lock();
            UiPlayer.Instance.transform.SetParent(transform);
            UiPlayer.Instance.Animation.ForcePlayJump();
            UiPlayer.Instance.Movement.Motion.Movement.OnFinishMotion += UiPlayer.Instance.Animation.ForceIdle;
            UiPlayer.Instance.Movement.Motion.Movement.OnFinishMotion += GoNext;
            UiPlayer.Instance.Movement.Motion.MoveTo(PlayerPosition.position, 10);
            AnimationElevator.Motion.Movement.OnFinishMotion += PlayerDisembark;
        }

        private void PlayerDisembark()
        {
            AnimationElevator.Motion.Movement.OnFinishMotion -= PlayerDisembark;
            UiPlayer.Instance.Movement.Motion.Movement.OnFinishMotion -= UiPlayer.Instance.Animation.ForceIdle;
            UiPlayer.Instance.Movement.Motion.Movement.OnFinishMotion -= GoNext;
            UiPlayer.Instance.transform.SetParent(null);
            UiPlayer.Instance.UnLock();
        }
        
        //--------------------------------------------------------------------------------------------------------------

        public bool room;

        public void GoNext()
        {
            room = !room;
            if(room) 
                GoStop2();
            else
                GoStop1();
        }
        
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