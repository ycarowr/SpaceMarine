using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine.Data
{
    public abstract class EnemyData : ScriptableObject
    {
        [Tooltip("Total reduction of the damage taken.")] [Range(0, 10)]
        public int Armor;

        [Tooltip("The damage which the enemy intents to cause.")] [Range(0, 10)]
        public int Attack;

        [Tooltip("Description of the enemy.")] [Multiline]
        public string Description;


        //TODO: Create a protype to hold the common data
        [Tooltip("Explosion when the object is destroyed")] [Header("Destroy")]
        public GameObject Explosion;

        [Tooltip("Total of damage needed to kill this unit.")] [Range(0, 10)]
        public int Health;

        [Tooltip("Color animation when it takes damage.")]
        public Color HitColor;

        [Tooltip("Icon of the enemy.")] public Texture Icon;

        [Tooltip("The creature type identification.")]
        public EnemyId Id;

        [Tooltip("Interval in seconds between explosions")]
        public Vector2 IntervalExplosions;

        [Tooltip("The prefab of the creature.")]
        public GameObject Model;

        [Tooltip("Name shown to the user.")] public string Name;

        [Range(0, 50)] public int QuantityExplosions;

        [Tooltip("How fast it moves around the map.")] [Range(0, 50)]
        public int Speed;

        public abstract IEnemy GetEnemy(Vector3 startPosition);
    }
}