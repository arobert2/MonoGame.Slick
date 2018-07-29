using Microsoft.Xna.Framework;
using SlickEngine.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.Map
{
    public class MapTile
    {
        public Rectangle TextureFrame { get; set; }

        public IShape Tile { get; set; }
    }
}
