namespace SpaceMarine
{
    public class UiWalker : UiEnemy
    {
        public override void OnCollideBullet(UiBullet bullet)
        {
            var damage = bullet.Damage;
            TryTakeDamage(damage);
        }
    }
}