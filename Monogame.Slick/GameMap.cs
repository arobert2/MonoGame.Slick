﻿using Microsoft.Xna.Framework.Graphics;
using MonoGame.Slick.ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame.Slick
{
    public class GameMap
    {
        public virtual List<IDrawableEntity> MapEntities { get; set; } = new List<IDrawableEntity>();

        public Texture2D Background { get; set; }
        public bool XWrap { get; set; }
        public bool YWrap { get; set; }
        public float BackgroundScrollRate { get; set; } = 0.001f;
    }
}
