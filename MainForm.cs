using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
//using System.Numerics;
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
        public static void DrawDiagram(DiagramPoints dg, int R,double d,double kWave, 
            ref GLControl glC)
        {
            dg.SetHeightPoints(R, d);
            dg.GetIntensityPoints(dg._sources, kWave, 1);
            double Max = dg._spherePoints.Max().Height;
            dg._spherePoints.ForEach(p =>
            {
                p.Height = p.Height * (double)R / Max;
            });
            glC.Select();

            Vector3 Eye = new Vector3((float)dg._spherePoints.Max().GridPosition.X + 300,
                (float)dg._spherePoints.Max().GridPosition.Y + 300,
                (float)dg._spherePoints.Max().Height + 300);

            var modelView = Matrix4.LookAt(Eye, new Vector3(0,0,0), new Vector3(0, 2, 0));
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelView);
            GL.Rotate(-90, 1, 0, 0);
            GL.Rotate(-90, 0, 0, 1);
        }

        private void MainWindowLoad(object sender, EventArgs e)
        {
            InitInputParameters();
            dg = new DiagramPoints(R, d);
            vF = new FormVisualizationSource(d, kWave, R, ref dg, ref glControl_Diagram);
            vF.Show();
        }

        private void button_Restart_Click(object sender, EventArgs e)
        {
            vF.Close();
            InitInputParameters();
            dg = new DiagramPoints(R, d);
            vF = new FormVisualizationSource(d, kWave, R, ref dg, ref glControl_Diagram);
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

            //GL.Enable(EnableCap.DepthTest);

            //var p = Matrix4.CreatePerspectiveFieldOfView((float)(80 * Math.PI / 180), 1, 200, 50000);
            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadMatrix(ref p);

            //Eye = new Vector3((float)dg._spherePoints.Max().GridPosition.X+1000, 
            //    (float)dg._spherePoints.Max().GridPosition.Y+1000,
            //    (float)dg._spherePoints.Max().Height+1000);

            //var modelView = Matrix4.LookAt(Eye, Targ, new Vector3(0, 2, 0));
            //GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadMatrix(ref modelView);
            //GL.Rotate(-90, 1, 0, 0);
            //GL.Rotate(-90, 0, 0, 1);

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
