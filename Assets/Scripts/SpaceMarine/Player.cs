using Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceMarine.Input;

namespace SpaceMarine
{
    public class Player : SingletonMB<Player>, IPlayer
    {
        [SerializeField] PlayerParameters parameters;
        public PlayerParameters Parameters => parameters;

        public Rigidbody2D Rigidbody2D { get; private set; }
        public Collider2D Collider2D { get; private set; }
        public SpriteRenderer Sprite { get; private set; }
        public Animator Animator { get; private set; }
        public MonoBehaviour MonoBehavior => this;
        public PlayerMovement Movement { get; private set; }
        public PlayerAttributes Attributes { get; private set; }
        public PlayerAnimator Animation { get; private set; }
        public ISpaceMarineInput Input { get; private set; }

        protected override void OnAwake()
        {
            Rigidbody2D = GetComponentInChildren<Rigidbody2D>();
            Collider2D = GetComponentInChildren<Collider2D>();
            Sprite = GetComponentInChildren<SpriteRenderer>();
            Animator = GetComponentInChildren<Animator>();
            Input = GetComponent<SpaceMarineInput>();
            Attributes = new PlayerAttributes(this);
            Animation = new PlayerAnimator(this);
            Movement = new PlayerMovement(this);
        }

        private void Update()
        {
            Movement?.Update();
            Animation?.Update();
        }

        [Button]
        private void Die()
        {
            Attributes.IsDead = true;
        }

    }
}