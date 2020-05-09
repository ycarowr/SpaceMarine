using SpaceMarine.Data;
using SpaceMarine.Model;
using Tools.Patterns.StateMachine;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiBipedal : UiEnemy, IStateMachineHandler
    {
        UiEnemyFSM Behaviors { get; set; }
        public MonoBehaviour MonoBehaviour => this;
        public Transform Offset;

        public override void Initialize(IEnemy runtimeData)
        {
            base.Initialize(runtimeData);
            var dataBipedal = Data as BipedalData;
            var pa = (Vector3) dataBipedal.PointA + transform.parent.position;
            var pb = (Vector3) dataBipedal.PointB + transform.parent.position;
            Behaviors = new BipedalBehavior(this, pa, pb, Offset);
        }

        void Update() => Behaviors.Update();
    }
}