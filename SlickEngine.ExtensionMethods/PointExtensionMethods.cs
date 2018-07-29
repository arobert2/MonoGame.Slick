using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlickEngine.ExtensionMethods
{
    public static class PointExtensionMethods
    {
        /// <summary>
        /// Rotates a point around a radian angle
        /// </summary>
        /// <param name="point">Point</param>
        /// <param name="rotate">Angle in radians</param>
        /// <returns>Rotated Point</returns>
        public static Point RotatePoint(this Point point, Point origin, double rotate)
        {
            var cos = Math.Cos(rotate);
            var sin = Math.Sin(rotate);

            var x = point.X - origin.X;
            var y = point.Y - origin.Y;

            var newx = point.X * cos - point.Y * sin;
            var newy = point.X * sin + point.Y * cos;

            var newpoint = new Point((int)newx + origin.X, (int)newy + origin.Y);
            return newpoint;
        }

        /// <summary>
        /// Add an integer to X and Y of a point
        /// </summary>
        /// <param name="p">Point</param>
        /// <param name="a">Integer</param>
        /// <returns>Added point</returns>
        public static Point Add(this Point p, int a)
        {
            return new Point(p.X + a, p.Y + a);
        }

        /// <summary>
        /// Add a point by another point
        /// </summary>
        /// <param name="p">Point</param>
        /// <param name="a">Point to add</param>
        /// <returns>Added Points</returns>
        public static Point Add(this Point p, Point a)
        {
            return new Point(p.X + a.X, p.Y + a.Y);
        }

        /// <summary>
        /// Multiple a point by an integer.
        /// </summary>
        /// <param name="p">Point</param>
        /// <param name="m">Integer</param>
        /// <returns>Multiplied Point</returns>
        public static Point Multiply(this Point p, int m)
        {
            return new Point(p.X * m, p.Y * m);
        }

        /// <summary>
        /// Multiply a point by another point
        /// </summary>
        /// <param name="p">Point</param>
        /// <param name="m">Point to multiply</param>
        /// <returns>Multiplied point</returns>
        public static Point Multiply(this Point p, Point m)
        {
            return new Point(p.X * m.X, p.Y * m.Y);
        }
        /// <summary>
        /// Distance between two points
        /// </summary>
        /// <param name="point">Point 1</param>
        /// <param name="p">Point 2</param>
        /// <returns>Distance</returns>
        public static double Distance(this Point point, Point p)
        {
            return Math.Sqrt(Math.Pow(p.X - point.X, 2) + Math.Pow(p.Y - point.Y, 2));
        }
    }
}
