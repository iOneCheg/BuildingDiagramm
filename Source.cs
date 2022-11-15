using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;

namespace BuildingDirectionalDiagram
{
    public class Square
    {
        public double X { get; set; }
        public double Y { get; set; }


        public Vector2d Center
        {
            get => new Vector2d(X + Width / 2, Y + Height / 2);
        }
        public int Width, Height;
        public Square(double x, double y, int width, int height)
        {
            X = x; Y = y; Width = width; Height = height; IsSetted = false;
        }
        public static bool PointInSquare(Point p, Square sq)
        {
            if (p.X > sq.X && p.X < sq.X + sq.Width && p.Y > sq.Y && p.Y < sq.Y + sq.Height)
                return true;
            else return false;
        }
        public static bool PointInSettedSquare(Point p,Square sq)
        {
            if (PointInSquare(p, sq) && sq.IsSetted == true)
            {
                return true;
            }
            else return false;
        }
        public bool IsSetted { get; set; }

    }
    public partial class Source
    {
        public double X { get; set; }
        public double Y { get; set; }

        private bool Selected { get; set; }

        public Source(double x, double y)
        {
            X = x; Y = y; Selected = true;
        }
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Source s = (Source)obj;
                return (X == s.X) && (Y == s.Y);
            }
        }
    }
}
