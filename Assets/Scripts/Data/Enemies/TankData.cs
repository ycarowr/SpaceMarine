using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine.Data
{
    [CreateAssetMenu(menuName = "Data/Tank")]
    public class TankData : EnemyData
    {
        public override IEnemy GetEnemy()
        {
            return new Tank(this);
        }
    }
}
