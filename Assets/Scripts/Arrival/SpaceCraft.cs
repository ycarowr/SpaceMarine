using Patterns;
using System.Collections;
using System.Collections.Generic;
using Tools.UI;
using UnityEngine;


namespace SpaceMarine
{
    public class SpaceCraft : SingletonMB<SpaceCraft>
    {
        public UiMotionMovement Motion { get; private set; }

        protected override void OnAwake()
        {
            Motion = new UiMotionMovement(this);
            Motion.IsConstant = false;
        }

        private void Update()
        {
            Motion.Update();
        }

        [Button]
        public void MoveToZero()
        {
            Motion.Execute(Vector3.zero, 100, 0);
        }
    }
}
