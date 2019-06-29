using System.Collections;
using Tools;
using Tools.UI.Fade;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceMarine.Opening
{
    public class OpeningSceneSequence : MonoBehaviour
    {
        [SerializeField] private DialogSystem dialog;
        [SerializeField] private OpeningSceneParameters parameters;

        [Button]
        private void Start()
        {
            Restart();
            Fade.Instance.SetAlphaImmediatly(parameters.FadeStart);
            StartCoroutine(FadeOut());
        }

        [Button]
        private void Restart()
        {
            SpaceCraft.Instance.transform.localScale = parameters.StartCraftScale;
            SpaceCraft.Instance.Motion.Movement.StopMotion();
            SpaceCraft.Instance.Motion.Movement.OnFinishMotion = () => { };
            SpaceCraft.Instance.transform.position = parameters.StartCraftPosition;
            SpaceCraft.Instance.Motion.Movement.IsConstant = false;
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
            SpaceCraft.Instance.Motion.Movement.Execute(cameraPos, parameters.SpaceCraftSpeedCenter, 0);

            void MoveLeftRoutine()
            {
                SpaceCraft.Instance.Motion.Movement.OnFinishMotion -= MoveLeftRoutine;
                MoveSpaceCraftLeftScreenSide();
            }

            SpaceCraft.Instance.Motion.Movement.OnFinishMotion += MoveLeftRoutine;
        }

        private void MoveSpaceCraftLeftScreenSide()
        {
            SpaceCraft.Instance.Motion.Movement
                .Execute(parameters.LeftScreenSpaceCraftPosition, parameters.SpaceCraftSpeedLeft, 0);
            SpaceCraft.Instance.Motion.Movement.IsConstant = true;

            void ShowDialog()
            {
                SpaceCraft.Instance.Motion.Movement.OnFinishMotion -= ShowDialog;
                dialog.Write(parameters.TextSequence);
                dialog.OnHide += MoveSpaceCraftRightScreenSide;
            }

            SpaceCraft.Instance.Motion.Movement.OnFinishMotion += ShowDialog;
        }

        private void MoveSpaceCraftRightScreenSide()
        {
            dialog.OnHide -= MoveSpaceCraftRightScreenSide;
            SpaceCraft.Instance.Motion.Movement
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