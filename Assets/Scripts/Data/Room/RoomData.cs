using System;
using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine.Data
{
    [CreateAssetMenu(menuName = "Data/Room")]
    public class RoomData : ScriptableObject
    {   
        [Tooltip("Name shown to the user.")]
        public string Name;
        
        [Tooltip("The creature type identification.")]
        public RoomId Id;

        [Tooltip("Description of the enemy.")] 
        [Multiline] public string Description;

        [Tooltip("Creatures inside the room.")]
        public EnemySpot[] Enemies;
    }

    [Serializable]
    public class EnemySpot
    {
        [Tooltip("Creature inside the room.")]
        public EnemyData Enemy;

        [Tooltip("Placed Local Position.")]
        public Vector2 Position;
    }
}
