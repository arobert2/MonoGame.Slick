using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.Graphics
{
    public class GraphicPackage
    {
        public Texture2D SpriteSheet { get; set; }
        public Dictionary<string, Rectangle> Frames { get; set; }
    }
}
