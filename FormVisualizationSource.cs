using OpenTK;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BuildingDirectionalDiagram
{
    public partial class FormVisualizationSource : Form
    {
        List<Square> squaresImage = new List<Square>();
        List<Square> squaresCalc = new List<Square>();

        public DiagramPoints diagLocal;

        public List<Source> sources = new List<Source>();
        private static double _d, _KWave;
        private static int _R;
        Graphics graph;
        GLControl _glC;
        PictureBox _pB;
        public FormVisualizationSource(double D, double kWave, int R, ref DiagramPoints dP,ref GLControl glCon,ref PictureBox pB)
        {
            _d = D; _KWave = kWave; _R = R; diagLocal = dP;_glC = glCon;_pB = pB;
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
            graph.FillRectangle(Brushes.White, 0, 0, pictureBoxSources.Width, pictureBoxSources.Height);
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


        }
        public void SetSquares()
        {
            float thickness = 2.0f; //Толщина линий

            //Ширина одного квадрата
            int widthSource = (pictureBoxSources.Width - (int)thickness * 11) / 10;
            //Высота одного квадрата
            int heightSource = (pictureBoxSources.Height - (int)thickness * 11) / 10;

            for (int x = 2; x < pictureBoxSources.Width; x += (widthSource) + (int)thickness)
            {
                for (int y = 2; y < pictureBoxSources.Height; y += (heightSource) + (int)thickness)
                {
                    squaresImage.Add(new Square(x, y, widthSource, heightSource));
                }
            }

            for (int x = 0; x < 500; x += (widthSource))
            {
                for (int y = 0; y < 500; y += (heightSource))
                {
                    squaresCalc.Add(new Square(x, y, widthSource, heightSource));
                }
            }
        }
        public void SetSquareSource(Square sq, int i)
        {
            graph = Graphics.FromImage(pictureBoxSources.Image);

            double koeff = (5 * _d) / 250d;
            sq.IsSetted = true;
            graph.FillRectangle(Brushes.Blue, (int)sq.X, (int)sq.Y, sq.Width, sq.Height);
            graph.FillEllipse(Brushes.Red, (int)sq.Center.X - 5, (int)sq.Center.Y - 5, 10, 10);

            sources.Add(new Source((-250 + squaresCalc[i].Center.X) * koeff, (250 - squaresCalc[i].Center.Y) * koeff));
            pictureBoxSources.Refresh();
        }
        public void DeleteSquareSource(Square sq,Square calcSq)
        {
            graph = Graphics.FromImage(pictureBoxSources.Image);

            graph.FillRectangle(Brushes.White, (int)sq.X, (int)sq.Y, sq.Width, sq.Height);
            sq.IsSetted = false;

            double koeff = (5d * _d) / 250d;

            Source deletedSource = new Source(0,0);
            sources.ForEach(s =>
            {
                deletedSource = new Source((-250d + calcSq.Center.X) * koeff, (250d - calcSq.Center.Y) * koeff);
                if (deletedSource.Equals(s)) 
                    deletedSource = new Source(s.X,s.Y);
            });
            sources.Remove(deletedSource);

            pictureBoxSources.Refresh();

        }


        private void OnClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < squaresImage.Count; i++)
            {
                if (Square.PointInSquare(new Point(e.X, e.Y), squaresImage[i])
                    && squaresImage[i].IsSetted == false)
                {
                    SetSquareSource(squaresImage[i], i);
                }
                else if (Square.PointInSquare(new Point(e.X, e.Y), squaresImage[i])
                    && squaresImage[i].IsSetted == true)
                {
                    DeleteSquareSource(squaresImage[i], squaresCalc[i]);
                }
            }
        }

        private void buttonBuildDiagram_Click(object sender, System.EventArgs e)
        {
            diagLocal._sources = sources;
            this.Enabled = false;
            MainForm.DrawDiagram(diagLocal, _R, _d, _KWave, ref _glC,ref _pB);
        }
    }
}
