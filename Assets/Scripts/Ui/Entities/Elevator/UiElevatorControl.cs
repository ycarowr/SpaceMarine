using System;
using System.Diagnostics;
using SpaceMarine.Model;
using Tools;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace SpaceMarine
{
    /// <summary>
    ///     Controls the elevator.
    /// </summary>
    public class UiElevatorControl : MonoBehaviour
    {
        private IElevatorControl ElevatorControl =>
            GameObject.FindObjectOfType<GameController>().Game.ElevatorMechanics.ElevatorControl;//GameController.Instance.Game.ElevatorMechanics.ElevatorControl;
        private PressButtonNotification PlayerInteraction { get; set; }
        
        private void Awake()
        {
            PlayerInteraction = GetComponentInChildren<PressButtonNotification>();
        }

        private void Start()
        {
            PlayerInteraction.AddListener(SwitchElevatorMechanism);
        }

        private void SwitchElevatorMechanism()
        {
            ElevatorControl.Switch();
        }
    }
}