using Microsoft.Xna.Framework;
using SlickEngine.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.Shapes
{
    public class Hexagon : IShape
    {
        /// <summary>
        /// Radius of the Hexagon
        /// </summary>
        public int Radius { get; set; }
        /// <summary>
        /// Angle of Left and Right sides
        /// </summary>
        public double Tilt { get; set; } = 1.0472;
        /// <summary>
        /// Is the hexagon rotated 90 degrees.
        /// </summary>
        public bool Rotate { get; set; } = true;
        /// <summary>
        /// Coordinates on an XYZ Plane
        /// </summary>
        public Cubic CubicCoordinates { get; set; }
        /// <summary>
        /// Coordinates on an XY Plane
        /// </summary>
        public Point Coordinates { get; set; }
        /// <summary>
        /// Center coordinates in relation to size
        /// </summary>
        public Point CenterCoordinates { get; set; } = new Point( 0, 0 );

        private int _radiusTilt { get { return (int)(1.0472 / Tilt * 100); } }
        /// <summary>
        /// Get Paremeter Points
        /// </summary>
        public Point[] ParemeterPoints {
            get
            {
                var points = new List<Point>();

                points.Add(new Point(0 + Radius, 0).RotatePoint(new Point(0,0), Tilt / 2));
                points.Add(new Point(0, 0 + _radiusTilt));
                points.Add(new Point(0 - Radius, 0).RotatePoint(new Point(0, 0), Tilt / 2 - 3.14159));
                points.Add(new Point(0 - Radius, 0).RotatePoint(new Point(0, 0), Tilt / 2 + 3.14159));
                points.Add(new Point(0, 0 - _radiusTilt));
                points.Add(new Point(0 + Radius, 0).RotatePoint(new Point(0, 0), Tilt / 2 * -1));

                var p = points;
                points = new List<Point>();
                foreach(var pts in p)
                {
                    points.Add(pts.RotatePoint(new Point(0, 0), 1.5708));
                }

                return points.ToArray();
            }
        }
        /// <summary>
        /// Get points in relation to the center X Y coordinates
        /// </summary>
        public Point[] ParemterPointsDrawLocation
        {
            get
            {
                var points = new List<Point>();
                foreach (Point p in ParemeterPoints)
                    points.Add(p.Add(CenterCoordinates));
                return points.ToArray();
            }
        }

        public Hexagon(int radius)
        {
            Radius = radius;
        }
    }
}
