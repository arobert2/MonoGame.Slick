using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.Slick.ECS.SpriteComponents
{
    public class AnimatedSprite
    {
        public Texture2D SpriteSheet { get; set; }
        public Rectangle[] SpriteMask { get; set; }
        public TimeSpan FramePause { get; set; }
        public int CurrentFrame { get; private set; } = 0;

        public void Update()
        {
            CurrentFrame++;
        }
    }
}
