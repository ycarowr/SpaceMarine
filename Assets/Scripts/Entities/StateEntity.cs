using UnityEngine;

namespace SpaceMarine
{
    /// <summary>
    ///     Entities which somehow interact with the player.
    /// </summary>
    public abstract class StateEntity : BaseEntity
    {
        /// <summary>
        ///     State of the entity.
        /// </summary>
        public enum State
        {
            Off,
            On
        }
        
        public State Current { get; private set; }
        public bool IsProcessing => Current == State.On;
        public bool IsDisabled=> Current == State.Off;
        
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
        private void SwitchOn()
        {
            if (!IsDisabled)
                return;
            
            Current = State.On;
            OnStartProcessing();
        }

        /// <summary>
        ///     Turns off the entity.
        /// </summary>
        private void SwitchOff()
        {
            if (!IsProcessing)
                return;
            
            Current = State.Off;
            OnStopProcessing();
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