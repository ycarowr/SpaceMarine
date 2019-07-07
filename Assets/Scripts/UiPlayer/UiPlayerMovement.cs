using SpaceMarine.Input;
using Tools.UI;
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

        public UiMotion Motion { get; }
        public MonoBehaviour MonoBehaviour => UiPlayer.MonoBehavior;
        public IUiPlayer UiPlayer { get; }
        public  UiPlayerParameters Parameters { get; }
        public  ISpaceMarineInput Input { get; }
        private Rigidbody2D Rigidbody2D { get; }
        private float JumpTime { get; set; }
        private float vSpeed { get; set; }
        private float hSpeed { get; set; }

        public void Update()
        {
            Motion.Update();
            Move();
        }

        private void Move()
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

        private float GetVerticalSpeed(Vector3 position)
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