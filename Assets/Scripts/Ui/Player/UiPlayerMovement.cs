using SpaceMarine.Input;
using Tools.UiTransform;
using UnityEngine;

namespace SpaceMarine
{
    public interface IPlayerMovement : IUiMotionHandler
    {
        IUiPlayer UiPlayer { get; }
        UiPlayerParameters Parameters { get; }
        ISpaceMarineInput Input { get; }
    }

    public class UiPlayerMovement : IPlayerMovement
    {
        public UiPlayerMovement(IUiPlayer uiPlayer)
        {
            UiPlayer = uiPlayer;
            Parameters = uiPlayer.Parameters;
            Input = uiPlayer.Input;
            Rigidbody2D = uiPlayer.Rigidbody2D;
            Motion = new UiMotion(this);
        }

        Rigidbody2D Rigidbody2D { get; }
        float JumpTime { get; set; }
        float vSpeed { get; set; }
        float hSpeed { get; set; }

        public UiMotion Motion { get; }
        public MonoBehaviour MonoBehaviour => UiPlayer.MonoBehavior;
        public IUiPlayer UiPlayer { get; }
        public UiPlayerParameters Parameters { get; }
        public ISpaceMarineInput Input { get; }

        public void Update()
        {
            Motion.Update();
            Move();
        }

        void Move()
        {
            if (UiPlayer.IsLocked)
                return;

            if (UiPlayer.Attributes.IsShotting && UiPlayer.Attributes.IsGrounded)
                return;

            var position = (Vector2) UiPlayer.MonoBehavior.transform.position;
            var deltaTime = Time.deltaTime;
            hSpeed = Input.Horizontal * Parameters.Speed;
            vSpeed = GetVerticalSpeed(position);
            var speed = new Vector2(hSpeed, vSpeed) * deltaTime;
            Rigidbody2D.MovePosition(position + speed);
        }

        float GetVerticalSpeed(Vector3 position)
        {
            if (!Input.IsJumpPressed)
            {
                JumpTime = 0;
                return Parameters.FallSpeed;
            }

            JumpTime += Time.deltaTime;
            return JumpTime < Parameters.JumpTime ? Input.Vertical * Parameters.JumpSpeed : Parameters.FallSpeed;
        }
    }
}