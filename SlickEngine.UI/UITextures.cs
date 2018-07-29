using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.UI
{
    public class UITextures
    {
        public Texture2D PanelBackground { get; set; }

        public Texture2D Button { get; set; }
        public Texture2D ButtonClick { get; set; }
        
        public Texture2D Toolbar { get; set; }
        public Texture2D ToolbarCloseButton { get; set; }
        public Texture2D ToolbarCloseButtonClicked { get; set; }
        public Texture2D ToolbarIcon { get; set; }
        public SpriteFont ToolbarFont { get; set; }
    }
}
