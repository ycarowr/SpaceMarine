using Patterns.StateMachine;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiBipedal : UiEnemy, IStateMachineHandler
    {
        public Transform PointA;
        public Transform PointB;

        UiEnemyFSM Behaviors { get; set; }
        public MonoBehaviour MonoBehaviour => this;

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