using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Data;
using SpaceMarine.Model;
using UnityEngine;


namespace SpaceMarine
{
    public class UiEnemy : UiBaseEntity
    {
        public EnemyId Id;
        public IEnemy Enemy { get; set; }
    }
}
