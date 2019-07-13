using UnityEngine;

namespace SpaceMarine
{
    public abstract class UiBaseEntity : MonoBehaviour
    {
        public Rigidbody2D Rigidbody2D { get; private set; }
        public Collider Collider { get; private set; }
        public SpriteRenderer Sprite { get; private set; }
        public Animator Animator { get; private set; }
        public IUiPlayer MyUiPlayer => UiPlayer.Instance;

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
        
        protected void OnCollisionStay2D(Collision2D collision)
        {
            if (IsPlayer(collision.collider))
                OnCollisionStayPlayer();
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
            return collider == MyUiPlayer.Collider2D;
        }

        protected virtual void OnCollisionEnterPlayer()
        {
        }
        
        protected virtual void OnCollisionStayPlayer()
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