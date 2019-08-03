using System.Collections;
using System.Collections.Generic;
using Patterns;
using Patterns.GameEvents;
using SpaceMarine.Data;
using SpaceMarine.Model;
using Tools;
using UnityEngine;
using UnityEngine.Analytics;


namespace SpaceMarine
{
    public class UiEnemy : UiBaseEntity, IListener,
        UiBullet.IBulletHandler, 
        GameEvent.IDestroyEnemy, 
        GameEvent.IEnemyTakeDamage
    {
        public EnemyId Id;
        public IEnemy Enemy { get; set; }
        ShakeAnimation Shake { get; set; }


        private void Start()
        {
            GameEvents.Instance.AddListener(this);
            Shake = GetComponent<ShakeAnimation>();
            Test();
        }

        public void TryTakeDamage(int damage)
        {
            Enemy.TakeDamage(damage);
        }

        protected virtual IEnumerator TakeDamageAnimation()
        {
            yield return StartCoroutine(AnimateDamage());
        }
        
        protected virtual IEnumerator DestroyAnimation()
        {
            yield return AnimateExplosion();
        }
        
        //--------------------------------------------------------------------------------------------------------------
        
        public virtual void OnDestroyEnemy(IEnemy enemy)
        {
            if (enemy != Enemy)
                return;
            
            StartCoroutine(DestroyAnimation());
        }

        public virtual void OnTakeDamage(IEnemy enemy, int damage)
        {
            if (enemy != Enemy)
                return;

            StartCoroutine(TakeDamageAnimation());
        }
        
        public virtual void OnCollideBullet(UiBullet bullet)
        {
            
        }
        
        //--------------------------------------------------------------------------------------------------------------

        IEnumerator AnimateDamage()
        {
            SpriteRenderer.color = Enemy.Data.HitColor;
            Shake?.Shake();
            yield return StartCoroutine(MakeItWhiteAgain());
        }
        
        IEnumerator MakeItWhiteAgain()
        {
            yield return new WaitForSeconds(0.2f);
            SpriteRenderer.color = Color.white;
        }

        IEnumerator AnimateExplosion()
        {
            var quantity = Enemy.Data.QuantityExplosions;
            var model = Enemy.Data.Explosion;
            var interval = Enemy.Data.IntervalExplosions;
            var pooler = UiObjectsPooler.Instance;
            
            void Explode()
            {
                var explosion = pooler.Get(model);
                var bounds = SpriteRenderer.bounds;
                var x = Random.Range(bounds.min.x, bounds.max.x);
                var y = Random.Range(bounds.min.y, bounds.max.y);
                var rndPosWithin = new Vector3(x, y, 0);
                explosion.transform.position = rndPosWithin;
            }
            
            Explode();
            
            for (var i = 1; i < quantity; i++)
            {
                var delayUntilNext = Random.Range(interval.x, interval.y);
                yield return new WaitForSeconds(delayUntilNext);
                Explode();
                
                if(i == quantity -1)
                    pooler.Release(gameObject);
            }
        }

        //--------------------------------------------------------------------------------------------------------------

        public EnemyData Data;
        
        [Button]
        public void Test()
        {
            Enemy = Data.GetEnemy(transform.position);
        }

        [Button]
        public void TryTakeDamage()
        {
            TryTakeDamage(1);
        }
    }
}
