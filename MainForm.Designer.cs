namespace BuildingDirectionalDiagram
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.glControl_Diagram = new OpenTK.GLControl();
            this.groupBox_SystemParameters = new System.Windows.Forms.GroupBox();
            this.numericUpDown_RBig = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Kd = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Lambda = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Restart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox_SystemParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RBig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Kd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Lambda)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl_Diagram
            // 
            this.glControl_Diagram.BackColor = System.Drawing.Color.Black;
            this.glControl_Diagram.Location = new System.Drawing.Point(7, 22);
            this.glControl_Diagram.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glControl_Diagram.Name = "glControl_Diagram";
            this.glControl_Diagram.Size = new System.Drawing.Size(700, 700);
            this.glControl_Diagram.TabIndex = 1;
            this.glControl_Diagram.VSync = false;
            this.glControl_Diagram.Load += new System.EventHandler(this.glcontrol_Load);
            this.glControl_Diagram.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl_Diagram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.On_KeyDown);
            // 
            // groupBox_SystemParameters
            // 
            this.groupBox_SystemParameters.Controls.Add(this.numericUpDown_RBig);
            this.groupBox_SystemParameters.Controls.Add(this.numericUpDown_Kd);
            this.groupBox_SystemParameters.Controls.Add(this.numericUpDown_Lambda);
            this.groupBox_SystemParameters.Controls.Add(this.label4);
            this.groupBox_SystemParameters.Controls.Add(this.label3);
            this.groupBox_SystemParameters.Controls.Add(this.label1);
            this.groupBox_SystemParameters.Location = new System.Drawing.Point(733, 13);
            this.groupBox_SystemParameters.Name = "groupBox_SystemParameters";
            this.groupBox_SystemParameters.Size = new System.Drawing.Size(268, 108);
            this.groupBox_SystemParameters.TabIndex = 2;
            this.groupBox_SystemParameters.TabStop = false;
            this.groupBox_SystemParameters.Text = "Параметры системы";
            // 
            // numericUpDown_RBig
            // 
            this.numericUpDown_RBig.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_RBig.Location = new System.Drawing.Point(177, 77);
            this.numericUpDown_RBig.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_RBig.Name = "numericUpDown_RBig";
            this.numericUpDown_RBig.Size = new System.Drawing.Size(82, 22);
            this.numericUpDown_RBig.TabIndex = 7;
            this.numericUpDown_RBig.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // numericUpDown_Kd
            // 
            this.numericUpDown_Kd.DecimalPlaces = 1;
            this.numericUpDown_Kd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_Kd.Location = new System.Drawing.Point(177, 49);
            this.numericUpDown_Kd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Kd.Name = "numericUpDown_Kd";
            this.numericUpDown_Kd.Size = new System.Drawing.Size(82, 22);
            this.numericUpDown_Kd.TabIndex = 6;
            this.numericUpDown_Kd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_Lambda
            // 
            this.numericUpDown_Lambda.DecimalPlaces = 2;
            this.numericUpDown_Lambda.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_Lambda.Location = new System.Drawing.Point(177, 21);
            this.numericUpDown_Lambda.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Lambda.Name = "numericUpDown_Lambda";
            this.numericUpDown_Lambda.Size = new System.Drawing.Size(82, 22);
            this.numericUpDown_Lambda.TabIndex = 4;
            this.numericUpDown_Lambda.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Радиус полусферы (R):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Число k (для d):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Длина волны (lambda):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.glControl_Diagram);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 729);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Диаграмма направленностей в пространстве";
            // 
            // button_Restart
            // 
            this.button_Restart.Location = new System.Drawing.Point(733, 127);
            this.button_Restart.Name = "button_Restart";
            this.button_Restart.Size = new System.Drawing.Size(155, 45);
            this.button_Restart.TabIndex = 5;
            this.button_Restart.Text = "Начать заново";
            this.button_Restart.UseVisualStyleBackColor = true;
            this.button_Restart.Click += new System.EventHandler(this.button_Restart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(737, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 400);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 738);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_Restart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_SystemParameters);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Постсроение диаграммы направленностей";
            this.Load += new System.EventHandler(this.MainWindowLoad);
            this.groupBox_SystemParameters.ResumeLayout(false);
            this.groupBox_SystemParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RBig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Kd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Lambda)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private OpenTK.GLControl glControl_Diagram;
        private System.Windows.Forms.GroupBox groupBox_SystemParameters;
        private System.Windows.Forms.NumericUpDown numericUpDown_RBig;
        private System.Windows.Forms.NumericUpDown numericUpDown_Kd;
        private System.Windows.Forms.NumericUpDown numericUpDown_Lambda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Restart;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

