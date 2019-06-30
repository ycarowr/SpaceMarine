using System;
using Tools;
using UnityEngine;

namespace SpaceMarine
{
    public class PressButtonNotification : StateEntity
    {
        public Action OnPressButton { get; set; } = () => { };
        
        private Window Window;
        private KeyboardInput Input;

        protected override void Awake()
        {
            base.Awake();
            Input = GetComponent<KeyboardInput>();
            Window = GetComponent<Window>();
            Input.OnKeyDown += OnPressButton.Invoke;
        }

        protected override void OnStartProcessing()
        {
            Window.Show();
            Input.IsTracking = true;
        }

        protected override void OnStopProcessing()
        {
            Window.Hide();
            Input.IsTracking = false;
        }      
    }
}