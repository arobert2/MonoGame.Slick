namespace MonoGame.Slick.ECS
{
    public interface IEntity
    {
        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }

        void Update();
    }
}
