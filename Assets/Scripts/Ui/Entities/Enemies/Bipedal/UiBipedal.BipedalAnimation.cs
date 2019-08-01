using UnityEngine;

namespace SpaceMarine
{
    public partial class UiBipedal
    {
        public class BipedalAnimation
        {
            readonly int walk = UnityEngine.Animator.StringToHash("Walk");
            readonly int idle = UnityEngine.Animator.StringToHash("Idle");
            Animator Animator { get; }
            MonoBehaviour Handler { get; }

            public BipedalAnimation(UiBipedal handler)
            {
                Handler = handler;
                Animator = Handler.GetComponent<Animator>();
            }

            public void Walk()
            {
                Animator.Play(walk);
            }

            public void Idle()
            {
                Animator.Play(idle);
            }

            public void Disable()
            {
                //TODO: Fade the object out.
            }

            public void Explode()
            {
                //TODO: Boom, BOom, BOOM
            }
        }
    }
}