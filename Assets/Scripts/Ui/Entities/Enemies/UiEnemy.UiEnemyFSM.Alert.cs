namespace SpaceMarine
{
    public partial class UiEnemy
    {
        public partial class UiEnemyFSM
        {
            public class Alert : BaseEnemyState<UiEnemyFSM>
            {
                public Alert(UiEnemyFSM fsm) : base(fsm)
                {
                }
            }
        }
    }
}