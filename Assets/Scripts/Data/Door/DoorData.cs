using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine.Data
{
    [CreateAssetMenu(menuName = "Data/Door")]
    public class DoorData : ScriptableObject
    {
        [Tooltip("Description of the enemy.")] [Multiline]
        public string Description;

        [Range(0, 20)] [SerializeField] int health;

        [Tooltip("The creature type identification.")]
        public DoorId Id;

        [Tooltip("Instantiated object")] [SerializeField]
        GameObject model;

        [Tooltip("Name shown to the user.")] public string Name;

        [Tooltip("The Default Doors")] public DoorData Prototype;


        public int Health => Prototype.health + health;
        public GameObject Model => Prototype.model;
    }
}