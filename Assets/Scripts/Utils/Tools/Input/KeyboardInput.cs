using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input = UnityEngine.Input;


namespace Tools
{
    public class KeyboardInput : MonoBehaviour, IKeyboardInput
    {
        [SerializeField] [Tooltip("The Keyboard key")] KeyCode key;
        public KeyCode Key => key;
        public Action OnKey { get; set; } = () => { };
        public Action OnKeyDown { get; set; } = () => { }; 
        public Action OnKeyUp { get; set; } = () => { };

        private void Update()
        {
            var isKey = Input.GetKey(key);
            var isKeyDown = Input.GetKeyDown(key);
            var isKeyUp = Input.GetKeyUp(key);

            if (isKey)
                OnKey?.Invoke();
            if (isKeyDown)
                OnKeyDown?.Invoke();
            if (isKeyUp)
                OnKeyUp?.Invoke();
        }
    }
}