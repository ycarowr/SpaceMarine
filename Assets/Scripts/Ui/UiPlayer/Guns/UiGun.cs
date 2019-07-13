using SpaceMarine.Input;
using UnityEngine;

namespace SpaceMarine
{
    public class UiGun : IGun
    {
        public IUiPlayer UiPlayer { get; }
        public GunData Data { get; private set; }
        public int CurrentAmmo { get; private set; }
        private Transform Spawn { get; }
        private float timeRate;
        
        //--------------------------------------------------------------------------------------------------------------

        public UiGun(IUiPlayer uiPlayer, Transform bulletSpawn, GunData data)
        {
            UiPlayer = uiPlayer;
            SetGunData(data);
            Spawn = bulletSpawn;
        }
        
        
        //--------------------------------------------------------------------------------------------------------------

        
        public void SetGunData(GunData data)
        {
            Data = data;
        }

        public void Update()
        {
            if (!UiPlayer.Input.IsShootPressed)
            {
                timeRate = Data.Rate;
                return;
            }

            if(timeRate < 1f/Data.Rate)
                timeRate += Time.deltaTime;
            else
            {
                timeRate = 0;
                Shoot();   
            }
        }
        
        public void Shoot()
        {
            if (!Data)
                return;

            var bullet = BulletPooler.Instance.Get<Bullet>(Data.Bullet);
            
            //define direction
            var xDirection = UiPlayer.Sprite.flipX ? -1 : 1;
            
            //define starting position
            bullet.transform.position = Spawn.position;
            
            //go
            var velocity = Data.Velocity;
            var precision = Data.Precision;
            var adjustment = Data.Adjustment;
            bullet.Move(xDirection, velocity, precision, adjustment, Data.LifeSpan);
        }

        public void Reload()
        {
            if (!Data)
                return;
            
            //TODO: Refill ammo after a certain amount of time. Setup coroutine.
        }

        private void OnOutOfAmmo()
        {
            //TODO: Raise out of ammo event.
        }
    }
}