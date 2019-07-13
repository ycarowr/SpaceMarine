using System.Collections;
using Patterns.GameEvents;
using SpaceMarine.Model;
using Tools;
using Tools.Dialog;
using Tools.UI.Fade;
using UnityEngine;

namespace SpaceMarine.Arrival
{
    public class ArrivalSceneSequence : UiGameEventListener, Events.IStartGame
    {
        [SerializeField] private DialogSystem dialog;
        [SerializeField] private ArrivalSceneParameters param;
        
        private SpaceCraft SpaceCraft => SpaceCraft.Instance;
        
        
        public void OnStartGame(IGame runtimeGame)
        {
            StartProcessing();
        }
        
        [Button]
        private void StartProcessing()
        {
            Restart();
            Fade.Instance.SetAlphaImmediatly(param.FadeStart);
            UiPlayer.Instance.Deactivate();
            StartCoroutine(FadeOut());
        }

        [Button]
        private void Restart()
        {
            SpaceCraft.Motion.Movement.StopMotion();
            SpaceCraft.Motion.Movement.OnFinishMotion = () => { };
            SpaceCraft.transform.position = param.StartCraftPosition;
            SpaceCraft.transform.localScale = param.StartCraftScale;
            SpaceCraft.Motion.Movement.IsConstant = false;
            Fade.Instance.SetAlphaImmediatly(1);
            dialog.Hide();
        }

        private IEnumerator FadeOut()
        {
            yield return new WaitForSeconds(param.FadeStartDelay);
            Fade.Instance.SetAlpha(0, param.FadeSpeedOpening);
            StartCoroutine(MoveSpaceCraftScreenRight());
        }

        private IEnumerator MoveSpaceCraftScreenRight()
        {
            yield return new WaitForSeconds(param.DelayMoveRight);

            SpaceCraft.Motion.Movement.Execute(param.RightScreenSpaceCraftPosition, param.SpaceCraftSpeedRight, 0);
            SpaceCraft.Motion.Movement.OnFinishMotion += MoveSpaceCraftArrivalPoint;
        }

        private void MoveSpaceCraftArrivalPoint()
        {
            dialog.OnHide -= MoveSpaceCraftArrivalPoint;
            StartCoroutine(MoveToArrival());
        }

        private IEnumerator MoveToArrival()
        {
            SpaceCraft.Instance.transform.localScale = param.ReverCraftScale;
            SpaceCraft.Instance.DisableNumber();
            yield return new WaitForSeconds(param.DelayMoveToArrivalPoint);
            SpaceCraft.Motion.Movement
                .Execute(param.ArrivalPoint, param.SpaceCraftSpeedArrival, 0);

            SpaceCraft.Motion.Movement.OnFinishMotion += EnablePlayer;
        }

        private void EnablePlayer()
        {
            SpaceCraft.Motion.Movement.OnFinishMotion -= EnablePlayer;
            UiPlayer.Instance.Active();
        }
    }
}