using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine.Data
{
    [CreateAssetMenu(menuName = "Data/Bipedal")]
    public class BipedalData : EnemyData
    {
        public Vector2 PointA;
        public Vector2 PointB;

        public override IEnemy GetEnemy(Vector3 startPosition) => new Bipedal(this, startPosition);
    }
}