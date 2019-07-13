using System;
using Tools;
using UnityEngine;

namespace SpaceMarine
{
    public class PressButtonNotification : StateEntity
    {        
        private Window Window;
        private IKeyboardInput Input;

        protected override void Awake()
        {
            base.Awake();
            Input = GetComponent<IKeyboardInput>();
            Window = GetComponent<Window>();
        }

        public void AddListener(Action action)
        {
            if(action != null)
                Input.OnKeyDown += action;
        }
        
        protected override void OnStartProcessing()
        {
            Window.Show();
            Input.StartTracking();
        }

        protected override void OnStopProcessing()
        {
            Window.Hide();
            Input.StopTracking();
        }      
    }
}