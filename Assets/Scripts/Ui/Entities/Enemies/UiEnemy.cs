using System.Collections;
using System.Collections.Generic;
using Patterns;
using Patterns.GameEvents;
using SpaceMarine.Data;
using SpaceMarine.Model;
using UnityEngine;
using UnityEngine.Analytics;


namespace SpaceMarine
{
    public class UiEnemy : UiBaseEntity, UiBullet.IBulletHandler, IListener, GameEvent.IDestroyEnemy, GameEvent.IEnemyTakeDamage
    {
        public EnemyId Id;
        public IEnemy Enemy { get; set; }

        private void Start()
        {
            GameEvents.Instance.AddListener(this);
            Test();
        }


        [Button]
        public void TryTakeDamage(int damage)
        {
            Enemy.TakeDamage(damage);
        }
        
        //--------------------------------------------------------------------------------------------------------------
        
        void GameEvent.IDestroyEnemy.OnDestroyEnemy(IEnemy enemy)
        {
            Debug.Log("Destroy enemy");
        }

        void GameEvent.IEnemyTakeDamage.OnTakeDamage(IEnemy enemy, int damage)
        {
            Debug.Log("Take damage: "+damage);
        }
        
        void UiBullet.IBulletHandler.OnCollideBullet(UiBullet bullet)
        {
            Debug.Log("SHielded");
        }

        //--------------------------------------------------------------------------------------------------------------

        public EnemyData Data;
        
        [Button]
        public void Test()
        {
            Enemy = Data.GetEnemy();
        }
    }
}
