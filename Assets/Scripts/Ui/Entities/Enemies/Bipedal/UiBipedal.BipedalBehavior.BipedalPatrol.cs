using System.Collections;
using Tools.UI;
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


                public BipedalPatrol(UiEnemyFSM fsm, Vector3 pointA, Vector3 pointB) : base(fsm)
                {
                    PointA = pointA;
                    PointB = pointB;
                    Current = State.PointA;
                    Motion = new UiMotion(this);
                    Motion.Movement.IsConstant = true;
                }

                Vector3 PointA { get; }
                Vector3 PointB { get; }
                State Current { get; set; }
                Coroutine IdleRoutine { get; set; }
                public UiMotion Motion { get; }
                public MonoBehaviour MonoBehaviour => Fsm.Handler.MonoBehaviour;

                //------------------------------------------------------------------------------------------------------

                public override void OnEnterState()
                {
                    Next();
                }

                public override void OnUpdate()
                {
                    Motion.Update();
                }

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
                        Motion.Movement.OnFinishMotion -= MoveA;
                        GoTo(State.PointA);
                    }

                    Motion.Movement.OnFinishMotion += MoveA;
                    Motion.MoveTo(PointA, Speed);
                }

                /// <summary>
                ///     Walk towards point B.
                /// </summary>
                void WalkTowardsB()
                {
                    void MoveB()
                    {
                        Motion.Movement.OnFinishMotion -= MoveB;
                        GoTo(State.PointB);
                    }

                    Motion.Movement.OnFinishMotion += MoveB;
                    Motion.MoveTo(PointB, Speed);
                }

                /// <summary>
                ///     Assigns the next state and dispatches its respective method.
                /// </summary>
                /// <param name="next"></param>
                void GoTo(State next)
                {
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

                #endregion

                //------------------------------------------------------------------------------------------------------
            }
        }
    }
}