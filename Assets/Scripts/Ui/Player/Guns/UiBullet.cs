using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceMarine
{
    public class UiBullet : MonoBehaviour
    {
        private Rigidbody2D Rigidbody2D { get; set; }
        private TrailRenderer Trail { get; set; }

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Trail = GetComponent<TrailRenderer>();
        }


        //------------------------------------------------------------------------------------------------------------------

        public void Move(int xDirection, float velocity, float precision, float adjustment, float lifeSpan)
        {
            var newVelocity = Rigidbody2D.velocity;
            newVelocity.y = GetAccuracy(precision) + adjustment;
            newVelocity.x = velocity * xDirection;
            
            Rigidbody2D.velocity = newVelocity;
            Activate();
            
            StartCoroutine(KeepAlive(lifeSpan));
        }

        float GetAccuracy(float precision)
        {
            return Random.Range(-precision, precision);
        }

        public IEnumerator KeepAlive(float delay)
        {    
            yield return new WaitForSeconds(delay);
            Deactivate();
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }
        
        public void Deactivate()
        {
            Trail.Clear();
            UiBulletPooler.Instance.Release(gameObject);
        }
    }
}