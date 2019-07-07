namespace SpaceMarine
{
    public class UiPlayerAttributes
    {
        public UiPlayerAttributes(IUiPlayer uiPlayer)
        {
            UiPlayer = uiPlayer;
            Parameters = uiPlayer.Parameters;
        }

        private UiPlayerParameters Parameters { get; }
        private IUiPlayer UiPlayer { get; }
        public bool IsDead { get; set; }
        public bool IsMoving => UiPlayer.Input.Horizontal != 0 && !UiPlayer.Input.IsShootPressed && IsGrounded;
        public bool IsLeft => UiPlayer.Input.Horizontal < 0;
        public bool IsIdle => IsGrounded && !IsMoving;
        public bool IsShotting => UiPlayer.Input.IsShootPressed;
        public bool IsGrounded { get; private set; }
        public void SetGrounded(bool isGrounded)
        {
            IsGrounded = isGrounded;
        }
    }
}