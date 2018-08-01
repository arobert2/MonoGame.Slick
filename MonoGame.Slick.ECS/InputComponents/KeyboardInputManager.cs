using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoGame.Slick.ECS.InputComponents
{
    public class CommandUnavailableException : Exception
    { }
    public class KeyboardInputManager
    {
        /// <summary>
        /// Commands available to this KeyboardInputManager
        /// </summary>
        public ICommand[] AvailableCommands { get; private set; }
        /// <summary>
        /// Commands with keys assigned available to this KeyboardInputManager
        /// </summary>
        public Dictionary<Keys, ICommand> AssignedCommands { get; private set; } = new Dictionary<Keys, ICommand>();
        /// <summary>
        /// Create a new KeyboardInputManager
        /// </summary>
        /// <param name="availableCommands">ICommands available to the KeyboardInputManager</param>
        public KeyboardInputManager(ICommand[] availableCommands)
        {
            AvailableCommands = availableCommands;
        }
        /// <summary>
        /// Assign a key to an ICommand
        /// </summary>
        /// <param name="k">Key to assign</param>
        /// <param name="command">ICommand key will be assigned to.</param>
        public void AssignKey (Keys k, ICommand command)
        {
            if (AvailableCommands.Contains(command))
                AssignedCommands[k] = command;
            else
                throw new CommandUnavailableException();
        }
        /// <summary>
        /// Remove a key assignment
        /// </summary>
        /// <param name="k">Key to remove assignment from.</param>
        public void UnassignKey (Keys k)
        {
            AssignedCommands.Remove(k);
        }
    }
}
