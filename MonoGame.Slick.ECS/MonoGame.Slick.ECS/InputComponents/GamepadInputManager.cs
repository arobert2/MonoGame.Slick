using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoGame.Slick.ECS.InputComponents
{
    public class UnchangeableCommandException : Exception
    { }
    public class GamePadInputManager
    {
        /***************************
         * Global Deadzone Settings
         */

        /// <summary>
        /// Positive X deadzone
        /// </summary>
        public static float DeadZonePX = 0.05f;
        /// <summary>
        /// Negative X deadzone
        /// </summary>
        public static float DeadZoneNX = -0.05f;
        /// <summary>
        /// Positive Y deadzone
        /// </summary>
        public static float DeadZonePY = 0.05f;
        /// <summary>
        /// Negative Y deadzone
        /// </summary>
        public static float DeadZoneNY = -0.05f;

        /**********************************************
         * Thumbstick and Trigger ICommand assignments
         */

        /// <summary>
        /// Left trigger deadzone
        /// </summary>
        public static float DeadZoneLeftTrigger = 0.01f;
        /// <summary>
        /// Right trigger deadzone
        /// </summary>
        public static float DeadZoneRightTrigger = 0.01f;
        /// <summary>
        /// Stick 1 up ICommand
        /// </summary>
        public ICommand StickOneUp { get; set; }
        /// <summary>
        /// Stick 1 Down ICommand
        /// </summary>
        public ICommand StickOneDown { get; set; }
        /// <summary>
        /// Stick 1 Left ICommand
        /// </summary>
        public ICommand StickOneLeft { get; set; }
        /// <summary>
        /// Stick 1 Right ICommand
        /// </summary>
        public ICommand StickOneRight { get; set; }
        /// <summary>
        /// Stick 2 up ICommand
        /// </summary>
        public ICommand StickTwoUp { get; set; }
        /// <summary>
        /// Stick 2 down ICommand
        /// </summary>
        public ICommand StickTwoDown { get; set; }
        /// <summary>
        /// Stick 2 left ICommand
        /// </summary>
        public ICommand StickTwoLeft { get; set; }
        /// <summary>
        /// Stick 2 right ICommand
        /// </summary>
        public ICommand StickTwoRight { get; set; }
        /// <summary>
        /// Left trigger ICommand
        /// </summary>
        public ICommand LeftTrigger { get; set; }
        /// <summary>
        /// Right trigger ICommand
        /// </summary>
        public ICommand RightTrigger { get; set; }

        /***********************
         * Assignable Commands
         */

        /// <summary>
        /// List of available commands in this GamePadInputManager
        /// </summary>
        public ICommand[] AvailableCommands { get; private set; }
        /// <summary>
        /// List of assigned commands in this GamePadInputManager
        /// </summary>
        public Dictionary<Buttons, ICommand> AssignedCommands { get; private set; } = new Dictionary<Buttons, ICommand>();
        /// <summary>
        /// Create a new GamePadInputManager
        /// </summary>
        /// <param name="availableCommands">Commands available to this input manager</param>
        public GamePadInputManager(ICommand[] availableCommands)
        {
            AvailableCommands = availableCommands;
        }
        /// <summary>
        /// Assign A button to a command
        /// </summary>
        /// <param name="b">Button to assign</param>
        /// <param name="command">ICommand button is assigned to</param>
        public void AssignButton(Buttons b, ICommand command)
        {
            if (StickOneDown == command || StickOneUp == command || StickOneLeft == command || StickOneRight == command ||
                StickTwoDown == command || StickTwoUp == command || StickTwoLeft == command || StickTwoRight == command)
                throw new UnchangeableCommandException();

            if (AvailableCommands.Contains(command))
                AssignedCommands[b] = command;
            else
                throw new CommandUnavailableException();
        }
        /// <summary>
        /// Unassign a button from an ICommand
        /// </summary>
        /// <param name="b"></param>
        public void UnassignButton(Buttons b)
        {
            AssignedCommands.Remove(b);
        }
    }
}
