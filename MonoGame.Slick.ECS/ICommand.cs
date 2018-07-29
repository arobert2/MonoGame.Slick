using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGame.Slick.ECS
{
    public interface ICommand
    {
        /// <summary>
        /// Name of command
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Description of command
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Execute a command method for this ICommand object
        /// </summary>
        /// <param name="ientity">IEntity that will be manipulated by this command</param>
        /// <param name="gamePadState">GamePadState for referencing trigger and tumbstick data</param>
        /// <param name="timeSpan">Last time this command was executed</param>
        void Execute(IEntity ientity, GamePadState? gamePadState, TimeSpan? timeSpan);
    }
}
