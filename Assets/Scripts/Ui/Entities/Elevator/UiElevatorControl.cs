﻿using System;
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
        private IElevator Elevator => GameController.Instance.Game.ElevatorMechanics.Elevator;
        private UiButtonTriggerZone PlayerInteraction { get; set; }
        
        private void Awake()
        {
            PlayerInteraction = GetComponentInChildren<UiButtonTriggerZone>();
        }

        private void Start()
        {
            PlayerInteraction.AddListener(SwitchElevatorMechanism);
        }

        private void SwitchElevatorMechanism()
        {
            Elevator.Switch();
        }
    }
}