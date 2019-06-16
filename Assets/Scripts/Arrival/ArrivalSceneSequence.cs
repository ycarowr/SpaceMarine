using System.Collections;
using System.Collections.Generic;
using Tools.UI.Fade;
using UnityEngine;
using Dialog;
using System;
using UnityEngine.SceneManagement;

namespace SpaceMarine.Arrival
{
    public class ArrivalSceneSequence : MonoBehaviour
    {
        [SerializeField] ArrivalSceneParameters param;

        [Button]
        void Start()
        {
            Restart();
            Fade.Instance.SetAlphaImmediatly(param.FadeStart);
            StartCoroutine(FadeOut());
        }

        [Button]
        void Restart()
        {
            SpaceCraft.Instance.Motion.StopMotion();
            SpaceCraft.Instance.Motion.OnFinishMotion = () => { };
            SpaceCraft.Instance.transform.position = param.StartCraftPosition;
            SpaceCraft.Instance.transform.localScale = param.StartCraftScale;
            SpaceCraft.Instance.Motion.IsConstant = false;
            Fade.Instance.SetAlphaImmediatly(1);
            DialogSystem.Instance.Hide();
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

            SpaceCraft.Instance.Motion
                .Execute(param.RightScreenSpaceCraftPosition, param.SpaceCraftSpeedRight, 0);
            
            SpaceCraft.Instance.Motion.OnFinishMotion += MoveSpaceCraftArrivalPoint;
        }

        void MoveSpaceCraftArrivalPoint()
        {
            DialogSystem.Instance.OnHide -= MoveSpaceCraftArrivalPoint;
            StartCoroutine(MoveToArrival());
        }

        IEnumerator MoveToArrival()
        {
            SpaceCraft.Instance.transform.localScale = param.ReverCraftScale;
            SpaceCraft.Instance.DisableNumber();
            yield return new WaitForSeconds(param.DelayMoveToArrivalPoint);
            SpaceCraft.Instance.Motion
                .Execute(param.ArrivalPoint, param.SpaceCraftSpeedArrival, 0);

            SpaceCraft.Instance.Motion.OnFinishMotion += EnablePlayer;
        }

        private void EnablePlayer()
        {
            SpaceCraft.Instance.Motion.OnFinishMotion -= EnablePlayer;
            Player.Instance.Active();
        }
    }
}
