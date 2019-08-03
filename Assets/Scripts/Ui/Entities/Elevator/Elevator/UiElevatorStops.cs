using System;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine
{
    [Serializable][ExecuteInEditMode]
    public class UiElevatorStops : MonoBehaviour
    {
        public Transform Elevator;

        void OnEnable()
        {
            if(!Application.isEditor)
                Destroy(gameObject);
        }
        
        private void Update()
        {
            var current = transform.position;
            current.x = Elevator.position.x;
            transform.position = current;
        }
    }
}
