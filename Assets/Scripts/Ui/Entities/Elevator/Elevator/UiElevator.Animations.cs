using System.Collections.Generic;
using SpaceMarine.Model;
using Tools.UI;
using Tools.UI.Fade;
using UnityEngine;
using UnityEngine.XR;

namespace SpaceMarine
{
    public partial class UiElevator
    {
        public class Animations: IUiMotionHandler
        {
            #region Elevator Stops and Motion
            private Dictionary<RoomId, Transform> Stops { get; }
            
            private const float Threshold = 0.075f;
            public float Speed => Handler.MovingSpeed;
            public UiMotion Motion { get; }
            public MonoBehaviour MonoBehaviour => Handler;
            private UiElevator Handler { get; }
            
            #endregion
            
            #region Lights
            
            private const float LightsOn = 0f;
            private const float LightsOff = 0.8f;
            private FadeComponent Lights { get; }
            
            #endregion

            public Animations(UiElevator handler, UiElevatorStop[] stops)
            {
                Handler = handler;
                Lights = Handler.GetComponentInChildren<FadeComponent>();
                Motion = new UiMotion(this);
                Motion.Movement.SetThreshold(Threshold);
               
                Stops = new Dictionary<RoomId, Transform>();
                foreach(var stop in stops)
                    Stops.Add(stop.Id, stop.Position);
            }

            public void Update()
            {
                Motion?.Update();
            }

            //----------------------------------------------------------------------------------------------------------
            
            #region Lights
            
            public void SwitchOn()
            {
                Lights.SetAlpha(LightsOn);
            }

            public void SwitchOff()
            {
                Lights.SetAlpha(LightsOff);
            }
            
            #endregion
            
            //----------------------------------------------------------------------------------------------------------

            #region Handle Movement
            
            private void MoveToDestiny()
            {
                var id = Handler.CurrentRoom;
                var stop = Stops[id];
                Motion.MoveTo(stop.position, Speed);
            }

            public void GoToWithNoPlayer()
            {
                var id = Handler.CurrentRoom;
                var stop = Stops[id];
                Motion.MoveTo(stop.position, Speed);
            }
            
            public void GoTo(RoomId id)
            {
                
                UiCamera.Instance.transform.SetParent(Handler.transform);
                UiPlayer.Instance.Lock();
                UiPlayer.Instance.transform.SetParent(Handler.transform);
                UiPlayer.Instance.Animation.ForcePlayJump();
                UiPlayer.Instance.Movement.Motion.Movement.OnFinishMotion += UiPlayer.Instance.Animation.ForceIdle;
                UiPlayer.Instance.Movement.Motion.Movement.OnFinishMotion += MoveToDestiny;
                UiPlayer.Instance.Movement.Motion.MoveTo(Handler.PlayerPosition.position, 10);
                Motion.Movement.OnFinishMotion += PlayerDisembark;
            }

            private void PlayerDisembark()
            {
                UiCamera.Instance.transform.SetParent(null);
                Motion.Movement.OnFinishMotion -= PlayerDisembark;
                UiPlayer.Instance.Movement.Motion.Movement.OnFinishMotion -= UiPlayer.Instance.Animation.ForceIdle;
                UiPlayer.Instance.Movement.Motion.Movement.OnFinishMotion -= MoveToDestiny;
                UiPlayer.Instance.transform.SetParent(null);
                UiPlayer.Instance.UnLock();
            }
            
            
            
            #endregion
        }
    }
}