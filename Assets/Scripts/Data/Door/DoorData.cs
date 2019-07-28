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
        [Range(1, 20)]
        public int Health;
        
        [Tooltip("Name shown to the user.")]
        public string Name;
        
        [Tooltip("The creature type identification.")]
        public DoorId Id;

        [Tooltip("Description of the enemy.")] 
        [Multiline] public string Description;

        [Tooltip("Instantiated object")]
        public GameObject DoorPrefab;
    }
}
