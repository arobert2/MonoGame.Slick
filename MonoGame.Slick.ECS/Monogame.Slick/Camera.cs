using MonoGame.Slick.ECS;
using System.Collections.Generic;

namespace Monogame.Slick
{
    public class Camera
    {
        /// <summary>
        /// X Center of Camera
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y Center of Camera
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// XSize of Camera
        /// </summary>
        public int CameraSizeX { get; set; }
        /// <summary>
        /// YSize of Camera
        /// </summary>
        public int CameraSizeY { get; set; }
        /// <summary>
        /// Displayed GameWorld
        /// </summary>
        public GameMap gameWorld { get; set; }
        /// <summary>
        /// Get all visible IEntities
        /// </summary>
        /// <returns>List of visible entities</returns>
        private List<IEntity> GetVIsibleIEntity()
        {
            var visible = new List<IEntity>();
            foreach(var ie in gameWorld.MapEntities)
            {
                if ((ie.X + ie.Width / 2 > X - CameraSizeX / 2 && ie.X - ie.Width / 2 < CameraSizeX / 2) && 
                    (ie.Y + ie.Height / 2 > Y - CameraSizeY / 2 && ie.Y - ie.Height / 2 < Y - CameraSizeY / 2))
                    visible.Add(ie);
            }

            return visible;
        }
    }
}
