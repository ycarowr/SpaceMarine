using UnityEngine;

namespace SpaceMarine
{
    public class UiPlayerAnimator
    {
        readonly int Die = Animator.StringToHash("Die");

        readonly int Idle = Animator.StringToHash("Idle");
        readonly int Jump = Animator.StringToHash("Jump");
        readonly int Run = Animator.StringToHash("Run");
        readonly int Shoot = Animator.StringToHash("Shoot");

        public UiPlayerAnimator(IUiPlayer uiPlayer)
        {
            UiPlayer = uiPlayer;
            Sprite = uiPlayer.Sprite;
            Attributes = uiPlayer.Attributes;
            Animator = uiPlayer.Animator;
        }

        IUiPlayer UiPlayer { get; }
        UiPlayerAttributes Attributes { get; }
        Animator Animator { get; }
        SpriteRenderer Sprite { get; }

        public void Update()
        {
            if (UiPlayer.IsLocked)
                return;

            Animator.SetBool(Jump, !Attributes.IsGrounded);
            Animator.SetBool(Idle, Attributes.IsIdle);
            Animator.SetBool(Run, Attributes.IsMoving);
            Animator.SetBool(Die, Attributes.IsDead);
            Animator.SetBool(Shoot, Attributes.IsShotting);

            Sprite.flipX = Attributes.IsMoving ? Attributes.IsLeft : Sprite.flipX;
        }


        public void ForceWalk()
        {
            Animator.SetBool(Run, true);
            Animator.SetBool(Jump, false);
        }

        public void ForceJump()
        {
            Animator.SetBool(Run, false);
            Animator.SetBool(Jump, true);
        }

        public void ForceIdle()
        {
            Animator.SetBool(Jump, false);
            Animator.SetBool(Idle, true);
            Animator.SetBool(Run, false);
        }
    }
}