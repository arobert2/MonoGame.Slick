using Microsoft.Xna.Framework;
using SlickEngine.UI.UIInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.Map
{
    interface IMapItem : IUIObject
    {
        Rectangle TextureFrame { get; set; }
        int MaxVisibleRange { get; set; }
        int MinVisibleRange { get; set; }
    }
}
