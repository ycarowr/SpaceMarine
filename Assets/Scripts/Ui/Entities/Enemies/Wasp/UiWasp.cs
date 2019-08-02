using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Data;
using SpaceMarine.Model;


namespace SpaceMarine
{
    public partial class UiWasp : UiEnemy
    {
        public override void OnCollideBullet(UiBullet bullet)
        {
            var damage = bullet.Damage;
            TryTakeDamage(damage);
        }
    }
}
