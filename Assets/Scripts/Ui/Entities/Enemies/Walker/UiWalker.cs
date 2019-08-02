using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Data;
using SpaceMarine.Model;


namespace SpaceMarine
{
    public partial class UiWalker : UiEnemy
    {
        public override void OnCollideBullet(UiBullet bullet)
        {
            var damage = bullet.Damage;
            TryTakeDamage(damage);
        }
    }
}
