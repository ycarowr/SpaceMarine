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
        private KeyboardInput Input { get; }
        private Rigidbody2D Rigidbody2D { get; }

        public PlayerMovement(IPlayer player)
        {
            Player = player;
            Parameters = player.Parameters;
            Input = player.MonoBehavior.GetComponentInChildren<KeyboardInput>();
            Rigidbody2D = player.MonoBehavior.GetComponentInChildren<Rigidbody2D>();
        }

        public void Update()
        {
            var delta = Time.deltaTime;
            var hSpeed = delta * Input.Horizontal * Parameters.Speed;
            var vSpeed = delta * Input.Vertical * Parameters.Jump;
            var speed = new Vector2(hSpeed, vSpeed);
            var position = (Vector2)Player.MonoBehavior.transform.position;
            Rigidbody2D.MovePosition(position + speed);
        }
    }
}