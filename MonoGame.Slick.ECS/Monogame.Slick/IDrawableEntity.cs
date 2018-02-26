using MonoGame.Slick.ECS;
using MonoGame.Slick.ECS.SpriteComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame.Slick
{
    public interface IDrawableEntity : IEntity
    {
        SpriteComponent Sprite { get; set; }
    }
}
