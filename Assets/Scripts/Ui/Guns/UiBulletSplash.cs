using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMarine
{
    public class UiBulletSplash: MonoBehaviour
    {
        private readonly int splashBullet = Animator.StringToHash("BulletSplash");
        private Animator Animator { get; set; }
        private SpriteRenderer SpriteRenderer { get; set; }

        private void Awake()
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