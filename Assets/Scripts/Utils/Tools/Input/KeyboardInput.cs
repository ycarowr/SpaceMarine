using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tools.Input
{
    public interface IInputProvider
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool IsShootPressed { get; }
        bool IsJumpPressed { get; }
    }

    public class KeyboardInput : MonoBehaviour, IInputProvider
    {
        private const KeyCode ShootKey = KeyCode.Space;
        private const KeyCode JumpKey = KeyCode.W;

        private const string HorizontalAx = "Horizontal";
        private const string VerticalAx = "Vertical";

        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        public bool IsJumpPressed { get; private set; }

        public bool IsShootPressed { get; private set; }

        private void Update()
        {
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