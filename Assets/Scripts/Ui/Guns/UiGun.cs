using System.Diagnostics.Tracing;
using Patterns.GameEvents;
using SpaceMarine.Input;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiGun : UiGameEventListener, 
        Events.IPlayerEquip, Events.IPlayerShoot, Events.IPlayerReload, Events.ICreateGame
    {
        public IGunData GunData { get; set; }

        [Tooltip("Place in world space where the bullets are spawned.")]
        public Transform BulletSpawn;
        
        public IUiPlayer UiPlayer { get; private set; }
        private UiGunInput GunInput { get; set;}
        
        
        //--------------------------------------------------------------------------------------------------------------

        protected override void Awake()
        {
            base.Awake();
            UiPlayer = GetComponent<IUiPlayer>();
        }
        
        public void OnCreateGame(IGame runtimeGame)
        {
            GunInput = new UiGunInput(this);
            TestEquip();
        }
        

        //--------------------------------------------------------------------------------------------------------------

        public void Update()
        {
            GunInput?.Update();
        }
        
        //--------------------------------------------------------------------------------------------------------------
        
        void Events.IPlayerEquip.OnEquip(IShooter player, IGunData gunData)
        {
            Equip(gunData);
        }

        void Events.IPlayerShoot.OnShoot(IShooter player)
        {
            if (GunData == null)
                return;

            var bullet = UiObjectsPooler.Instance.Get<UiBullet>(GunData.Bullet);
            
            //define bullet direction
            var xDirection = UiPlayer.Sprite.flipX ? -1 : 1;
            
            //define starting position
            bullet.transform.position = BulletSpawn.position;
            
            //go
            var velocity = GunData.Velocity;
            var precision = GunData.Precision;
            var adjustment = GunData.Adjustment;
            var info = new UiBullet.BulletTriggerInfo()
            {
                Damage = GunData.Damage,
                LifeSpan = GunData.BulletLifeSpan,
                Adjustment = adjustment,
                Velocity = velocity,
                Direction = xDirection,
                Precision = precision
            };
            
            bullet.Fire(info);
        }

        void Events.IPlayerReload.OnReload(IShooter player)
        {
                
        }

        private void Equip(IGunData gunData)
        {
            GunData = gunData;
        }
        
        //--------------------------------------------------------------------------------------------------------------

        [Header("Test")] public GunData testGun;

        [Button]
        void TestEquip()
        {
            GunInput?.TryEquip(testGun);
        }
    }
}