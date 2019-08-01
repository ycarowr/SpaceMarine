using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Data;
using SpaceMarine.Model;
using Tools.UI;
using UnityEngine;


namespace SpaceMarine
{
    public class UiBipedalShield : UiBaseEntity, UiBullet.IBulletHandler
    {
        private UiEnemy Ui { get; set; }
        
        protected override void Awake()
        {
            base.Awake();
            Ui = GetComponentInParent<UiEnemy>();
        }

        public void OnCollideBullet(UiBullet bullet)
        {
            var damage = bullet.Damage;
            Ui.TryTakeDamage(damage);
        }
    }
}
