namespace BuildingDirectionalDiagram
{
    partial class FormVisualizationSource
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxSources = new System.Windows.Forms.PictureBox();
            this.buttonBuildDiagram = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSources)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxSources
            // 
            this.pictureBoxSources.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxSources.Name = "pictureBoxSources";
            this.pictureBoxSources.Size = new System.Drawing.Size(522, 522);
            this.pictureBoxSources.TabIndex = 0;
            this.pictureBoxSources.TabStop = false;
            this.pictureBoxSources.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            // 
            // buttonBuildDiagram
            // 
            this.buttonBuildDiagram.Location = new System.Drawing.Point(12, 540);
            this.buttonBuildDiagram.Name = "buttonBuildDiagram";
            this.buttonBuildDiagram.Size = new System.Drawing.Size(522, 48);
            this.buttonBuildDiagram.TabIndex = 1;
            this.buttonBuildDiagram.Text = "Построить диаграмму";
            this.buttonBuildDiagram.UseVisualStyleBackColor = true;
            this.buttonBuildDiagram.Click += new System.EventHandler(this.buttonBuildDiagram_Click);
            // 
            // FormVisualizationSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 593);
            this.Controls.Add(this.buttonBuildDiagram);
            this.Controls.Add(this.pictureBoxSources);
            this.Name = "FormVisualizationSource";
            this.Text = "Выбор источников";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSources)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSources;
        private System.Windows.Forms.Button buttonBuildDiagram;
    }
}