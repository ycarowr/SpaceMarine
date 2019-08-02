using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine.Data
{
    [CreateAssetMenu(menuName = "Data/Mecha")]
    public class MechaData : EnemyData
    {
        public override IEnemy GetEnemy()
        {
            return new Mecha(this);
        }
    }
}
