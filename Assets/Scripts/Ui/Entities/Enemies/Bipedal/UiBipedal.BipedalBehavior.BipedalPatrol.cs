using System.Collections;
using SpaceMarine.Data;
using SpaceMarine.Model;
using Tools.UiTransform;
using UnityEngine;

namespace SpaceMarine
{
    public partial class UiBipedal
    {
        partial class BipedalBehavior
        {
            /// <summary>
            ///     The patrol state of the bipedal enemy.
            /// </summary>
            class BipedalPatrol : Patrol, IUiMotionHandler
            {
                const float IdleTime = 3;
                const float Speed = 5;
                readonly int _idleAnimHash = Animator.StringToHash("Idle");
                readonly int _walkAnimHash = Animator.StringToHash("Walk");


                public BipedalPatrol(UiEnemyFSM fsm, Vector3 pointA, Vector3 pointB) : base(fsm)
                {
                    PointA = pointA;
                    PointB = pointB;
                    Animator = Fsm.Handler.MonoBehaviour.GetComponent<Animator>();
                    SpriteRenderer = Fsm.Handler.MonoBehaviour.GetComponent<SpriteRenderer>();
                    Current = State.PointA;
                    Motion = new UiMotion(this);
                    Motion.Movement.IsConstant = true;
                }

                Vector3 PointA { get; }
                Vector3 PointB { get; }
                State Current { get; set; }
                Coroutine IdleRoutine { get; set; }
                public UiMotion Motion { get; }
                private Animator Animator { get; }
                private SpriteRenderer SpriteRenderer { get; }
                public MonoBehaviour MonoBehaviour => Fsm.Handler.MonoBehaviour;
                private RuntimeEnemy RuntimeEnemy => (RuntimeEnemy) ((UiBipedal) Fsm.Handler.MonoBehaviour).Enemy;

                //------------------------------------------------------------------------------------------------------

                public override void OnEnterState() => Next();

                public override void OnUpdate() => Motion.Update();

                enum State
                {
                    PointA,
                    PointB,
                    WalkA,
                    WalkB
                }

                //------------------------------------------------------------------------------------------------------

                #region Sub State Machine

                /// <summary>
                ///     Patrol point A.
                /// </summary>
                /// <returns></returns>
                IEnumerator StayA()
                {
                    yield return new WaitForSeconds(IdleTime);
                    GoTo(State.WalkB);
                }

                /// <summary>
                ///     Patrol point B.
                /// </summary>
                /// <returns></returns>
                IEnumerator StayB()
                {
                    yield return new WaitForSeconds(IdleTime);
                    GoTo(State.WalkA);
                }

                /// <summary>
                ///     Walk towards point A.
                /// </summary>
                void WalkTowardsA()
                {
                    void MoveA()
                    {
                        if (RuntimeEnemy.IsDead)
                            return;
                        
                        Motion.Movement.OnFinishMotion -= MoveA;
                        GoTo(State.PointA);
                        Animator.Play(_idleAnimHash);
                    }

                    Motion.Movement.OnFinishMotion += MoveA;
                    Motion.MoveTo(PointA, Speed);
                    Animator.Play(_walkAnimHash);
                    SpriteRenderer.flipX = false;
                    ReverseCollisionBounders();
                }

                /// <summary>
                ///     Walk towards point B.
                /// </summary>
                void WalkTowardsB()
                {
                    void MoveB()
                    {
                        if (RuntimeEnemy.IsDead)
                            return;

                        Motion.Movement.OnFinishMotion -= MoveB;
                        GoTo(State.PointB);
                        Animator.Play(_idleAnimHash);
                    }

                    Motion.Movement.OnFinishMotion += MoveB;
                    Motion.MoveTo(PointB, Speed);
                    Animator.Play(_walkAnimHash);
                    SpriteRenderer.flipX = true;
                    ReverseCollisionBounders();
                }

                /// <summary>
                ///     Assigns the next state and dispatches its respective method.
                /// </summary>
                /// <param name="next"></param>
                void GoTo(State next)
                {
                    if (RuntimeEnemy.IsDead)
                        return;

                    Current = next;
                    Next();
                }

                void Next()
                {
                    switch (Current)
                    {
                        case State.PointA:
                            IdleRoutine = MonoBehaviour.StartCoroutine(StayA());
                            break;
                        case State.PointB:
                            IdleRoutine = MonoBehaviour.StartCoroutine(StayB());
                            break;
                        case State.WalkA:
                            WalkTowardsA();
                            break;
                        case State.WalkB:
                            WalkTowardsB();
                            break;
                    }
                }

                void ReverseCollisionBounders()
                {
                    var scale = ((BipedalBehavior) Fsm).CollisionOffset.localScale;
                    scale.x = -scale.x;
                    ((BipedalBehavior) Fsm).CollisionOffset.localScale = scale;
                }

                #endregion

                //------------------------------------------------------------------------------------------------------
            }
        }
    }
}