using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGame.Slick.ECS.InputComponents
{
    public class InputComponent
    {
        /// <summary>
        /// InputManager for gamepads
        /// </summary>
        public GamePadInputManager GamePadInputManager { get; set; }
        /// <summary>
        /// InputManager for Keyboards
        /// </summary>
        public KeyboardInputManager KeyboardInputManager { get; set; }
        /// <summary>
        /// Execute commands based on the keys and gamepad informtion sent to the InputComponent
        /// </summary>
        /// <param name="ientity">IEntity this component belongs to.</param>
        /// <param name="keyboardState">Current keyboard state</param>
        /// <param name="gamePadState">Current gamepad state</param>
        /// <param name="timespan">time of update trigger</param>
        public void Update(IEntity ientity, KeyboardState? keyboardState, GamePadState? gamePadState, TimeSpan? timespan)
        {
            //Stop if no keyboard or gamepad data
            if (!keyboardState.HasValue && !gamePadState.HasValue)
                return;
            //if KeyboardState data passed
            if (keyboardState.HasValue)
            {
                var keys = keyboardState.Value.GetPressedKeys();    //Get keys pressed
                //Run all commands that keys are pressed for.
                foreach (var k in keys)
                    this.KeyboardInputManager.AssignedCommands[k]?.Execute(ientity, null, timespan);
            }
            //if GamePadStateData is passed
            if (gamePadState.HasValue)
            {
                var lthumb = gamePadState.Value.ThumbSticks.Left;   //Left thumbstick data
                var rthumb = gamePadState.Value.ThumbSticks.Right;  //Right thumbstick data
                var ltrigger = gamePadState.Value.Triggers.Left;    //Left trigger data
                var rtrigger = gamePadState.Value.Triggers.Right;   //Right trigger data

                //Execute Left thumbstick commands
                if (lthumb.X > GamePadInputManager.DeadZonePX)
                    GamePadInputManager.StickOneLeft?.Execute(ientity, gamePadState, timespan);
                if (lthumb.X < GamePadInputManager.DeadZoneNX)
                    GamePadInputManager.StickOneRight?.Execute(ientity, gamePadState, timespan);
                if (lthumb.Y > GamePadInputManager.DeadZonePY)
                    GamePadInputManager.StickOneUp?.Execute(ientity, gamePadState, timespan);
                if (lthumb.Y < GamePadInputManager.DeadZoneNY)
                    GamePadInputManager.StickOneDown?.Execute(ientity, gamePadState, timespan);

                //Execute Right thumbstick commands
                if (rthumb.X > GamePadInputManager.DeadZonePX)
                    GamePadInputManager.StickTwoLeft?.Execute(ientity, gamePadState, timespan);
                if (rthumb.X < GamePadInputManager.DeadZoneNX)
                    GamePadInputManager.StickTwoRight?.Execute(ientity, gamePadState, timespan);
                if (rthumb.Y > GamePadInputManager.DeadZonePY)
                    GamePadInputManager.StickTwoUp?.Execute(ientity, gamePadState, timespan);
                if (rthumb.Y < GamePadInputManager.DeadZoneNY)
                    GamePadInputManager.StickTwoDown?.Execute(ientity, gamePadState, timespan);

                //Execute trigger commands
                if (ltrigger > GamePadInputManager.DeadZoneLeftTrigger)
                    GamePadInputManager.LeftTrigger?.Execute(ientity, gamePadState, timespan);
                if (rtrigger > GamePadInputManager.DeadZoneRightTrigger)
                    GamePadInputManager.RightTrigger?.Execute(ientity, gamePadState, timespan);

                //Execute button commands
                if (gamePadState.Value.IsButtonDown(Buttons.A))
                    GamePadInputManager.AssignedCommands[Buttons.A]?.Execute(ientity, null, timespan);
                if (gamePadState.Value.IsButtonDown(Buttons.B))
                    GamePadInputManager.AssignedCommands[Buttons.B]?.Execute(ientity, null, timespan);
                if (gamePadState.Value.IsButtonDown(Buttons.Back))
                    GamePadInputManager.AssignedCommands[Buttons.Back]?.Execute(ientity, null, timespan);
                if (gamePadState.Value.IsButtonDown(Buttons.BigButton))
                    GamePadInputManager.AssignedCommands[Buttons.BigButton]?.Execute(ientity, null, timespan);
                if (gamePadState.Value.IsButtonDown(Buttons.DPadDown))
                    GamePadInputManager.AssignedCommands[Buttons.DPadDown]?.Execute(ientity, null, timespan);
                if (gamePadState.Value.IsButtonDown(Buttons.DPadUp))
                    GamePadInputManager.AssignedCommands[Buttons.DPadUp]?.Execute(ientity, null, timespan);
                if (gamePadState.Value.IsButtonDown(Buttons.DPadLeft))
                    GamePadInputManager.AssignedCommands[Buttons.DPadLeft]?.Execute(ientity, null, timespan);
                if (gamePadState.Value.IsButtonDown(Buttons.DPadRight))
                    GamePadInputManager.AssignedCommands[Buttons.DPadRight]?.Execute(ientity, null, timespan);
                if (gamePadState.Value.IsButtonDown(Buttons.LeftShoulder))
                    GamePadInputManager.AssignedCommands[Buttons.LeftShoulder]?.Execute(ientity, null, timespan);
                if (gamePadState.Value.IsButtonDown(Buttons.LeftStick))
                    GamePadInputManager.AssignedCommands[Buttons.LeftStick]?.Execute(ientity, null, timespan);
                if (gamePadState.Value.IsButtonDown(Buttons.RightShoulder))
                    GamePadInputManager.AssignedCommands[Buttons.RightShoulder]?.Execute(ientity, null, timespan);
                if (gamePadState.Value.IsButtonDown(Buttons.RightStick))
                    GamePadInputManager.AssignedCommands[Buttons.RightStick]?.Execute(ientity, null, timespan);
                if (gamePadState.Value.IsButtonDown(Buttons.Start))
                    GamePadInputManager.AssignedCommands[Buttons.Start]?.Execute(ientity, null, timespan);
                if (gamePadState.Value.IsButtonDown(Buttons.X))
                    GamePadInputManager.AssignedCommands[Buttons.X]?.Execute(ientity, null, timespan);
                if (gamePadState.Value.IsButtonDown(Buttons.Y))
                    GamePadInputManager.AssignedCommands[Buttons.Y]?.Execute(ientity, null, timespan);
            }
        }
    }
}
