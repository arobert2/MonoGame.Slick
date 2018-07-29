using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SlickEngine.UI.UIInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.UI
{
    public class Button : UIObject
    {
        public Texture2D TextureClick { get; set; }
        public Texture2D TextureUnClick { get; set; }

        public Button(int height, int width) : base(height, width)
        {
            Height = height;
            Width = width;

            ClickDown += (o, args) =>
            {
                Texture = TextureClick;
            };

            ClickUp += (o, args) =>
            {
                Texture = TextureUnClick;
            };           
        }
    }
}
