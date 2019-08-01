using System.Collections;
using System.Collections.Generic;
using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools;
using Tools.Dialog;
using UnityEngine;

namespace SpaceMarine
{
    public class UiDoorBulletHandler : UiGameEventListener, UiBullet.IBulletHandler, GameEvent.IDoorTakeDamage, GameEvent.IDestroyDoor
    {
        [Header("Destroyamage Parameters")]
        public Vector2 IntervalExplosions;
        public int QuantityExplosions;
        public Color HitColor;
        
        [Header("Prefabs")]
        public GameObject ExplosionPrefab;
        public SpriteRenderer SpriteRenderer;
        
        UiDoor UiDoor { get; set; }
        ShakeAnimation Shake { get; set; }
        
        
        protected override void Awake()
        {
            base.Awake();
            Shake = GetComponent<ShakeAnimation>();
            UiDoor = GetComponent<UiDoor>();
        }

        public void OnCollideBullet(UiBullet bullet)
        {
            if (bullet == null)
                return;
            
            var dam = bullet.Damage;
            var door = UiDoor.Door; 
            door.TakeDamage(dam);
        }

        public void OnTakeDamage(IDoor door, int damage)
        {
            if(door.Id == UiDoor.Id && isActiveAndEnabled)
            {
                SpriteRenderer.color = HitColor;
                Shake.Shake();
                StartCoroutine(MakeItWhileAgain());
            }
        }

        private IEnumerator MakeItWhileAgain()
        {
            yield return new WaitForSeconds(0.2f);
            SpriteRenderer.color = Color.white;
        }

        public void OnDestroyDoor(IDoor door)
        {
            if(door.Id == UiDoor.Id && isActiveAndEnabled)
                StartCoroutine(AnimateExplosion());
        }

        IEnumerator AnimateExplosion()
        {
            void Explode()
            {
                var explosion = UiObjectsPooler.Instance.Get(ExplosionPrefab);
                var bounds = SpriteRenderer.bounds;
                var x = Random.Range(bounds.min.x, bounds.max.x);
                var y = Random.Range(bounds.min.y, bounds.max.y);
                var rndPosWithin = new Vector3(x, y, 0);
                explosion.transform.position = rndPosWithin;
            }
            
            Explode();
            
            for (var i = 1; i < QuantityExplosions; i++)
            {
                var delayUntilNext = Random.Range(IntervalExplosions.x, IntervalExplosions.y);
                yield return new WaitForSeconds(delayUntilNext);
                Explode();
                
                if(i == QuantityExplosions -1)
                    UiObjectsPooler.Instance.Release(gameObject);
            }
        }
    }
}
