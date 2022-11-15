using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vector2 = OpenTK.Vector2;

namespace BuildingDirectionalDiagram
{
    public class PointG : IComparable<PointG>
    {
        public Vector2d GridPosition { get; set; }
        public double Height { get; set; }
        public bool IsSource { get; set; }
        public int indexI,indexJ;

        public PointG(Vector2d position, double Height,int i,int j)
        {
            GridPosition = position;
            this.Height = Height;
            this.indexI = i;
            this.indexJ = j;
        }

        public double Distance(PointG p, Source sp)
        {
            double dX = (sp.X - p.GridPosition.X) * (sp.X - p.GridPosition.X),
                dY = (sp.Y - p.GridPosition.Y) * (sp.Y - p.GridPosition.Y),
                dZ =  p.Height * p.Height;
            return Math.Sqrt(dX + dY + dZ);
        }

        public int CompareTo(PointG other)
        {
            if (this.Height > other.Height)
                return 1;
            if (this.Height < other.Height)
                return -1;
            else return 0;
        }
    }
    public class DiagramPoints
    {
        public List<PointG> _spherePoints = new List<PointG>();
        public List<Source> _sources = new List<Source>();
        public List<PointG> _intensityPoints = new List<PointG>();
        //R - кол-во квадратов (как половина ширины большого квадрата)

        // Обрезание точек окружности
        public void ClippingPoints(int R, double D)
        {
            _spherePoints.RemoveAll(pG=>
            {
                if (!(pG.GridPosition.X * pG.GridPosition.X +
                pG.GridPosition.Y * pG.GridPosition.Y <= R * D * R * D))
                {
                    return true;
                }
                else return false;
            });
        }

        //Задаем высоту точкам (из уравнения сферы)
        public List<PointG> SetHeightPoints(int R, double D)
        {
            _spherePoints.ForEach(point =>
            {
                point.Height = Math.Sqrt(R * D * R * D -
                    point.GridPosition.X * point.GridPosition.X -
                    point.GridPosition.Y * point.GridPosition.Y);
            });
            return _spherePoints;
        }
        public List<PointG> GetIntensityPoints(List<Source> sources, double k, double A)    //k - волновое число
        {
            _spherePoints.ForEach(p =>
            {
                double hIntensity = IntensityHeight(sources, p, k, A);
                p.Height = hIntensity;
            });
            return _spherePoints;
        }
        public double IntensityHeight(List<Source> s, PointG pG, double k, double A)
        {
            Complex sum = 0;
            for (var i = 0; i < s.Count; i++)
            {
                double r = pG.Distance(pG, s[i]);
                double x = Math.Cos(k * r);
                double y = Math.Sin(k * r);
                Complex value = new Complex(x,-y);
                sum += value / r;
            }
            return sum.Magnitude;
        }
        public DiagramPoints(int R, double D)  //Width - половина ширины окна 10х10 (в пикселях)
        {
            // Sposob 1
            //var list = _spherePoints.Select(point => !_digPoints.Contains(point));
            //// Sposob 2
            //_digPoints.ForEach(point =>
            //{
            //    if (_spherePoints.Contains(point)) _spherePoints.Remove(point);
            //});

            Vector2d leftUp = new Vector2d(-R * D, R * D); //Координаты левого вернего угла в координатах относительно D 
            Vector2d rightUp = new Vector2d(R * D, R * D); //Координаты правого вернего угла в координатах относительно D

            Vector2d leftDown = new Vector2d(-R * D, -R * D); //Координаты левого нижнего угла в координатах относительно D
            int indexI = 0;
            for (double x = leftUp.X + D / 2; x < rightUp.X; x += D)
            {
                int indexJ = 0;
                for (double y = leftUp.Y - D / 2; y > leftDown.Y; y -= D)
                {
                    _spherePoints.Add(new PointG(new Vector2d(x, y), 0,indexI,indexJ));
                    indexJ++;
                }
                indexI++;
            }
            ClippingPoints(R, D);
            //SetHeightPoints(R, D);  //задаём высоту для точек

        }
    }

}
