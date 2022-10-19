using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BuildingDirectionalDiagram
{
    public partial class FormVisualizationSource : Form
    {
        List<Square> squares = new List<Square>();
        private int counter;
        Graphics graph;
        public FormVisualizationSource()
        {
            InitializeComponent();
            InitVisualization();
            SetSquares();
        }

        /// <summary>
        /// Отрисоквка сетки 10х10
        /// </summary>
        public void InitVisualization()
        {
            pictureBoxSources.Image = new Bitmap(pictureBoxSources.Width, pictureBoxSources.Height);
            graph = Graphics.FromImage(pictureBoxSources.Image);
            //Перенос начала координат в центр pictureBox
            graph.TranslateTransform(pictureBoxSources.Width / 2, pictureBoxSources.Height / 2);
            // Изменение направления Oy 
            graph.ScaleTransform(1, -1);

            float thickness = 2.0f; //Толщина линий
            int widthImage = pictureBoxSources.Width;
            int heightImage = pictureBoxSources.Height;

            //Ширина одного квадрата
            int widthSource = (pictureBoxSources.Width - (int)thickness * 11) / 10;
            //Высота одного квадрата
            int heightSource = (pictureBoxSources.Height - (int)thickness * 11) / 10;

            Pen pen = new Pen(Color.Red);
            
            graph.FillEllipse(Brushes.Red, -5, -5, 10, 10);
            pen = new Pen(Color.Black, thickness);
            //Отрисовка вертикальных линий
            for (int x = -widthImage / 2 + 1; x < widthImage / 2; x += (widthSource + (int)thickness))
            {
                graph.DrawLine(pen, x, heightImage / 2, x, -heightImage / 2);
            }
            //Отрисовка горизонтальных линий
            for (int y = heightImage / 2 - 1; y > -heightImage / 2; y -= (heightSource + (int)thickness))
            {
                graph.DrawLine(pen, -widthImage / 2, y, widthImage / 2, y);
            }

            //graph.Dispose();

        }
        public void SetSquares()
        {
            float thickness = 2.0f; //Толщина линий
            int widthImage = pictureBoxSources.Width;
            int heightImage = pictureBoxSources.Height;

            //Ширина одного квадрата
            int widthSource = (pictureBoxSources.Width - (int)thickness * 11) / 10;
            //Высота одного квадрата
            int heightSource = (pictureBoxSources.Height - (int)thickness * 11) / 10;

            for (int x = 2; x < widthImage; x += (widthSource + (int)thickness))
            {
                for (int y = 2; y < heightImage; y += (heightSource + (int)thickness))
                {
                    squares.Add(new Square(x, y, widthSource, heightSource));
                }

            }
            counter = 0;
        }
        public void SetSquareSource(Square sq)
        {
            //pictureBoxSources.Image = new Bitmap(pictureBoxSources.Width, pictureBoxSources.Height);
            graph = Graphics.FromImage(pictureBoxSources.Image);

            //Pen pen = new Pen(Color.Aqua);
            graph.FillRectangle(Brushes.Blue, (int)sq.X, (int)sq.Y, sq.Width, sq.Height);
            //graph.DrawRectangle(pen, (int)sq.X, (int)sq.Y, sq.Width, sq.Height);
            //graph.Dispose();
            pictureBoxSources.Refresh();
        }
        public void SetSources(Point p, Square sq)
        {
            if (Square.PointInSquare(p, sq))
            {
                SetSquareSource(sq);
                counter++;
            }
        }

        private void OnClick(object sender, MouseEventArgs e)
        {
            squares.ForEach(sq => SetSources(new Point(e.X, e.Y), sq));
        }

        private void buttonBuildDiagram_Click(object sender, System.EventArgs e)
        {
            counter = 0;
        }
    }
}
