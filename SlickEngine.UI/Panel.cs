using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SlickEngine.UI.UIInterface;
using SlickEngine.UI.UIInterfaces;

namespace SlickEngine.UI
{
    public class Panel : UIObject, IResizable
    {
        public bool ResizeEnabled { get; set; } = false;

        public Panel(int height, int width) : base(height, width)
        {

        }

        public void Resize(int x, int y, Point origin)
        {
            
        }
    }
}
