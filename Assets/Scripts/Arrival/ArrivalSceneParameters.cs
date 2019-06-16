using Dialog;
using UnityEngine;


namespace SpaceMarine.Arrival
{
    [CreateAssetMenu(menuName = "Parameters/ArrivalSceneParameters")]
    public class ArrivalSceneParameters : ScriptableObject
    {
        [Header("Fades")]
        [Range(0, 5)] public float FadeSpeedOpening = 0.5f;
        [Range(0, 5)] public float FadeSpeedEnding = 2.5f;
        [Range(0, 5)] public float FadeStart = 1f;
        [Range(0, 5)] public float FadeStartDelay = 1f;

        [Header("Space Craft")]
        [Range(0, 5)] public float DelayMoveRight = 2;
        [Range(0, 5)] public float DelayMoveToArrivalPoint = 2;
        
        [Range(0, 10)] public float SpaceCraftSpeedArrival = 1.5f;
        [Range(0, 10)] public float SpaceCraftSpeedLeft = 5.5f;
        [Range(0, 10)] public float SpaceCraftSpeedRight = 6.5f;

        public Vector3 StartCraftScale = new Vector3(18, 12f, 1);
        public Vector3 ReverCraftScale = new Vector3(-6, 4f, 1);

        public Vector3 StartCraftPosition = new Vector3(-38f, 2.89f, -2);
        public Vector3 ArrivalPoint = new Vector3(-57f, 2.89f, -2);
        public Vector3 RightScreenSpaceCraftPosition = new Vector3(50f, 2.89f, -2);

        [Header("Dialogs")]
        public TextSequence TextSequence;
    }
}
