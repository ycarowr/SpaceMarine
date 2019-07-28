namespace SpaceMarine
{
    public partial class UiBullet
    {
        public interface IBulletHandler
        {
            void OnCollideBullet(UiBullet bullet);
        }
    }
}