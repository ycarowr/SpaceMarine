using System.Collections;
using System.Collections.Generic;
using Tools.UI.Fade;
using UnityEngine;
using Dialog;
using System;

namespace SpaceMarine.Arrival
{
    public partial class OpeningSequence : MonoBehaviour
    {
        [SerializeField] OpeningSceneParameters parameters;

        [Button]
        void Start()
        {
            Restart();
            Fade.Instance.SetAlphaImmediatly(parameters.FadeStart);
            StartCoroutine(FadeOut());
        }

        [Button]
        void Restart()
        {
            SpaceCraft.Instance.Motion.StopMotion();
            SpaceCraft.Instance.Motion.OnFinishMotion = () => { };
            SpaceCraft.Instance.transform.position = parameters.StartCraftPosition;
            SpaceCraft.Instance.Motion.IsConstant = false;
            Fade.Instance.SetAlphaImmediatly(1);
            DialogSystem.Instance.Hide();
        }

        IEnumerator FadeOut()
        {
            yield return new WaitForSeconds(parameters.FadeStartDelay);
            Fade.Instance.SetAlpha(0, parameters.FadeSpeedOpening);
            StartCoroutine(MoveSpaceCraftScreenCenter());
        }

        IEnumerator MoveSpaceCraftScreenCenter()
        {
            yield return new WaitForSeconds(parameters.DelayMoveCraftCenter);
            var cameraPos = Camera.main.transform.position;
            SpaceCraft.Instance.Motion.Execute(cameraPos, parameters.SpaceCraftSpeedCenter, 0);

            void MoveLeftRoutine()
            {
                SpaceCraft.Instance.Motion.OnFinishMotion -= MoveLeftRoutine;
                MoveSpaceCraftLeftScreenSide();
            }

            SpaceCraft.Instance.Motion.OnFinishMotion += MoveLeftRoutine;
        }

        void MoveSpaceCraftLeftScreenSide()
        {
            SpaceCraft.Instance.Motion
                .Execute(parameters.LeftScreenSpaceCraftPosition, parameters.SpaceCraftSpeedLeft, 0);
            SpaceCraft.Instance.Motion.IsConstant = true;

            void ShowDialog()
            {
                SpaceCraft.Instance.Motion.OnFinishMotion -= ShowDialog;
                DialogSystem.Instance.Write(parameters.TextSequence);
                DialogSystem.Instance.OnHide += MoveSpaceCraftRightScreenSide;
            }

            SpaceCraft.Instance.Motion.OnFinishMotion += ShowDialog;
        }

        void MoveSpaceCraftRightScreenSide()
        {
            DialogSystem.Instance.OnHide -= MoveSpaceCraftRightScreenSide;
            SpaceCraft.Instance.Motion
                .Execute(parameters.RightScreenSpaceCraftPosition, parameters.SpaceCraftSpeedRight, 0);

            Fade.Instance.SetAlpha(1, parameters.FadeSpeedEnding);
        }
    }
}
