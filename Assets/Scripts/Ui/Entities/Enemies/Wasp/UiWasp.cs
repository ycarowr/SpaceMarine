namespace SpaceMarine
{
    public class UiWasp : UiEnemy
    {
        public override void OnCollideBullet(UiBullet bullet)
        {
            var damage = bullet.Damage;
            TryTakeDamage(damage);
        }
    }
}