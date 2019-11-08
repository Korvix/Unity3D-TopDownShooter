using UnityEngine;
using XInputDotNetPure;

namespace TopDownShooter.GameSystem
{
    public class InputSystem : MonoBehaviour
    {
        private InputData inputData;
        private GamePadState state;
        private GamePadState prevState;

        void Awake()
        {
            inputData = GameContext.Instance.InputData;
        }
        
        void Update()
        {
            prevState = state;
            state = GamePad.GetState(PlayerIndex.One);            
            inputData.leftArrow = Input.GetKey(KeyCode.LeftArrow);
            inputData.rightArrow = Input.GetKey(KeyCode.RightArrow);
            inputData.upArrow = Input.GetKey(KeyCode.UpArrow);
            inputData.downArrow = Input.GetKey(KeyCode.DownArrow);
            inputData.space = Input.GetKey(KeyCode.Space);
            inputData.leftStickX = state.ThumbSticks.Left.X;
            inputData.leftStickY = state.ThumbSticks.Left.Y;
            inputData.triggerRight = state.Triggers.Right;
            inputData.triggerLeft = state.Triggers.Left;
            inputData.aButtonDown = state.Buttons.A == ButtonState.Pressed && prevState.Buttons.A == ButtonState.Released;
            inputData.backButtonDown = state.Buttons.Back == ButtonState.Pressed && prevState.Buttons.Back == ButtonState.Released;
            inputData.rightStickX = state.ThumbSticks.Right.X;
            inputData.yButtonDown = state.Buttons.Y == ButtonState.Pressed && prevState.Buttons.Y == ButtonState.Released;
        }
    }
}