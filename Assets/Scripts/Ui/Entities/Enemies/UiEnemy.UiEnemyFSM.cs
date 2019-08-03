using Patterns.StateMachine;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiEnemy
    {
        public abstract partial class UiEnemyFSM : BaseStateMachine 
        {
            public abstract Patrol PatrolState { get; protected set; }
            public abstract Alert AlertState { get; protected set; }

            protected UiEnemyFSM(IStateMachineHandler handler) : base(handler)
            {
                
            }

            /// <summary>
            ///     Patrols the area.
            /// </summary>
            public void PatrolArea()
            {
                PushState(PatrolState);
            }

            /// <summary>
            ///     Stay alert. Fired when the player reaches its range.
            /// </summary>
            public void StayAlert()
            {
                PushState(AlertState);
            }
        }
    }
}