using Patterns.StateMachine;

namespace SpaceMarine
{
    public partial class UiEnemy
    {
        public partial class UiEnemyFSM
        {
            public class Patrol : BaseEnemyState<UiEnemyFSM>
            {
                public Patrol(UiEnemyFSM fsm) : base(fsm)
                {
                }
            }
        }
    }
}