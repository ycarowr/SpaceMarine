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
        UiButtonTriggerZone PlayerInteraction { get; set; }
        Animations ElevatorAnimations { get; set; }       

        void Awake()
        {
            ElevatorAnimations = new Animations(this, ElevatorStops);
            PlayerInteraction = GetComponentInChildren<UiButtonTriggerZone>();
            PlayerInteraction.AddListener(PlayerEmbark);
            GoStop1();
            Deactivate();
        }
        
        void Update()
        {
            ElevatorAnimations?.Update();    
        }

        //--------------------------------------------------------------------------------------------------------------

        public void Activate()
        {
            PlayerInteraction.SetState(UiStateEntity.State.Off);
            ElevatorAnimations.Activate();
        }

        public void Deactivate()
        {
            PlayerInteraction.SetState(UiStateEntity.State.Inactive);
            ElevatorAnimations.Deactivate();
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
            ElevatorAnimations.Motion.Movement.OnFinishMotion += PlayerDisembark;
        }

        private void PlayerDisembark()
        {
            ElevatorAnimations.Motion.Movement.OnFinishMotion -= PlayerDisembark;
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
            ElevatorAnimations.GoStop1();
        }
        
        [Button]
        public void GoStop2()
        {
            ElevatorAnimations.GoStop2();
        }
        
        [Button]
        public void GoStop3()
        {
            ElevatorAnimations.GoStop3();
        }
        
        [Button]
        public void GoStop4()
        {
            ElevatorAnimations.GoStop4();
        }
    }
}