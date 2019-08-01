﻿using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine.Data
{
    [CreateAssetMenu(menuName = "Data/Walker")]
    public class WalkerData : EnemyData
    {
        public override IEnemy GetEnemy()
        {
            return new Walker(this);
        }
    }
}