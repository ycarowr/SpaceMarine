using System.Collections;
using System.Collections.Generic;
using Tools.UI.Fade;
using UnityEngine;


namespace SpaceMarine.Arrival
{
    public class CameraSequence : MonoBehaviour
    {
        // fade
        private const float fadeSpeed = 0.5f;
        private const float fadeStart = 1f;
        private const float fadeTimeOutStart = 1f;

        //spacecraft
        private readonly Vector3 leftScreenSpaceCraftPosition = new Vector3(-57f, 2.89f, -2);
        private readonly float spaceCraftSpeed = 7f;

        [Button]
        private void Start()
        {
            Fade.Instance.SetAlphaImmediatly(fadeStart);
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut()
        {
            yield return new WaitForSeconds(fadeTimeOutStart);
            Fade.Instance.SetAlpha(0, fadeSpeed);
            StartCoroutine(MoveSpaceCraftScreenCenter());
        }

        private IEnumerator MoveSpaceCraftScreenCenter()
        {
            yield return new WaitForSeconds(3);
            var cameraPos = transform.position;
            SpaceCraft.Instance.Motion.Execute(cameraPos, spaceCraftSpeed, 0, false);

            void MoveLeftRoutine()
            {
                SpaceCraft.Instance.Motion.OnFinishMotion -= MoveLeftRoutine;
                StartCoroutine(MoveSpaceCraftLeftScreenSide());
            }

            SpaceCraft.Instance.Motion.OnFinishMotion += MoveLeftRoutine;
        }

        private IEnumerator MoveSpaceCraftLeftScreenSide()
        {
            yield return new WaitForSeconds(0.5f);
            SpaceCraft.Instance.Motion.Execute(leftScreenSpaceCraftPosition, spaceCraftSpeed, 0, false);
        }

    }
}
