using UnityEngine;

namespace SpaceMarine
{
    [CreateAssetMenu(menuName = "Data/Gun")]
    public class GunData : ScriptableObject
    {
        [Tooltip("How much the player can shoot before to run out of bullets.")][SerializeField] [Range(1, 30)] 
        private int ammo;
        
        [Tooltip("How much bullets it can fire per seconds.")][SerializeField] [Range(0, 30)] 
        private float rate;
        
        [Tooltip("Time in seconds to reload the gun.")]
        [SerializeField] [Range(0, 30)] private float reloadTime;
        
        [Tooltip("Icon of the gun.")]
        [SerializeField] private Sprite icon;

        [Tooltip("Pickable item on the ground that allows access to this gun.")]
        [SerializeField] private GameObject pickable;

        [Tooltip("Bullets shot by this gun.")] [SerializeField]
        private GameObject bullet;
        
        [Tooltip("Velocity on X of the projectile.")] 
        [SerializeField] [Range(1, 50)] private float velocity;
        
        [Tooltip("Precision on Y of the projectile.")] 
        [SerializeField] [Range(0.01f, 20)] private float precision;
        
        [Tooltip("Adjustment for precision")]
        [SerializeField] [Range(0.01f, 20)] private float adjustment = 0.02f;

        [Tooltip("Time that the projectile will be alive in seconds")]
        [SerializeField] [Range(0.01f, 20)] private float lifeSpan = 1;
        
        
        //--------------------------------------------------------------------------------------------------------------

        public int Ammo => ammo;
        public float Rate => rate;
        public float ReloadTime => reloadTime;
        public GameObject Bullet => bullet;
        public float Velocity => velocity;
        public float Precision => precision;
        public float LifeSpan => lifeSpan;
        public float Adjustment => adjustment;
    }
}