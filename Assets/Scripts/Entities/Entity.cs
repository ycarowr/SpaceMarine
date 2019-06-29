using UnityEngine;

namespace SpaceMarine
{
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
            if (IsPlayer(collision.collider))
                OnCollisionEnterPlayer();
        }

        protected void OnCollisionExit2D(Collision2D collision)
        {
            if (IsPlayer(collision.collider))
                OnCollisionExitPlayer();
        }

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsPlayer(collision))
                OnTriggerEnterPlayer();
        }

        protected void OnTriggerExit2D(Collider2D collision)
        {
            if (IsPlayer(collision))
                OnTriggerExitPlayer();
        }

        private bool IsPlayer(Collider2D collider)
        {
            return collider == MyPlayer.Collider2D;
        }

        protected virtual void OnCollisionEnterPlayer()
        {
        }

        protected virtual void OnCollisionExitPlayer()
        {
        }

        protected virtual void OnTriggerEnterPlayer()
        {
        }

        protected virtual void OnTriggerExitPlayer()
        {
        }
    }
}