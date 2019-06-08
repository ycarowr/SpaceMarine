using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceMarine
{
    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField] PlayerParameters parameters;
        public PlayerParameters Parameters => parameters;
        public MonoBehaviour MonoBehavior => this;
        public PlayerMovement Movement { get; private set; }

        private void Awake()
        {
            Movement = new PlayerMovement(this);
        }

        private void Update()
        {
            Movement?.Update();
        }
    }
}