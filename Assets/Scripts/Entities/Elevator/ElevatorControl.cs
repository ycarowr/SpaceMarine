using System;
using System.Diagnostics;
using Tools;
using UnityEngine;

namespace SpaceMarine
{
    /// <summary>
    ///     Controls the elevator.
    /// </summary>
    public class ElevatorControl : MonoBehaviour
    {
        /// <summary>
        ///     Fired when the elevator changes state.
        /// </summary>
        public static Action<bool> OnSwitchElevator = (isEnabled) => { };
        
        /// <summary>
        ///     Whether the elevator is enabled or not.
        /// </summary>
        public bool IsElevatorEnabled { get; private set; }
        
        
        private PressButtonNotification PlayerInteraction { get; set; }

        
        private void Awake()
        {
            PlayerInteraction = GetComponentInChildren<PressButtonNotification>();
            PlayerInteraction.OnPressButton += SwitchElevatorMechanism;
        }

        /// <summary>
        ///     Locks or unlocks the elevator.
        /// </summary>
        private void SwitchElevatorMechanism()
        {
            IsElevatorEnabled = !IsElevatorEnabled;
            OnSwitchElevator?.Invoke(IsElevatorEnabled);
        }
    }
}