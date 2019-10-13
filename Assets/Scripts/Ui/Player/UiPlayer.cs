using System;
using SpaceMarine.Input;
using Tools.Patterns.Singleton;
using UnityEngine;

namespace SpaceMarine
{
    public class UiPlayer : SingletonMB<UiPlayer>, IUiPlayer
    {
        public Action<bool> OnInputChange = isLocked => { };

        [SerializeField] UiPlayerParameters parameters;


        protected override void OnAwake()
        {
            Rigidbody2D = GetComponentInChildren<Rigidbody2D>();
            Collider2D = GetComponentInChildren<Collider2D>();
            Sprite = GetComponentInChildren<SpriteRenderer>();
            Animator = GetComponentInChildren<Animator>();
            Input = GetComponent<UiSpaceMarineInput>();
            Attributes = new UiPlayerAttributes(this);
            Animation = new UiPlayerAnimator(this);
            Movement = new UiPlayerMovement(this);
            UnLock();
        }

        void Update()
        {
            Movement?.Update();
            Animation?.Update();
        }

        [Button]
        public void Lock()
        {
            IsLocked = true;
            Input.StopTracking();
            Collider2D.enabled = false;
            OnInputChange.Invoke(IsLocked);
        }

        [Button]
        public void UnLock()
        {
            IsLocked = false;
            Input.StartTracking();
            Collider2D.enabled = true;
            OnInputChange.Invoke(IsLocked);
        }

        [Button]
        public void Deactivate() => gameObject.SetActive(false);

        [Button]
        public void Active() => gameObject.SetActive(true);

        #region Properties

        public UiPlayerParameters Parameters => parameters;
        public Rigidbody2D Rigidbody2D { get; private set; }
        public Collider2D Collider2D { get; private set; }
        public SpriteRenderer Sprite { get; private set; }
        public Animator Animator { get; private set; }
        public MonoBehaviour MonoBehavior => this;
        public UiPlayerMovement Movement { get; private set; }
        public UiPlayerAttributes Attributes { get; private set; }
        public UiPlayerAnimator Animation { get; private set; }
        public ISpaceMarineInput Input { get; private set; }
        public bool IsLocked { get; private set; }

        #endregion
    }
}