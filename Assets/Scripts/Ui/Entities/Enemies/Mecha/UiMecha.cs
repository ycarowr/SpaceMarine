using System.Collections;
using System.Collections.Generic;
using SpaceMarine;
using UnityEngine;

namespace SpaceMarine
{
    public class UiMecha : UiEnemy
    {
        public override void OnCollideBullet(UiBullet bullet)
        {
            var damage = bullet.Damage;
            TryTakeDamage(damage);
        }
    }
}