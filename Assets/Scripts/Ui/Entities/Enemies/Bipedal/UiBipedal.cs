using Patterns.StateMachine;
using SpaceMarine.Data;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiBipedal : UiEnemy, IStateMachineHandler
    {
        public MonoBehaviour MonoBehaviour => this;
        UiEnemyFSM Behaviors { get; set; }
        
        public override void Initialize(IEnemy runtimeData)
        {
            base.Initialize(runtimeData);
            var dataBipedal = Data as BipedalData;
            var pa = (Vector3) dataBipedal.PointA + transform.parent.position;
            var pb = (Vector3) dataBipedal.PointB + transform.parent.position;
            Behaviors = new BipedalBehavior(this, pa, pb);
        }

        void Update()
        {
            Behaviors.Update();
        }
    }
}