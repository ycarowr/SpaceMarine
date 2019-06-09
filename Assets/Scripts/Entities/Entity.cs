using SpaceMarine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour
{   
    public Rigidbody2D Rigidbody2D { get; private set; }
    public Collider Collider { get; private set; }
    public SpriteRenderer Sprite { get; private set; }
    public Animator Animator { get; private set; }
    public IPlayer MyPlayer => Player.Instance;

    protected virtual void Awake()
    {
        Rigidbody2D = GetComponentInChildren<Rigidbody2D>();
        Collider = GetComponentInChildren<Collider>();
        Sprite = GetComponentInChildren<SpriteRenderer>();
        Animator = GetComponentInChildren<Animator>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider == MyPlayer.Collider2D)
            OnCollisionEnterPlayer();
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider == MyPlayer.Collider2D)
            OnCollisionExitPlayer();
    }

    protected abstract void OnCollisionEnterPlayer();
    protected abstract void OnCollisionExitPlayer();
}
