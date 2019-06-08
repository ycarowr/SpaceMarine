using System;
using System.Collections;
using UnityEngine;

namespace Tools.UI
{
    public class UiMotion
    {
        public UiMotionBase Movement { get; private set; }
        public UiMotionBase Rotation { get; private set; }
        public UiMotionBase Scale { get; private set; }

        public UiMotion(MonoBehaviour handler)
        {
            Scale = new UiMotionScale(handler);
            Movement = new UiMotionMovement(handler);
            Rotation = new UiMotionRotation(handler);
        }

        public void Update()
        {
            Movement?.Update();
            Rotation?.Update();
            Scale?.Update();
        }

        #region Transform Operations

        public void RotateTo(Vector3 rotation, float speed)
        {
            Rotation?.Execute(rotation, speed);
        }

        public void MoveTo(Vector3 position, float speed, float delay = 0)
        {
            Movement?.Execute(position, speed, delay, withZ: false);
        }

        public void MoveToWithZ(Vector3 position, float speed, float delay = 0)
        {
            Movement?.Execute(position, speed, delay, withZ: true);
        }

        public void ScaleTo(Vector3 scale, float speed, float delay = 0)
        {
            Scale?.Execute(scale, speed, delay);
        }

        #endregion
    }
}