using UnityEngine;

namespace SpaceMarine
{
    /// <summary>
    ///     Entities which somehow interact with the player.
    /// </summary>
    public abstract class UiStateEntity : UiBaseEntity
    {
        /// <summary>
        ///     State of the entity.
        /// </summary>
        public enum State
        {
            Off,
            On,
            Inactive
        }
        
        public State Current { get; private set; }
        public bool IsProcessing => Current == State.On;
        public bool IsDisabled => Current == State.Off;
        public bool IsActive => Current != State.Inactive;
        
        //--------------------------------------------------------------------------------------------------------------

        protected override void OnTriggerEnterPlayer()
        {
            SwitchOn();
        }

        protected override void OnTriggerExitPlayer()
        {
            SwitchOff();
        }

        //--------------------------------------------------------------------------------------------------------------
        
        /// <summary>
        ///     Turns on the entity.
        /// </summary>
        public void SwitchOn()
        {
            if (!IsActive)
                return;
            
            Current = State.On;
            OnStartProcessing();
        }

        /// <summary>
        ///     Turns off the entity.
        /// </summary>
        public void SwitchOff()
        {
            if (!IsActive)
                return;
            
            Current = State.Off;
            OnStopProcessing();
        }

        public void SetState(State state)
        {
            Current = state;
        }
        
        //--------------------------------------------------------------------------------------------------------------

        /// <summary>
        ///     Fired when it collides with the player.
        /// </summary>
        protected virtual void OnStartProcessing()
        {
            //Override to do something.
        }
        
        /// <summary>
        ///     Fired when the player exit the collision.
        /// </summary>
        protected virtual void OnStopProcessing()
        {
            //Override to do something.
        }
    }
}