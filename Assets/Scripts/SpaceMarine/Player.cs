using System;
using Patterns;
using SpaceMarine.Input;
using UnityEditor;
using UnityEngine;

namespace SpaceMarine
{
    public class Player : SingletonMB<Player>, IPlayer
    {
        public Action<bool> OnChangeUserPermission = (isLocked) => { };
        #region Set by editor
        
        [SerializeField] private PlayerParameters parameters;
        [SerializeField] private Transform bulletSpawn;
        [SerializeField] private Transform spawnPoint;
        
        #endregion
        
        #region Properties
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
        public IGun Gun { get; private set; }
        public Death Death { get; private set; }
        public Spawn Spawn { get; private set; }
        public bool IsLocked { get; private set; }
        
        #endregion


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
            Death = new Death(this);
            Spawn = new Spawn(this, spawnPoint);
            Gun = new Gun(this, bulletSpawn, dataTest);
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
            OnChangeUserPermission.Invoke(IsLocked);
        }
        
        [Button]
        public void UnLock()
        {
            IsLocked = false;
            Input.StartTracking();
            OnChangeUserPermission.Invoke(IsLocked);
        }

        [Button]
        public void Die()
        {
            Death.Die();
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