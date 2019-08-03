using UnityEngine;

namespace SpaceMarine
{
    public class UiBulletSplash : MonoBehaviour
    {
        readonly int splashBullet = Animator.StringToHash("BulletSplash");
        Animator Animator { get; set; }
        SpriteRenderer SpriteRenderer { get; set; }

        void Awake()
        {
            Animator = GetComponent<Animator>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Animate(bool isFlipX)
        {
            SpriteRenderer.flipX = isFlipX;
            Animator.Play(splashBullet);
        }

        //Called by Animator
        public void Release()
        {
            UiObjectsPooler.Instance.Release(gameObject);
        }
    }
}