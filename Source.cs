using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BuildingDirectionalDiagram
{
    public class Square
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Width, Height;
        public Square(double x, double y, int width, int height)
        {
            X = x; Y = y; Width = width; Height = height;
        }
        public static bool PointInSquare(Point p, Square sq)
        {
            if (p.X > sq.X && p.X < sq.X + sq.Width && p.Y > sq.Y && p.Y < sq.Y + sq.Height)
                return true;
            else return false;
        }
    }
    public partial class Source
    {
        private double X { get; set; }
        private double Y { get; set; }

        private int Width, Height;

        private bool Selected { get; set; }

        public Source(double x, double y, int width, int height)
        {
            X = x; Y = y; Selected = true; Width = width; Height = height;
        }
    }
}
