using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.UI.UIInterfaces
{
    public interface IResizable
    {
        bool ResizeEnabled { get; set; }

        void Resize(int x, int y, Point origin);
    }
}
