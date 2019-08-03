using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine.Data
{
    [CreateAssetMenu(menuName = "Data/Mecha")]
    public class MechaData : EnemyData
    {
        public override IEnemy GetEnemy(Vector3 startPosition)
        {
            return new Mecha(this, startPosition);
        }
    }
}