using UnityEngine;

namespace Tools.UI
{
    public class UiMotionMovement : UiMotionBase
    {
        public UiMotionMovement(MonoBehaviour handler) : base(handler)
        {
        }

        private bool WithZ { get; set; }
        public bool IsConstant { get; set; }

        public override void Execute(Vector3 position, float speed, float delay)
        {
            base.Execute(position, speed, delay);
        }

        protected override void OnMotionEnds()
        {
            WithZ = false;
            IsOperating = false;
            var target = Target;
            target.z = Handler.transform.position.z;
            Handler.transform.position = target;
            base.OnMotionEnds();
        }

        protected override void KeepMotion()
        {
            var current = (Vector2)Handler.transform.position;
            var amount = Speed * Time.deltaTime;
            var delta = !IsConstant
                ? Vector2.Lerp(current, Target, amount)
                : Vector2.MoveTowards(current, Target, amount);
            
            Handler.transform.position = delta;
        }

        protected override bool CheckFinalState()
        {
            var distance = (Vector2)Target - (Vector2)Handler.transform.position;
            return distance.magnitude <= Threshold;
        }
    }
}