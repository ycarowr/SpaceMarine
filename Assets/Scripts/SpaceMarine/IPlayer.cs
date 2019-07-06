using SpaceMarine.Input;
using UnityEngine;

namespace SpaceMarine
{
    public interface IPlayer
    {
        bool IsLocked { get; }
        MonoBehaviour MonoBehavior { get; }
        PlayerAnimator Animation { get; }
        PlayerAttributes Attributes { get; }
        PlayerParameters Parameters { get; }
        PlayerMovement Movement { get; }
        ISpaceMarineInput Input { get; }
        Rigidbody2D Rigidbody2D { get; }
        Collider2D Collider2D { get; }
        Animator Animator { get; }
        SpriteRenderer Sprite { get; }
        IGun Gun { get; }
        void Equip(GunData gun);
        void Die();
    }
}