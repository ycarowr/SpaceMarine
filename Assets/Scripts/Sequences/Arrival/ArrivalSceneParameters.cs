using Tools;
using UnityEngine;

namespace SpaceMarine.Arrival
{
    [CreateAssetMenu(menuName = "Parameters/ArrivalSceneParameters")]
    public class ArrivalSceneParameters : ScriptableObject
    {
        public Vector3 ArrivalPoint;

        [Header("Space Craft")] [Range(0, 5)] public float DelayMoveRight;

        [Range(0, 5)] public float DelayMoveToArrivalPoint;
        [Range(0, 5)] public float FadeSpeedEnding;

        [Header("Fades")] [Range(0, 5)] public float FadeSpeedOpening;

        [Range(0, 5)] public float FadeStart;
        [Range(0, 5)] public float FadeStartDelay;

        [Header("Space Craft Movement")] 
        public Vector3 ReverCraftScale;
        public Vector3 RightScreenSpaceCraftPosition;

        [Range(0, 10)] public float SpaceCraftSpeedArrival;
        [Range(0, 10)] public float SpaceCraftSpeedLeft;
        [Range(0, 10)] public float SpaceCraftSpeedRight;

        public Vector3 StartCraftPosition;

        public Vector3 StartCraftScale;

        [Header("Dialogs")] public TextSequence TextSequence;
    }
}