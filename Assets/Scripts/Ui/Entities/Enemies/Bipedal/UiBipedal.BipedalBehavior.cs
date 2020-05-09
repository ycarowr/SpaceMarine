using Tools.Patterns.StateMachine;
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
            public BipedalBehavior(IStateMachineHandler handler, Vector3 pointA, Vector3 pointB, Transform collisionOffset) : base(handler)
            {
                PointA = pointA;
                PointB = pointB;
                CollisionOffset = collisionOffset;
                Initialize();
            }

            public Transform CollisionOffset { get; }
            public override Patrol PatrolState { get; protected set; }
            public override Alert AlertState { get; protected set; }
            Vector3 PointA { get; }
            Vector3 PointB { get; }

            protected override void OnBeforeInitialize()
            {
                PatrolState = new BipedalPatrol(this, PointA, PointB);
                AlertState = new Alert(this);
                RegisterState(PatrolState);
                RegisterState(AlertState);
            }

            protected override void OnInitialize() => PatrolArea();
        }
    }
}