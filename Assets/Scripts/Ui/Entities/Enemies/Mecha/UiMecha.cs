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