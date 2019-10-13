using Tools.Patterns.StateMachine;

namespace SpaceMarine
{
    public partial class UiEnemy
    {
        public abstract partial class UiEnemyFSM : BaseStateMachine
        {
            protected UiEnemyFSM(IStateMachineHandler handler) : base(handler)
            {
            }

            public abstract Patrol PatrolState { get; protected set; }
            public abstract Alert AlertState { get; protected set; }

            /// <summary>
            ///     Patrols the area.
            /// </summary>
            public void PatrolArea() => PushState(PatrolState);

            /// <summary>
            ///     Stay alert. Fired when the player reaches its range.
            /// </summary>
            public void StayAlert() => PushState(AlertState);
        }
    }
}