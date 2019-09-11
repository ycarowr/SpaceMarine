using UnityEngine;

namespace SpaceMarine.Data
{
    public class Walker : RuntimeEnemy
    {
        public Walker(EnemyData data, Vector3 startPosition) : base(data, startPosition)
        {
        }
    }
}