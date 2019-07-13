using UnityEngine;

namespace SpaceMarine
{
    public class UiPlayerAnimator
    {
        private readonly int Die = Animator.StringToHash("Die");

        private readonly int Idle = Animator.StringToHash("Idle");
        private readonly int Jump = Animator.StringToHash("Jump");
        private readonly int Run = Animator.StringToHash("Run");
        private readonly int Shoot = Animator.StringToHash("Shoot");

        public UiPlayerAnimator(IUiPlayer uiPlayer)
        {
            UiPlayer = uiPlayer;
            Sprite = uiPlayer.Sprite;
            Attributes = uiPlayer.Attributes;
            Animator = uiPlayer.Animator;
        }

        private IUiPlayer UiPlayer { get; }
        private UiPlayerAttributes Attributes { get; }
        private Animator Animator { get; }
        private SpriteRenderer Sprite { get; }

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

        public void ForcePlayJump()
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