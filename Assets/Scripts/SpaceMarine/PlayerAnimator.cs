using UnityEngine;

namespace SpaceMarine
{
    public class PlayerAnimator
    {
        private readonly int Die = Animator.StringToHash("Die");

        private readonly int Idle = Animator.StringToHash("Idle");
        private readonly int Jump = Animator.StringToHash("Jump");
        private readonly int Run = Animator.StringToHash("Run");
        private readonly int Shoot = Animator.StringToHash("Shoot");

        public PlayerAnimator(IPlayer player)
        {
            Player = player;
            Sprite = player.Sprite;
            Attributes = player.Attributes;
            Animator = player.Animator;
        }

        private IPlayer Player { get; }
        private PlayerAttributes Attributes { get; }
        private Animator Animator { get; }
        private SpriteRenderer Sprite { get; }

        public void Update()
        {
            Animator.SetBool(Jump, !Attributes.IsGrounded);
            Animator.SetBool(Idle, Attributes.IsIdle);
            Animator.SetBool(Run, Attributes.IsMoving);
            Animator.SetBool(Die, Attributes.IsDead);
            Animator.SetBool(Shoot, Attributes.IsShotting);

            Sprite.flipX = Attributes.IsMoving ? Attributes.IsLeft : Sprite.flipX;
        }
    }
}