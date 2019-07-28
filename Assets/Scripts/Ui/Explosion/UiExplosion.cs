using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMarine
{
    public class UiExplosion : MonoBehaviour
    {
        readonly int explosion = Animator.StringToHash("Explosion");
        private Animator Animator { get; set; }

        void Awake()
        {
            Animator = GetComponent<Animator>();
        }

        public void Explode()
        {
            Animator.Play(explosion);
        }

        //Called by Animator
        public void Release()
        {
            UiObjectsPooler.Instance.Release(gameObject);
        }
    }
}