using System;
using SpaceMarine.Model;
using Tools;
using UnityEngine;

namespace SpaceMarine
{
    public class UiElevatorStops : EditorComponent
    {
        public Transform Elevator;

        void Update()
        {
            var current = transform.position;
            current.x = Elevator.position.x;
            transform.position = current;
        }
    }
}
