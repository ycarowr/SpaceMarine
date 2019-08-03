using Patterns.StateMachine;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiBipedal
    {
        /// <summary>
        ///     Holds all bipedal UI behaviors.
        /// </summary>
        partial class BipedalBehavior : UiEnemyFSM
        {
            public override Patrol PatrolState { get; protected set; }
            public override Alert AlertState { get; protected set; }
            Transform PointA { get; }
            Transform PointB { get; }
            
            public BipedalBehavior(IStateMachineHandler handler, Transform pointA, Transform pointB) : base(handler)
            {
                PointA = pointA;
                PointB = pointB;
                Initialize();
            }

            protected override void OnBeforeInitialize()
            {
                PatrolState = new BipedalPatrol(this, PointA, PointB);
                AlertState = new Alert(this);
                RegisterState(PatrolState);
                RegisterState(AlertState);
            }

            protected override void OnInitialize()
            {
                PatrolArea();
            }
        }
    }
}