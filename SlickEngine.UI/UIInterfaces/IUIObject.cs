using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.UI.UIInterface
{
    public interface IUIObject
    {
        Texture2D Texture { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        int X { get; set; }
        int Y { get; set; }

        IUIObject Parent { get; }
        List<IUIObject> Children { get; }

        event EventHandler ClickDown;
        event EventHandler ClickUp;
        event EventHandler RightClick;
        event EventHandler AltClick;
        event EventHandler CtrlClick;
        event EventHandler DoubleClick;

        void Draw(SpriteBatch spritebatch);

        void AddChild(IUIObject iuio, int x, int y);

        void RemoveChild(IUIObject iuio);

        void SetParent(IUIObject iuio);
    }
}
