using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine.Data
{
    public abstract class EnemyData : ScriptableObject
    {   
        [Tooltip("Name shown to the user.")]
        public string Name;
        
        [Tooltip("The creature type identification.")]
        public EnemyId Id;
        
        [Tooltip("The damage which the enemy intents to cause.")] 
        [Range(0, 10)] public int Attack;
        
        [Tooltip("Total reduction of the damage taken.")]
        [Range(0, 10)] public int Armor;
        
        [Tooltip("Total of damage needed to kill this unit.")]
        [Range(0, 10)] public int Health;
        
        [Tooltip("How fast it moves around the map.")]
        [Range(0, 50)] public int Speed;

        [Tooltip("Description of the enemy.")] 
        [Multiline] public string Description;

        [Tooltip("The prefab of the creature.")]
        public GameObject Model;


        public abstract IEnemy GetEnemy();
    }
}
