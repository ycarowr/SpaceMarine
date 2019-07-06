using System;
using System.Diagnostics;
using Tools;
using Tools.UI.Fade;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace SpaceMarine
{
    public class LightsElevatorControl : BaseEntity
    {
        private const float LightsOn = 0;
        private const float LightsOff = 0.7f;
        
        private FadeComponent Lights { get; set; }

        protected override void Awake()
        {
            base.Awake();
            Lights = transform.parent.GetComponentInChildren<FadeComponent>();
        }
        
        protected override void OnTriggerEnterPlayer()
        {
            Lights.SetAlpha(LightsOn);
        }

        protected override void OnTriggerExitPlayer()
        {
            Lights.SetAlpha(LightsOff);
        }
    }
}