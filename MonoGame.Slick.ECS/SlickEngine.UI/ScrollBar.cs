using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.UI
{
    public class ScrollBar : UIObject
    {
        public bool Horizontal { get; set; }

        public ScrollBar(int height, int width) : base(height, width)
        {
            if (Horizontal)
            {
                Children.Add(new Button(height, height) { X = 0, Y = 0, Texture = DefaultUITextures.LeftScrollButton });
                Children.Add(new Button(height, height) { X = Width - height, Y = 0, Texture = DefaultUITextures.RightScrollButton });
            }
            else
            {
                Children.Add(new Button(width, width) { X = 0, Y = 0, Texture = DefaultUITextures.UpScrollButton });
                Children.Add(new Button(width, width) { X = Height - width, Y = 0, Texture = DefaultUITextures.DownScrollButton });
            }
        }
    }
}
