namespace SpaceMarine
{
    public class UiBipedalShield : UiBaseEntity, UiBullet.IBulletHandler
    {
        UiEnemy Ui { get; set; }

        public void OnCollideBullet(UiBullet bullet)
        {
            var damage = bullet.Damage;
            Ui.TryTakeDamage(damage);
        }

        protected override void Awake()
        {
            base.Awake();
            Ui = GetComponentInParent<UiEnemy>();
        }
    }
}