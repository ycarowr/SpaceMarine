using UnityEngine;

namespace SpaceMarine
{
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
        
        private void SwitchOn()
        {
            if (!IsDisabled)
                return;
            
            Current = State.On;
            OnStartProcessing();
        }

        private void SwitchOff()
        {
            if (!IsProcessing)
                return;
            
            Current = State.Off;
            OnFinishProcessing();
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
        protected virtual void OnFinishProcessing()
        {
            //Override to do something.
        }
    }
}