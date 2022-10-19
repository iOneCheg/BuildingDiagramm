using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingDirectionalDiagram
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonSelectSource_Click(object sender, EventArgs e)
        {
            var SelectedForm = new FormVisualizationSource();
            SelectedForm.Show();
        }
    }
}
