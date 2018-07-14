using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.Shapes
{
    public interface IShape
    {
        Point Coordinates { get; set; }

        Point CenterCoordinates { get; set; }

        Point[] ParemeterPoints { get; }

        Point[] ParemterPointsDrawLocation { get; }
    }
}
