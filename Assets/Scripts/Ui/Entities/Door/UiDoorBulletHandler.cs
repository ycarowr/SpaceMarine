using System.Collections;
using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools;
using UnityEngine;

namespace SpaceMarine
{
    public class UiDoorBulletHandler : UiGameEventListener,
        UiBullet.IBulletHandler,
        GameEvent.IDoorTakeDamage,
        GameEvent.IDestroyDoor
    {
        [Header("Prefabs")] public GameObject ExplosionPrefab;

        public Color HitColor;

        [Header("Destroy damage Parameters")] public Vector2 IntervalExplosions;

        public int QuantityExplosions;
        public SpriteRenderer SpriteRenderer;

        UiDoor UiDoor { get; set; }
        ShakeAnimation Shake { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        void UiBullet.IBulletHandler.OnCollideBullet(UiBullet bullet)
        {
            if (bullet == null)
                return;

            var dam = bullet.Damage;
            var door = UiDoor.Door;
            door.TakeDamage(dam);
        }

        void GameEvent.IDestroyDoor.OnDestroyDoor(IDoor door)
        {
            if (door.Id == UiDoor.Id && isActiveAndEnabled)
                StartCoroutine(AnimateExplosion());
        }

        void GameEvent.IDoorTakeDamage.OnTakeDamage(IDoor door, int damage)
        {
            if (door.Id == UiDoor.Id && isActiveAndEnabled)
            {
                SpriteRenderer.color = HitColor;
                Shake.Shake();
                StartCoroutine(MakeItWhiteAgain());
            }
        }


        protected override void Awake()
        {
            base.Awake();
            Shake = GetComponent<ShakeAnimation>();
            UiDoor = GetComponent<UiDoor>();
        }

        //--------------------------------------------------------------------------------------------------------------

        IEnumerator MakeItWhiteAgain()
        {
            yield return new WaitForSeconds(0.2f);
            SpriteRenderer.color = Color.white;
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

                if (i == QuantityExplosions - 1)
                    UiObjectsPooler.Instance.Release(gameObject);
            }
        }
    }
}