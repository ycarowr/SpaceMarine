using Patterns.GameEvents;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiGun : UiGameEventListener,
        GameEvent.IPlayerEquip, GameEvent.IPlayerShoot, GameEvent.IPlayerReload, GameEvent.ICreateGame
    {
        [Tooltip("Place in world space where the bullets are spawned.")]
        public Transform BulletSpawn;

        //--------------------------------------------------------------------------------------------------------------

        [Header("Test")] public GunData testGun;
        public IGunData GunData { get; set; }

        public IUiPlayer UiPlayer { get; private set; }
        UiGunInput GunInput { get; set; }

        public void OnCreateGame(IGame runtimeGame)
        {
            GunInput = new UiGunInput(this);
            TestEquip();
        }

        //--------------------------------------------------------------------------------------------------------------

        void GameEvent.IPlayerEquip.OnEquip(IShooter player, IGunData gunData)
        {
            Equip(gunData);
        }

        void GameEvent.IPlayerReload.OnReload(IShooter player)
        {
        }

        void GameEvent.IPlayerShoot.OnShoot(IShooter player)
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
            var info = new UiBullet.BulletTriggerInfo
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


        //--------------------------------------------------------------------------------------------------------------

        protected override void Awake()
        {
            base.Awake();
            UiPlayer = GetComponent<IUiPlayer>();
        }


        //--------------------------------------------------------------------------------------------------------------

        public void Update()
        {
            GunInput?.Update();
        }

        void Equip(IGunData gunData)
        {
            GunData = gunData;
        }

        [Button]
        void TestEquip()
        {
            GunInput?.TryEquip(testGun);
        }
    }
}