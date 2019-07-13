using SpaceMarine.Input;
using UnityEngine;

namespace SpaceMarine
{
    public interface IUiPlayer
    {
        bool IsLocked { get; }
        MonoBehaviour MonoBehavior { get; }
        UiPlayerAnimator Animation { get; }
        UiPlayerAttributes Attributes { get; }
        UiPlayerParameters Parameters { get; }
        UiPlayerMovement Movement { get; }
        ISpaceMarineInput Input { get; }
        Rigidbody2D Rigidbody2D { get; }
        Collider2D Collider2D { get; }
        Animator Animator { get; }
        SpriteRenderer Sprite { get; }
    }
}