using System.Collections;
using System.Collections.Generic;
using Tools.Input;
using UnityEngine;


namespace SpaceMarine
{
    public class PlayerMovement
    {
        private IPlayer Player { get; }
        private PlayerParameters Parameters { get; }
        private IInputProvider Input { get; }
        private Rigidbody2D Rigidbody2D { get; }
        private float JumpTime { get; set; }
        private float vSpeed { get; set; }
        private float hSpeed { get; set; }

        public PlayerMovement(IPlayer player)
        {
            Player = player;
            Parameters = player.Parameters;
            Input = player.Input;
            Rigidbody2D = player.Rigidbody2D;
        }

        public void Update()
        {
            Move();
        }

        private void Move()
        {
            if (Player.Attributes.IsShotting && Player.Attributes.IsGrounded)
                return;

            var position = (Vector2)Player.MonoBehavior.transform.position;
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