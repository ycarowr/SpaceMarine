using Patterns.StateMachine;

namespace SpaceMarine
{
    public partial class UiEnemy
    {
        public partial class UiEnemyFSM
        {
            public abstract class BaseEnemyState <T>: IState where T : BaseStateMachine
            {
                public T Fsm { get; }
                public bool IsInitialized { get; }

                protected BaseEnemyState(T fsm)
                {
                    Fsm = fsm;
                }
                
                public virtual void OnInitialize()
                {

                }

                public virtual void OnEnterState()
                {
                }

                public virtual void OnExitState()
                {
                }

                public virtual void OnUpdate()
                {
                }

                public virtual void OnClear()
                {
                }

                public virtual void OnNextState(IState next)
                {
                }
            }
        }
    }
}