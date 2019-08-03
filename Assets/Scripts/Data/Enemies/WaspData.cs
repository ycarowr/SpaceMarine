using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine.Data
{
    [CreateAssetMenu(menuName = "Data/Wasp")]
    public class WaspData : EnemyData
    {
        public override IEnemy GetEnemy(Vector3 startPosition)
        {
            return new Wasp(this, startPosition);
        }
    }
}