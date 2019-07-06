using Tools;
using Tools.Dialog;
using UnityEngine;

namespace SpaceMarine.Opening
{
    [CreateAssetMenu(menuName = "Parameters/OpeningSceneParameters")]
    public class OpeningSceneParameters : ScriptableObject
    {
        [Range(0, 5)] public float DelayMoveCraftCenter = 3;
        [Range(0, 5)] public float FadeSpeedEnding = 2.5f;

        [Header("Fades")] [Range(0, 5)] public float FadeSpeedOpening = 0.5f;

        [Range(0, 5)] public float FadeStart = 1f;
        [Range(0, 5)] public float FadeStartDelay = 1f;
        public Vector3 LeftScreenSpaceCraftPosition = new Vector3(-57f, 2.89f, -2);
        public Object NextLevel;
        public Vector3 RightScreenSpaceCraftPosition = new Vector3(50f, 2.89f, -2);
        [Range(0, 10)] public float SpaceCraftSpeedCenter = 1.5f;
        [Range(0, 10)] public float SpaceCraftSpeedLeft = 5.5f;
        [Range(0, 10)] public float SpaceCraftSpeedRight = 6.5f;

        public Vector3 StartCraftPosition = new Vector3(-65.5f, 2.89f, -2);

        [Header("Space Craft")] public Vector3 StartCraftScale = Vector3.one;

        [Header("Dialogs")] public TextSequence TextSequence;
    }
}