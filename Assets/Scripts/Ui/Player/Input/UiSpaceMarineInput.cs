using UnityEngine;

namespace SpaceMarine.Input
{
    public interface ISpaceMarineInput
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool IsShootPressed { get; }
        bool IsJumpPressed { get; }
        void StartTracking();
        void StopTracking();
    }

    public class UiSpaceMarineInput : MonoBehaviour, ISpaceMarineInput
    {
        const KeyCode ShootKey = KeyCode.Space;
        const KeyCode JumpKey = KeyCode.W;

        const string HorizontalAx = "Horizontal";
        const string VerticalAx = "Vertical";
        public bool IsTracking { get; private set; }

        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        public bool IsJumpPressed { get; private set; }

        public bool IsShootPressed { get; private set; }

        public void StartTracking()
        {
            IsTracking = true;
        }

        public void StopTracking()
        {
            IsTracking = false;
        }

        void Update()
        {
            if (!IsTracking)
                return;

            //axis
            Horizontal = UnityEngine.Input.GetAxis(HorizontalAx);
            Vertical = UnityEngine.Input.GetAxis(VerticalAx);

            //jump
            IsJumpPressed = UnityEngine.Input.GetKey(JumpKey);

            //shoot
            IsShootPressed = UnityEngine.Input.GetKey(ShootKey);
        }
    }
}