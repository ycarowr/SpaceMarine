using System;
using Patterns;
using SpaceMarine.Input;
using UnityEditor;
using UnityEngine;

namespace SpaceMarine
{
    public class UiPlayer : SingletonMB<UiPlayer>, IUiPlayer
    {
        public Action<bool> OnChangeUserPermission = (isLocked) => { };
        #region Set by editor
        
        [SerializeField] private UiPlayerParameters parameters;
        [SerializeField] private Transform bulletSpawn;
        [SerializeField] private Transform spawnPoint;
        
        #endregion
        
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
        public IGun Gun { get; private set; }
        public UiDeath UiDeath { get; private set; }
        public UiSpawn Spawn { get; private set; }
        public bool IsLocked { get; private set; }
        
        #endregion


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
            Spawn = new UiSpawn(this, spawnPoint);
            Gun = new UiGun(this, bulletSpawn, dataTest);
            UnLock();
        }

        private void Update()
        {
            Movement?.Update();
            Animation?.Update();
            Gun?.Update();
        }

        [Button]
        public void Lock()
        {
            IsLocked = true;
            Input.StopTracking();
            Collider2D.enabled = false;
            OnChangeUserPermission.Invoke(IsLocked);
        }
        
        [Button]
        public void UnLock()
        {
            IsLocked = false;
            Input.StartTracking();
            Collider2D.enabled = true;
            OnChangeUserPermission.Invoke(IsLocked);
        }

        [Button]
        public void Die()
        {
            UiDeath.Die();
        }

        [Button]
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        [Button]
        public void Active()
        {
            gameObject.SetActive(true);
        }

        public void Equip(GunData data)
        {
            Gun?.SetGunData(data);
        }

        public GunData dataTest;
        [Button]
        public void EquipTest()
        {
            Equip(dataTest);
        }
    }
}