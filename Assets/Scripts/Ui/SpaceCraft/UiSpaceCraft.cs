using Patterns;
using Tools.UI;
using UnityEngine;

namespace SpaceMarine
{
    public class UiSpaceCraft : SingletonMB<UiSpaceCraft>, IUiMotionHandler
    {
        public GameObject Number;
        public UiMotion Motion { get; private set; }
        public MonoBehaviour MonoBehaviour => this;

        protected override void OnAwake()
        {
            Motion = new UiMotion(this);
            Motion.Movement.IsConstant = false;
        }

        void Update()
        {
            Motion?.Update();
        }

        public void DisableNumber()
        {
            Number.SetActive(false);
        }
    }
}