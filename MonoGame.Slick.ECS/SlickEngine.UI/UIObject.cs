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
    public abstract class UIObject : IUIObject
    {
        public Texture2D Texture { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public IUIObject Parent { get; private set; }

        public List<IUIObject> Children { get; private set; }

        public event EventHandler ClickDown;
        public event EventHandler RightClick;
        public event EventHandler AltClick;
        public event EventHandler CtrlClick;
        public event EventHandler DoubleClick;
        public event EventHandler ClickUp;

        public UIObject(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public void AddChild(IUIObject iuio, int x, int y)
        {
            iuio.SetParent(this);
            iuio.X = x;
            iuio.Y = y;
            Children.Add(iuio);
        }

        private Point GetScreenXY()
        {
            int x = X, y = Y;
            var currentparent = Parent;
            while(currentparent != null)
            {
                x += currentparent.X;
                y += currentparent.Y;
                currentparent = currentparent.Parent;
            }
            return new Point(x, y);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            var p = GetScreenXY();
            spritebatch.Draw(Texture, new Rectangle(p.X, p.Y, Height, Width), Color.White);
            foreach (var c in Children)
                c.Draw(spritebatch);
        }

        public void RemoveChild(IUIObject iuio)
        {
            Children.Remove(iuio);
        }

        public void SetParent(IUIObject iuio)
        {
            Parent = iuio;
        }
    }
}
