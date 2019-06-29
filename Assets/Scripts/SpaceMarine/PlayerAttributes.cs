namespace SpaceMarine
{
    public class PlayerAttributes
    {
        public PlayerAttributes(IPlayer player)
        {
            Player = player;
            Parameters = player.Parameters;
        }

        private IPlayer Player { get; }
        private PlayerParameters Parameters { get; }

        public bool IsDead { get; set; }
        public bool IsGrounded { get; set; }

        //movement
        public bool IsMoving => Player.Input.Horizontal != 0 && !Player.Input.IsShootPressed && IsGrounded;
        public bool IsLeft => Player.Input.Horizontal < 0;
        public bool IsRight => Player.Input.Horizontal > 0;
        public bool IsJump => !IsGrounded;
        public bool IsIdle => IsGrounded && !IsMoving;

        public bool IsShotting => Player.Input.IsShootPressed;
    }
}