namespace MonoGame.Slick.ECS
{
    public interface IEntity
    {
        /// <summary>
        /// X location in relation to map
        /// </summary>
        int X { get; set; }
        /// <summary>
        /// Y location in relation to map
        /// </summary>
        int Y { get; set; }
        /// <summary>
        /// Height
        /// </summary>
        int Width { get; set; }
        /// <summary>
        /// Width
        /// </summary>
        int Height { get; set; }
    }
}
