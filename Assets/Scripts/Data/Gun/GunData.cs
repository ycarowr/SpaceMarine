using UnityEngine;

namespace SpaceMarine
{
    public interface IGunData
    {
        int ClipAmmo { get; }
        float Rate { get; }
        int Damage { get; }
        float ReloadTime { get; }
        GameObject Bullet { get; }
        float Velocity { get; }
        float Precision { get; }
        float BulletLifeSpan { get; }
        float Adjustment { get; }
    }

    [CreateAssetMenu(menuName = "Data/Gun")]
    public class GunData : ScriptableObject, IGunData
    {
        [Tooltip("Adjustment for precision")] [SerializeField] [Range(0.01f, 20)]
        float adjustment = 0.02f;

        [Tooltip("Bullets shot by this gun.")] [SerializeField]
        GameObject bullet;

        [Header("Global")]
        [Tooltip("Time that the projectile will be alive in seconds")]
        [SerializeField]
        [Range(0.01f, 20)]
        float bulletLifeSpan = 1;

        [Header("Configs")]
        [Tooltip("How much the player can shoot before to run out of bullets.")]
        [SerializeField]
        [Range(1, 30)]
        int clipAmmo;

        [Tooltip("Damage of the bullets of this gun.")] [SerializeField] [Range(1, 10)]
        int damage;

        [Header("Visual")] [Tooltip("Icon of the gun.")] [SerializeField]
        Sprite icon;

        [Tooltip("Pick able item on the ground that allows access to this gun.")] [SerializeField]
        GameObject pickable;

        [Tooltip("Precision of the projectile on Y axis.")] [SerializeField] [Range(0.01f, 20)]
        float precision;

        [Tooltip("How much bullets it can fire per second.")] [SerializeField] [Range(0, 30)]
        float rate;

        [Tooltip("Time to reload the gun in seconds.")] [SerializeField] [Range(0, 30)]
        float reloadTime;

        [Tooltip("Velocity of the projectile on the X axis.")] [SerializeField] [Range(1, 50)]
        float velocity;

        //--------------------------------------------------------------------------------------------------------------

        public int ClipAmmo => clipAmmo;
        public float Rate => rate;
        public float ReloadTime => reloadTime;
        public GameObject Bullet => bullet;
        public float Velocity => velocity;
        public float Precision => precision;
        public float BulletLifeSpan => bulletLifeSpan;
        public float Adjustment => adjustment;
        public int Damage => damage;
    }
}