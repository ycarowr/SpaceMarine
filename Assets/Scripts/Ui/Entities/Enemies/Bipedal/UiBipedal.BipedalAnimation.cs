using UnityEngine;

namespace SpaceMarine
{
    public partial class UiBipedal
    {
        public class BipedalAnimation
        {
            readonly int idle = Animator.StringToHash("Idle");
            readonly int walk = Animator.StringToHash("Walk");

            public BipedalAnimation(UiBipedal handler)
            {
                Handler = handler;
                Animator = Handler.GetComponent<Animator>();
            }

            Animator Animator { get; }
            MonoBehaviour Handler { get; }

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