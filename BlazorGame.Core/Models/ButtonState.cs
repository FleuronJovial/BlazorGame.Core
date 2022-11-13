namespace BlazorGame.Core.Models
{
    public struct ButtonState
    {
        public ButtonState(States state, bool wasPressed)
        {
            State = state;
            WasPressed = wasPressed;
        }

        public bool WasPressed { get; }
        public States State { get; }

        public enum States
        {
            Up = 0,
            Down = 1
        }

        public static readonly ButtonState None = new ButtonState(States.Up, false);
    }
}
