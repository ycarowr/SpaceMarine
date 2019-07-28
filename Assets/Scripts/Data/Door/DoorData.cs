using System;
using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine.Data
{
    [CreateAssetMenu(menuName = "Data/Door")]
    public class DoorData : ScriptableObject
    {
        [Tooltip("The Default Doors")]
        public DoorData Prototype;
        
        [Range(0, 20), SerializeField]
        private int health;
        
        [Tooltip("Instantiated object"), SerializeField]
        private GameObject model;
        
        [Tooltip("Name shown to the user.")]
        public string Name;
        
        [Tooltip("The creature type identification.")]
        public DoorId Id;

        [Tooltip("Description of the enemy.")] 
        [Multiline] public string Description;


        public int Health => Prototype.health + health;
        public GameObject Model => Prototype.model;
    }
}
