using MonoGame.Slick.ECS.Contracts;
using System;
using System.Collections.Generic;

namespace MonoGame.Slick.ECS.InputComponent
{
    public class CommandUnavailableException : Exception
    {

    }
    public class KeyboardInputManager
    {
        public List<ICommand> AvailableCommands { get; private set; } = new List<ICommand>();
        public Dictionary<Keys, ICommand> AssignedCommands { get; private set; } = new Dictionary<Keys, ICommand>();

        public void AssignKey (Keys k, ICommand command)
        {
            if (AvailableCommands.Contains(command))
                AssignedCommands[k] = command;
            else
                throw new CommandUnavailableException();
        }

        public void UnassignKey (Keys k)
        {
            AssignedCommands.Remove(k);
        }
    }
}
