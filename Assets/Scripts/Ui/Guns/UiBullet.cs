using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiBullet : MonoBehaviour
    {
        IUiPlayer MyUiPlayer => UiPlayer.Instance;
        public Rigidbody2D Rigidbody2D;
        public TrailRenderer Trail;
        public SpriteRenderer SpriteRenderer;
        public int Damage { get; private set; }
        private Coroutine KeepAliveRoutine { get; set; }
        public GameObject BulletSplashPrefab;

        //------------------------------------------------------------------------------------------------------------------

        public struct BulletTriggerInfo
        {
            public int Direction { get; set; }
            public float Velocity { get; set; }
            public float Precision { get; set; }
            public float Adjustment { get; set; }
            public float LifeSpan { get; set; }
            public int Damage { get; set; }
        }
        
        public void Fire(BulletTriggerInfo info)
        {
            var precision = info.Precision;
            var adjustment = info.Adjustment;
            var velocity = info.Velocity;
            var xDirection = info.Direction;
            var lifeSpan = info.LifeSpan;
            var newVelocity = Rigidbody2D.velocity;

            Damage = info.Damage;
            newVelocity.y = GetAccuracy(precision) + adjustment;
            newVelocity.x = velocity * xDirection;
            SpriteRenderer.flipX = xDirection == -1;
            Rigidbody2D.velocity = newVelocity;
            Activate();
            
            KeepAliveRoutine = StartCoroutine(KeepAlive(lifeSpan));
        }

        float GetAccuracy(float precision)
        {
            return Random.Range(-precision, precision);
        }

        IEnumerator KeepAlive(float delay)
        {    
            yield return new WaitForSeconds(delay);
            Deactivate();
        }

        void Activate()
        {
            gameObject.SetActive(true);
        }
        
        void Deactivate()
        {
            if (KeepAliveRoutine != null)
            {
                StopCoroutine(KeepAliveRoutine);
                KeepAliveRoutine = null;
            }
            Trail.Clear();
            UiObjectsPooler.Instance.Release(gameObject);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            var handler = other.GetComponent<IBulletHandler>();
            if (handler == null)
                return;
            handler?.OnCollideBullet(this);
            var splash = UiObjectsPooler.Instance.Get<UiBulletSplash>(BulletSplashPrefab);
            var position = transform.position;
            splash.transform.position = position;
            splash.Animate(SpriteRenderer.flipX);
            Deactivate();
        }
    }
}