using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace BuildingDirectionalDiagram
{
    public partial class MainForm : Form
    {
        bool loaded = false;
        Vector3 Eye, Targ;
        private double Kd, lambda, kWave, d;
        public int R;
        FormVisualizationSource vF;
        public DiagramPoints dg;

        public MainForm()
        {
            InitializeComponent();
        }

        public void InitInputParameters()
        {
            lambda = Convert.ToDouble(numericUpDown_Lambda.Value);
            Kd = Convert.ToDouble(numericUpDown_Kd.Value);
            kWave = 2 * Math.PI / lambda;
            R = Convert.ToInt32(numericUpDown_RBig.Value);
            d = Kd * lambda;
        }

        private void glcontrol_Load(object sender, EventArgs e)
        {
            loaded = true;

            Eye = new Vector3(5000, 5000, 5000);
            Targ = new Vector3(0, 0, 0);

            GL.ClearColor(Color.SkyBlue);
            GL.Enable(EnableCap.DepthTest);

            var p = Matrix4.CreatePerspectiveFieldOfView((float)(80 * Math.PI / 180), 1, 200, 50000);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref p);

            var modelView = Matrix4.LookAt(Eye, Targ, new Vector3(0, 2, 0));
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelView);
            GL.Rotate(-90, 1, 0, 0);
            GL.Rotate(-90, 0, 0, 1);

        }
        public static void DrawDiagram(DiagramPoints dg, int R, double d, double kWave,
            ref GLControl glC, ref PictureBox pB)
        {
            int[][] m = new int[2 * R][];
            for (var i = 0; i < 2 * R; i++)
            {
                m[i] = new int[2 * R];
            }

            dg.SetHeightPoints(R, d);
            dg.GetIntensityPoints(dg._sources, kWave, 1);
            double Max = dg._spherePoints.Max().Height;
            double Min = dg._spherePoints.Min().Height;
            dg._spherePoints.ForEach(p =>
            {
                m[p.indexI][p.indexJ] = (int)((p.Height / Max) * 255);
                p.Height = p.Height * (double)R / Max;
            });
            FillImage(m, pB);
            glC.Select();

            Vector3 Eye = new Vector3((float)dg._spherePoints.Max().GridPosition.X + 300,
                (float)dg._spherePoints.Max().GridPosition.Y + 300,
                (float)dg._spherePoints.Max().Height + 300);

            var modelView = Matrix4.LookAt(Eye, new Vector3(0, 0, 0), new Vector3(0, 2, 0));
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelView);
            GL.Rotate(-90, 1, 0, 0);
            GL.Rotate(-90, 0, 0, 1);
        }

        public static void FillImage(int[][] pixels, PictureBox pB)
        {
            pB.Image = new Bitmap(pixels.Length, pixels[0].Length);
            for (int i = 0; i < pixels.Length; i++)
            {
                for (int j = 0; j < pixels[i].Length; j++)
                {
                    ((Bitmap)pB.Image).
                        SetPixel(i, j, Color.FromArgb(pixels[i][j], pixels[i][j], pixels[i][j]));

                }
            }
            pB.Refresh();
        }

        private void MainWindowLoad(object sender, EventArgs e)
        {
            InitInputParameters();
            dg = new DiagramPoints(R, d);
            pictureBox_DiagramImage.Height = 400; pictureBox_DiagramImage.Width = 400;
            vF = new FormVisualizationSource(d, kWave, R, ref dg, ref glControl_Diagram, ref pictureBox_DiagramImage);
            vF.Show();
        }


        private void button_Restart_Click(object sender, EventArgs e)
        {
            vF.Close();
            InitInputParameters();
            dg = new DiagramPoints(R, d);
            vF = new FormVisualizationSource(d, kWave, R, ref dg, ref glControl_Diagram, ref pictureBox_DiagramImage);
            vF.Show();
        }

        public void DrawPointsSphere()
        {
            dg._spherePoints.ForEach(point =>
            {
                GL.Color3(Color.Black);
                GL.Begin(BeginMode.Points);
                GL.Vertex3(point.GridPosition.X, point.GridPosition.Y, point.Height);
                GL.End();
            });

        }
        public Tuple<int,int,int> HSVToRGB(float h,float s,float v)
        {
            if (s == 0f) return new Tuple<int, int, int>((int)v, (int)v, (int)v);
            int i = (int)(h * 6f);
            float f = (h * 6f) - i;
            float p = v * (1f - s);
            float q = v * (1f - s * f);
            float t = v * (1f - s * (1f - f));
            i = i % 6;
            switch (i)
            {
                case 0: return new Tuple<int, int, int>((int)v, (int)t, (int)p);
                    break;
                case 1: return new Tuple<int, int, int>((int)q, (int)v, (int)p);
                    break;
                case 2: return new Tuple<int, int, int>((int)p, (int)v, (int)t);
                    break;
                case 3: return new Tuple<int, int, int>((int)p, (int)q, (int)v);
                    break;
                case 4: return new Tuple<int, int, int>((int)t, (int)p, (int)v);
                    break;
                case 5: return new Tuple<int, int, int>((int)v, (int)p, (int)q);
            }
            return null;
        }

        public void glControl_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded) return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            DrawPointsSphere();

            GL.Color3(Color.Green);     //X - green
            GL.Begin(BeginMode.Lines);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(100, 0, 0);
            GL.End();

            GL.Color3(Color.Red);       //Y - red
            GL.Begin(BeginMode.Lines);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 100, 0);
            GL.End();

            GL.Color3(Color.Blue);      //Z - blue
            GL.Begin(BeginMode.Lines);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 100);
            GL.End();

            GL.Color3(Color.White);
            GL.Begin(BeginMode.Polygon);
            GL.Vertex3(-2000, -2000, 0);
            GL.Vertex3(-2000, 2000, 0);
            GL.Vertex3(2000, 2000, 0);
            GL.Vertex3(2000, -2000, 0);
            GL.End();

            glControl_Diagram.SwapBuffers();
        }

        private void On_KeyDown(object sender, KeyEventArgs e)
        {
            if (!loaded) return;

            if (e.KeyCode == Keys.W)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Rotate(1, 1, 0, 0);
            }
            if (e.KeyCode == Keys.S)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Rotate(1, -1, 0, 0);
            }

            if (e.KeyCode == Keys.Y)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Rotate(1, 0, 1, 0);
            }

            if (e.KeyCode == Keys.D)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Rotate(1, 0, 0, 1);
            }

            if (e.KeyCode == Keys.A)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Rotate(1, 0, 0, -1);
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Scale(1.01, 1.01, 1.01);
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                GL.MatrixMode(MatrixMode.Modelview);
                GL.Scale(0.99, 0.99, 0.99);
            }

            glControl_Diagram.Invalidate();
        }
    }
}
