using System.Collections;
using System.Collections.Generic;
using Patterns.StateMachine;
using SpaceMarine.Data;
using SpaceMarine.Model;
using UnityEngine;


namespace SpaceMarine
{
    public partial class UiBipedal : UiEnemy, IStateMachineHandler
    {
        public MonoBehaviour MonoBehaviour => this;
        public Transform PointA;
        public Transform PointB;
       
        UiEnemyFSM Behaviors { get; set; }

        protected override void Awake()
        {
            base.Awake();
            Behaviors = new BipedalBehavior(this, PointA, PointB);
        }

        void Update()
        {
            Behaviors.Update();
        }
    }
}
