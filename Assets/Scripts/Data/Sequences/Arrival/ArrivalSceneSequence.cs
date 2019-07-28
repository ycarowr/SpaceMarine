using System.Collections;
using Extensions;
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
        [SerializeField] private ArrivalSceneParameters param;
        
        private UiSpaceCraft UiSpaceCraft => UiSpaceCraft.Instance;
        
        
        public void OnStartGame(IGame runtimeGame)
        {
            if(!param.SkipIntro)
                StartProcessing(); 
        }
        
        [Button]
        private void StartProcessing()
        {
            Restart();
            Fade.Instance.SetAlphaImmediatly(param.FadeStart);
            UiPlayer.Instance.Deactivate();
            UiPlayer.Instance.Movement.Motion.Teleport(param.PlayerPosition);
            StartCoroutine(FadeOut());
        }

        [Button]
        private void Restart()
        {
            UiSpaceCraft.Motion.Movement.StopMotion();
            UiSpaceCraft.Motion.Movement.OnFinishMotion = () => { };
            UiSpaceCraft.transform.position = param.StartCraftPosition;
            UiSpaceCraft.transform.localScale = param.StartCraftScale;
            UiSpaceCraft.Motion.Movement.IsConstant = false;
            Fade.Instance.SetAlphaImmediatly(1);
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

            UiSpaceCraft.Motion.Movement.Execute(param.RightScreenSpaceCraftPosition, param.SpaceCraftSpeedRight, 0);
            UiSpaceCraft.Motion.Movement.OnFinishMotion += MoveSpaceCraftArrivalPoint;
        }

        private void MoveSpaceCraftArrivalPoint()
        {
            StartCoroutine(MoveToArrival());
        }

        private IEnumerator MoveToArrival()
        {
            UiSpaceCraft.Instance.transform.localScale = param.ReverCraftScale;
            UiSpaceCraft.Instance.DisableNumber();
            yield return new WaitForSeconds(param.DelayMoveToArrivalPoint);
            UiSpaceCraft.Motion.Movement
                .Execute(param.ArrivalPoint, param.SpaceCraftSpeedArrival, 0);

            UiSpaceCraft.Motion.Movement.OnFinishMotion += EnablePlayer;
        }

        private void EnablePlayer()
        {
            UiSpaceCraft.Motion.Movement.OnFinishMotion -= EnablePlayer;
            UiPlayer.Instance.Active();
        }
    }
}