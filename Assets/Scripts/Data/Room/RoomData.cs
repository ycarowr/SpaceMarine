using System;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine.Data
{
    [CreateAssetMenu(menuName = "Data/Room")]
    public class RoomData : ScriptableObject
    {
        [Tooltip("Description of the enemy.")] [Multiline]
        public string Description;

        [Tooltip("Doors inside the room.")] public DoorSpot[] Doors;

        [Tooltip("Creatures inside the room.")]
        public EnemySpot[] Enemies;

        [Tooltip("The creature type identification.")]
        public RoomId Id;

        [Tooltip("Name shown to the user.")] public string Name;
    }

    [Serializable]
    public class EnemySpot
    {
        [Tooltip("Creature inside the room.")] public EnemyData Enemy;

        [Tooltip("Placed Local Position.")] public Vector2 Position;
    }

    [Serializable]
    public class DoorSpot
    {
        [Tooltip("Doors inside the room.")] public DoorData Door;

        [Tooltip("Placed Local Position.")] public Vector2 Position;
    }
}