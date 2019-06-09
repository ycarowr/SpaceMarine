using Tools.Input;
using UnityEngine;

namespace SpaceMarine
{
    public interface IPlayer
    {
        MonoBehaviour MonoBehavior { get; }
        PlayerAnimator Animation { get; }
        PlayerAttributes Attributes { get; }
        PlayerParameters Parameters { get; }
        PlayerMovement Movement { get; }
        IInputProvider Input { get; }
        Rigidbody2D Rigidbody2D { get; }
        Collider2D Collider2D { get; }
        Animator Animator { get; }
        SpriteRenderer Sprite { get; }
    }
}