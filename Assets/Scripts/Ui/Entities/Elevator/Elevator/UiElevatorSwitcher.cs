using SpaceMarine.Model;
using Tools.Patterns.GameEvents;

namespace SpaceMarine
{
    public class UiElevatorSwitcher : UiGameEventListener, GameEvent.IOnSwitchElevator, GameEvent.IStartGame
    {
        UiElevator UiElevator { get; set; }
        UiButtonTriggerZone ButtonETrigger { get; set; }

        void GameEvent.IOnSwitchElevator.OnSwitch(bool isEnabled) => SwitchElevator(isEnabled);

        //--------------------------------------------------------------------------------------------------------------

        void GameEvent.IStartGame.OnStartGame(IGame game) => SwitchOff();

        protected override void Awake()
        {
            base.Awake();
            UiElevator = GetComponent<UiElevator>();
            ButtonETrigger = GetComponentInChildren<UiButtonTriggerZone>();
        }

        //--------------------------------------------------------------------------------------------------------------

        public void SwitchElevator(bool isEnabled)
        {
            if (isEnabled)
                SwitchOn();
            else
                SwitchOff();
        }

        public void SwitchOn()
        {
            ButtonETrigger.SetState(UiStateEntity.State.Off);
            UiElevator.ElevatorAnimations.SwitchOn();
        }

        public void SwitchOff()
        {
            ButtonETrigger.SetState(UiStateEntity.State.Inactive);
            UiElevator.ElevatorAnimations.SwitchOff();
        }
    }
}