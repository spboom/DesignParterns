using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static double distanceBetween(Coordinate coordinate1, Coordinate coordinate2)
        {
            double dx = Math.Abs(coordinate1.X - coordinate2.X);
            double dy = Math.Abs(coordinate1.Y - coordinate2.Y);
            return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        }
    }
}
