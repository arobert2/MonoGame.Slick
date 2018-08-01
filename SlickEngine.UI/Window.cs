using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.UI
{
    public class Window : UIObject
    {
        /// <summary>
        /// Toolbar height
        /// </summary>
        public int WindowBarHeight
        {
            get
            {
                return Children[0].Height;
            }
            set
            {
                Children[0].Height = value;
            }
        }

        public Window(int height, int width) : base(height, width)
        {
        }
    }

    public class WindowBar : UIObject
    {
        private bool _objectIsClicked { get; set; }
        public SpriteFont Font { get; set; }
        public string ToolbarTitle;

        public WindowBar(int height, int width) : base(height, width)
        {
            this.ClickDown += (o, args) =>
            {
                if (_objectIsClicked)
                {
                    var mouseState = Mouse.GetState();
                    Parent.X += mouseState.X;
                    Parent.Y += mouseState.Y;
                }

                _objectIsClicked = true;
            };

            this.ClickDown += (o, args) =>
            {
                _objectIsClicked = false;
            };
        }
    }
}
