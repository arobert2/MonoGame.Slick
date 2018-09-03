using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SlickEngine.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.Map
{
    public class Map<T> where T : IShape
    {
        public Texture Texture { get; set; }

        public T[,] MapTile { get; set; }

        public Rectangle[,] TextureTiles { get; set; }

        public MapTile this[int x, int y]
        {
            get
            {
                var maptile = new MapTile();
                maptile.Tile = MapTile[x, y];
                maptile.TextureFrame = TextureTiles[x, y];

                /// Add new MapTIle items here.

                return maptile;
            }
        }

        public Map(int x, int y)
        {
            MapTile = new T[x, y];
        }
    }
}
