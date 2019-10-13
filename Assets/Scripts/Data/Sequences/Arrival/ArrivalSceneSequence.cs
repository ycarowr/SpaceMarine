using System.Collections;
using SpaceMarine.Model;
using Tools.Fade;
using Tools.Patterns.GameEvents;
using UnityEngine;

namespace SpaceMarine.Arrival
{
    public class ArrivalSceneSequence : UiGameEventListener, GameEvent.IStartGame
    {
        [SerializeField] ArrivalSceneParameters param;

        UiSpaceCraft UiSpaceCraft => UiSpaceCraft.Instance;


        public void OnStartGame(IGame runtimeGame)
        {
            if (!param.SkipIntro)
                StartProcessing();
        }

        [Button]
        void StartProcessing()
        {
            Restart();
            Fade.Instance.SetAlphaImmediatly(param.FadeStart);
            UiPlayer.Instance.Deactivate();
            UiPlayer.Instance.Movement.Motion.Teleport(param.PlayerPosition);
            StartCoroutine(FadeOut());
        }

        [Button]
        void Restart()
        {
            UiSpaceCraft.Motion.Movement.StopMotion();
            UiSpaceCraft.Motion.Movement.OnFinishMotion = () => { };
            UiSpaceCraft.transform.position = param.StartCraftPosition;
            UiSpaceCraft.transform.localScale = param.StartCraftScale;
            UiSpaceCraft.Motion.Movement.IsConstant = false;
            Fade.Instance.SetAlphaImmediatly(1);
        }

        IEnumerator FadeOut()
        {
            yield return new WaitForSeconds(param.FadeStartDelay);
            Fade.Instance.SetAlpha(0, param.FadeSpeedOpening);
            StartCoroutine(MoveSpaceCraftScreenRight());
        }

        IEnumerator MoveSpaceCraftScreenRight()
        {
            yield return new WaitForSeconds(param.DelayMoveRight);

            UiSpaceCraft.Motion.Movement.Execute(param.RightScreenSpaceCraftPosition, param.SpaceCraftSpeedRight);
            UiSpaceCraft.Motion.Movement.OnFinishMotion += MoveSpaceCraftArrivalPoint;
        }

        void MoveSpaceCraftArrivalPoint()
        {
            UiSpaceCraft.Motion.Movement.OnFinishMotion -= MoveSpaceCraftArrivalPoint;
            StartCoroutine(MoveToArrival());
        }

        IEnumerator MoveToArrival()
        {
            UiSpaceCraft.Instance.transform.localScale = param.ReverCraftScale;
            UiSpaceCraft.Instance.DisableNumber();
            yield return new WaitForSeconds(param.DelayMoveToArrivalPoint);
            UiSpaceCraft.Motion.Movement
                .Execute(param.ArrivalPoint, param.SpaceCraftSpeedArrival);
            UiSpaceCraft.Motion.Movement.OnFinishMotion += MovePlayerToArrival;
        }

        void MovePlayerToArrival()
        {
            UiSpaceCraft.Motion.Movement.OnFinishMotion -= MovePlayerToArrival;
            UiPlayer.Instance.Active();
            UiPlayer.Instance.Lock();
            UiPlayer.Instance.Animation.ForceWalk();
            UiPlayer.Instance.Movement.Motion.Movement.IsConstant = true;
            UiPlayer.Instance.Movement.Motion.Movement.Execute(param.PlayerFinalPosition, param.PlayerWalkSpeed);
            UiPlayer.Instance.Movement.Motion.Movement.OnFinishMotion += EnablePlayer;
        }

        void EnablePlayer()
        {
            UiPlayer.Instance.Movement.Motion.Movement.OnFinishMotion -= EnablePlayer;
            UiPlayer.Instance.Movement.Motion.Movement.StopMotion();
            UiPlayer.Instance.UnLock();
            UiPlayer.Instance.Animation.ForceIdle();
        }
    }
}