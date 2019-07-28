using System.Collections;
using Tools;
using Tools.Dialog;
using Tools.UI.Fade;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceMarine.Opening
{
    public class OpeningSceneSequence : MonoBehaviour
    {
        [SerializeField] private DialogSystem dialog;
        [SerializeField] private OpeningSceneParameters parameters;
        [SerializeField] private TextButton NextButton;
        

        [Button]
        private void Start()
        {
            Restart();
            NextButton.OnClick.Add(dialog, dialog.Next);
            Fade.Instance.SetAlphaImmediatly(parameters.FadeStart);
            StartCoroutine(FadeOut());
        }

        [Button]
        private void Restart()
        {
            UiSpaceCraft.Instance.transform.localScale = parameters.StartCraftScale;
            UiSpaceCraft.Instance.Motion.Movement.StopMotion();
            UiSpaceCraft.Instance.Motion.Movement.OnFinishMotion = () => { };
            UiSpaceCraft.Instance.transform.position = parameters.StartCraftPosition;
            UiSpaceCraft.Instance.Motion.Movement.IsConstant = false;
            Fade.Instance.SetAlphaImmediatly(1);
            dialog.Hide();
        }

        private IEnumerator FadeOut()
        {
            yield return new WaitForSeconds(parameters.FadeStartDelay);
            Fade.Instance.SetAlpha(0, parameters.FadeSpeedOpening);
            StartCoroutine(MoveSpaceCraftScreenCenter());
        }

        private IEnumerator MoveSpaceCraftScreenCenter()
        {
            yield return new WaitForSeconds(parameters.DelayMoveCraftCenter);
            var cameraPos = Camera.main.transform.position;
            UiSpaceCraft.Instance.Motion.Movement.Execute(cameraPos, parameters.SpaceCraftSpeedCenter, 0);

            void MoveLeftRoutine()
            {
                UiSpaceCraft.Instance.Motion.Movement.OnFinishMotion -= MoveLeftRoutine;
                MoveSpaceCraftLeftScreenSide();
            }

            UiSpaceCraft.Instance.Motion.Movement.OnFinishMotion += MoveLeftRoutine;
        }

        private void MoveSpaceCraftLeftScreenSide()
        {
            UiSpaceCraft.Instance.Motion.Movement
                .Execute(parameters.LeftScreenSpaceCraftPosition, parameters.SpaceCraftSpeedLeft, 0);
            UiSpaceCraft.Instance.Motion.Movement.IsConstant = true;

            void ShowDialog()
            {
                UiSpaceCraft.Instance.Motion.Movement.OnFinishMotion -= ShowDialog;
                dialog.Write(parameters.TextSequence);
                dialog.OnHide += MoveSpaceCraftRightScreenSide;
            }

            UiSpaceCraft.Instance.Motion.Movement.OnFinishMotion += ShowDialog;
        }

        private void MoveSpaceCraftRightScreenSide()
        {
            dialog.OnHide -= MoveSpaceCraftRightScreenSide;
            UiSpaceCraft.Instance.Motion.Movement
                .Execute(parameters.RightScreenSpaceCraftPosition, parameters.SpaceCraftSpeedRight, 0);

            Fade.Instance.SetAlpha(1, parameters.FadeSpeedEnding);
            Fade.Instance.OnFinishFade += LoadLevel;
        }

        private void LoadLevel()
        {
            SceneManager.LoadScene(parameters.NextLevel.name);
        }
    }
}