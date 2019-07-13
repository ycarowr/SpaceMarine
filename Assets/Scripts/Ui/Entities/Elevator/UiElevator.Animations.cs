using Tools.UI;
using Tools.UI.Fade;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiElevator
    {
        public class Animations: IUiMotionHandler
        {
            private const float Threshold = 0.075f;
            public float Speed => Handler.MovingSpeed;
            public UiMotion Motion { get; }
            public MonoBehaviour MonoBehaviour => Handler;
            private Transform[] Stops { get; }
            private const float LightsOn = 0f;
            private const float LightsOff = 0.8f;
            private FadeComponent Lights { get; }
            private UiElevator Handler { get; }

            public Animations(UiElevator handler, Transform[] stops)
            {
                Stops = stops;
                Handler = handler;
                Lights = Handler.GetComponentInChildren<FadeComponent>();
                Motion = new UiMotion(this);
                Motion.Movement.SetThreshold(Threshold);
            }

            public void Update()
            {
                Motion?.Update();
            }

            //----------------------------------------------------------------------------------------------------------
            
            public void Activate()
            {
                Lights.SetAlpha(LightsOn);
            }

            public void Deactivate()
            {
                Lights.SetAlpha(LightsOff);
            }
            
            //----------------------------------------------------------------------------------------------------------
            
            public void GoStop1()
            {
                Motion.MoveTo(Stops[0].position, Speed);
            }
        
            public void GoStop2()
            {
                Motion.MoveTo(Stops[1].position, Speed);
            }
        
            public void GoStop3()
            {
                Motion.MoveTo(Stops[2].position, Speed);
            }
        
            public void GoStop4()
            {
                Motion.MoveTo(Stops[3].position, Speed);
            }
            
            //----------------------------------------------------------------------------------------------------------
            
            private void PlayerEmbark()
            {
                UiPlayer.Instance.Lock();
                UiPlayer.Instance.transform.SetParent(Handler.transform);
                UiPlayer.Instance.Animation.ForcePlayJump();
                UiPlayer.Instance.Movement.Motion.Movement.OnFinishMotion += UiPlayer.Instance.Animation.ForceIdle;
                UiPlayer.Instance.Movement.Motion.Movement.OnFinishMotion += Handler.GoNext;
                UiPlayer.Instance.Movement.Motion.MoveTo(Handler.PlayerPosition.position, 10);
                Motion.Movement.OnFinishMotion += PlayerDisembark;
            }

            private void PlayerDisembark()
            {
                Motion.Movement.OnFinishMotion -= PlayerDisembark;
                UiPlayer.Instance.Movement.Motion.Movement.OnFinishMotion -= UiPlayer.Instance.Animation.ForceIdle;
                UiPlayer.Instance.Movement.Motion.Movement.OnFinishMotion -= Handler.GoNext;
                UiPlayer.Instance.transform.SetParent(null);
                UiPlayer.Instance.UnLock();
            }
        }
    }
}