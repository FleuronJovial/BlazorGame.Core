using BlazorGame.Core.Enums;
using BlazorGame.Core.Interfaces;
using BlazorGame.Core.Models;
using BlazorGame.Core.Utils;

namespace BlazorGame.Core.Services
{
    public class InputService : IGameService
    {
        private readonly IDictionary<MouseButtons, ButtonState> _buttonStates;
        private readonly IDictionary<Keys, ButtonState> _keyboardStates;

        public InputService()
        {
            _buttonStates = EnumUtils.GetAllValues<MouseButtons>()
                .ToDictionary(v => v, v => ButtonState.None);

            _keyboardStates = EnumUtils.GetAllValues<Keys>()
                                       .ToDictionary(v => v, v => ButtonState.None);
        }

        public void SetButtonState(MouseButtons button, ButtonState.States state)
        {
            var oldState = _buttonStates[button];
            _buttonStates[button] = new ButtonState(state, oldState.State == ButtonState.States.Down);
        }

        public ButtonState GetButtonState(MouseButtons button) => _buttonStates[button];

        public void SetKeyState(Keys key, ButtonState.States state)
        {
            var oldState = _keyboardStates[key];
            _keyboardStates[key] = new ButtonState(state, oldState.State == ButtonState.States.Down);
        }

        public ButtonState GetKeyState(Keys key) => _keyboardStates[key];

        public ValueTask Step() => ValueTask.CompletedTask;
    }






}