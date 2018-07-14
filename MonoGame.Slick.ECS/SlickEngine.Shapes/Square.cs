using Microsoft.Xna.Framework;
using SlickEngine.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.Shapes
{
    public class Square : IShape
    {
        /// <summary>
        /// Height and Width of square
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// Coordinates in a 2d plane
        /// </summary>
        public Point Coordinates { get; set; }
        /// <summary>
        /// Coordinates for the center of the square
        /// </summary>
        public Point CenterCoordinates { get; set; }
        /// <summary>
        /// Get Paremeter Points
        /// </summary>
        public Point[] ParemeterPoints
        {
            get
            {
                var points = new List<Point>();

                points.Add(new Point(Size / 2, Size / 2));
                points.Add(new Point(Size / 2 * -1, Size / 2));
                points.Add(new Point(Size / 2 * -1, Size / 2 * -1));
                points.Add(new Point(Size / 2, Size / 2 * -1));

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
                var points = ParemeterPoints;
                var newPoints = new List<Point>();
                foreach (var pts in points)
                    newPoints.Add(pts.Add(CenterCoordinates));
                return newPoints.ToArray();
            }
        }
    }
}
