using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine.Data
{
    [CreateAssetMenu(menuName = "Data/Bipedal")]
    public class BipedalData : EnemyData
    {
        public override IEnemy GetEnemy()
        {
            return new Bipedal(this);
        }
    }
}
