namespace ezTestReportViewer
{
    partial class medium
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartFPY = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.fpyLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.failLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.s13 = new System.Windows.Forms.Button();
            this.s12 = new System.Windows.Forms.Button();
            this.s11 = new System.Windows.Forms.Button();
            this.s10 = new System.Windows.Forms.Button();
            this.s9 = new System.Windows.Forms.Button();
            this.s8 = new System.Windows.Forms.Button();
            this.s7 = new System.Windows.Forms.Button();
            this.s6 = new System.Windows.Forms.Button();
            this.s5 = new System.Windows.Forms.Button();
            this.s4 = new System.Windows.Forms.Button();
            this.s3 = new System.Windows.Forms.Button();
            this.s2 = new System.Windows.Forms.Button();
            this.s1 = new System.Windows.Forms.Button();
            this.cycleDuty = new System.Windows.Forms.Label();
            this.serialLabel = new System.Windows.Forms.Label();
            this.lastData = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Start = new System.Windows.Forms.TabPage();
            this.History = new System.Windows.Forms.TabPage();
            this.Fails = new System.Windows.Forms.TabPage();
            this.Variants = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.chartFPY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.Start.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartFPY
            // 
            this.chartFPY.BackColor = System.Drawing.Color.Transparent;
            this.chartFPY.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartFPY.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartFPY.Legends.Add(legend1);
            this.chartFPY.Location = new System.Drawing.Point(168, 18);
            this.chartFPY.Name = "chartFPY";
            this.chartFPY.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartFPY.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Green,
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))};
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "s1";
            this.chartFPY.Series.Add(series1);
            this.chartFPY.Size = new System.Drawing.Size(294, 240);
            this.chartFPY.TabIndex = 1;
            this.chartFPY.Text = "chartFPY";
            this.chartFPY.Click += new System.EventHandler(this.chartFPY_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Chivo Black Italic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "FPY";
            // 
            // fpyLabel
            // 
            this.fpyLabel.AutoSize = true;
            this.fpyLabel.Font = new System.Drawing.Font("Chivo Black Italic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fpyLabel.Location = new System.Drawing.Point(9, 60);
            this.fpyLabel.Name = "fpyLabel";
            this.fpyLabel.Size = new System.Drawing.Size(66, 20);
            this.fpyLabel.TabIndex = 3;
            this.fpyLabel.Text = "99.99%";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passLabel.Location = new System.Drawing.Point(9, 98);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(115, 17);
            this.passLabel.TabIndex = 4;
            this.passLabel.Text = "Pass Units: 1000";
            // 
            // failLabel
            // 
            this.failLabel.AutoSize = true;
            this.failLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.failLabel.Location = new System.Drawing.Point(10, 127);
            this.failLabel.Name = "failLabel";
            this.failLabel.Size = new System.Drawing.Size(106, 17);
            this.failLabel.TabIndex = 5;
            this.failLabel.Text = "Fail Units: 1000";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.s13);
            this.groupBox1.Controls.Add(this.s12);
            this.groupBox1.Controls.Add(this.s11);
            this.groupBox1.Controls.Add(this.s10);
            this.groupBox1.Controls.Add(this.s9);
            this.groupBox1.Controls.Add(this.s8);
            this.groupBox1.Controls.Add(this.s7);
            this.groupBox1.Controls.Add(this.s6);
            this.groupBox1.Controls.Add(this.s5);
            this.groupBox1.Controls.Add(this.s4);
            this.groupBox1.Controls.Add(this.s3);
            this.groupBox1.Controls.Add(this.s2);
            this.groupBox1.Controls.Add(this.s1);
            this.groupBox1.Controls.Add(this.cycleDuty);
            this.groupBox1.Controls.Add(this.serialLabel);
            this.groupBox1.Controls.Add(this.lastData);
            this.groupBox1.Controls.Add(this.version);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chartFPY);
            this.groupBox1.Controls.Add(this.failLabel);
            this.groupBox1.Controls.Add(this.fpyLabel);
            this.groupBox1.Controls.Add(this.passLabel);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 290);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // s13
            // 
            this.s13.BackColor = System.Drawing.SystemColors.ControlDark;
            this.s13.Enabled = false;
            this.s13.Location = new System.Drawing.Point(434, 261);
            this.s13.Name = "s13";
            this.s13.Size = new System.Drawing.Size(17, 23);
            this.s13.TabIndex = 22;
            this.s13.UseVisualStyleBackColor = false;
            // 
            // s12
            // 
            this.s12.BackColor = System.Drawing.SystemColors.ControlDark;
            this.s12.Enabled = false;
            this.s12.Location = new System.Drawing.Point(411, 261);
            this.s12.Name = "s12";
            this.s12.Size = new System.Drawing.Size(17, 23);
            this.s12.TabIndex = 21;
            this.s12.UseVisualStyleBackColor = false;
            // 
            // s11
            // 
            this.s11.BackColor = System.Drawing.SystemColors.ControlDark;
            this.s11.Enabled = false;
            this.s11.Location = new System.Drawing.Point(388, 261);
            this.s11.Name = "s11";
            this.s11.Size = new System.Drawing.Size(17, 23);
            this.s11.TabIndex = 20;
            this.s11.UseVisualStyleBackColor = false;
            // 
            // s10
            // 
            this.s10.BackColor = System.Drawing.SystemColors.ControlDark;
            this.s10.Enabled = false;
            this.s10.Location = new System.Drawing.Point(365, 261);
            this.s10.Name = "s10";
            this.s10.Size = new System.Drawing.Size(17, 23);
            this.s10.TabIndex = 19;
            this.s10.UseVisualStyleBackColor = false;
            // 
            // s9
            // 
            this.s9.BackColor = System.Drawing.SystemColors.ControlDark;
            this.s9.Enabled = false;
            this.s9.Location = new System.Drawing.Point(342, 261);
            this.s9.Name = "s9";
            this.s9.Size = new System.Drawing.Size(17, 23);
            this.s9.TabIndex = 18;
            this.s9.UseVisualStyleBackColor = false;
            // 
            // s8
            // 
            this.s8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.s8.Enabled = false;
            this.s8.Location = new System.Drawing.Point(319, 261);
            this.s8.Name = "s8";
            this.s8.Size = new System.Drawing.Size(17, 23);
            this.s8.TabIndex = 17;
            this.s8.UseVisualStyleBackColor = false;
            // 
            // s7
            // 
            this.s7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.s7.Enabled = false;
            this.s7.Location = new System.Drawing.Point(296, 261);
            this.s7.Name = "s7";
            this.s7.Size = new System.Drawing.Size(17, 23);
            this.s7.TabIndex = 16;
            this.s7.UseVisualStyleBackColor = false;
            // 
            // s6
            // 
            this.s6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.s6.Enabled = false;
            this.s6.Location = new System.Drawing.Point(273, 261);
            this.s6.Name = "s6";
            this.s6.Size = new System.Drawing.Size(17, 23);
            this.s6.TabIndex = 15;
            this.s6.UseVisualStyleBackColor = false;
            // 
            // s5
            // 
            this.s5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.s5.Enabled = false;
            this.s5.Location = new System.Drawing.Point(250, 261);
            this.s5.Name = "s5";
            this.s5.Size = new System.Drawing.Size(17, 23);
            this.s5.TabIndex = 14;
            this.s5.UseVisualStyleBackColor = false;
            // 
            // s4
            // 
            this.s4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.s4.Enabled = false;
            this.s4.Location = new System.Drawing.Point(227, 261);
            this.s4.Name = "s4";
            this.s4.Size = new System.Drawing.Size(17, 23);
            this.s4.TabIndex = 13;
            this.s4.UseVisualStyleBackColor = false;
            // 
            // s3
            // 
            this.s3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.s3.Enabled = false;
            this.s3.Location = new System.Drawing.Point(204, 261);
            this.s3.Name = "s3";
            this.s3.Size = new System.Drawing.Size(17, 23);
            this.s3.TabIndex = 12;
            this.s3.UseVisualStyleBackColor = false;
            // 
            // s2
            // 
            this.s2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.s2.Enabled = false;
            this.s2.Location = new System.Drawing.Point(181, 261);
            this.s2.Name = "s2";
            this.s2.Size = new System.Drawing.Size(17, 23);
            this.s2.TabIndex = 11;
            this.s2.UseVisualStyleBackColor = false;
            // 
            // s1
            // 
            this.s1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.s1.Enabled = false;
            this.s1.Location = new System.Drawing.Point(158, 261);
            this.s1.Name = "s1";
            this.s1.Size = new System.Drawing.Size(17, 23);
            this.s1.TabIndex = 10;
            this.s1.UseVisualStyleBackColor = false;
            // 
            // cycleDuty
            // 
            this.cycleDuty.AutoSize = true;
            this.cycleDuty.Location = new System.Drawing.Point(10, 203);
            this.cycleDuty.Name = "cycleDuty";
            this.cycleDuty.Size = new System.Drawing.Size(61, 13);
            this.cycleDuty.TabIndex = 9;
            this.cycleDuty.Text = "Cycle Duty;";
            // 
            // serialLabel
            // 
            this.serialLabel.AutoSize = true;
            this.serialLabel.Location = new System.Drawing.Point(10, 179);
            this.serialLabel.Name = "serialLabel";
            this.serialLabel.Size = new System.Drawing.Size(45, 13);
            this.serialLabel.TabIndex = 8;
            this.serialLabel.Text = "SERIAL";
            // 
            // lastData
            // 
            this.lastData.AutoSize = true;
            this.lastData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastData.Location = new System.Drawing.Point(10, 157);
            this.lastData.Name = "lastData";
            this.lastData.Size = new System.Drawing.Size(98, 17);
            this.lastData.TabIndex = 7;
            this.lastData.Text = "Last Unit Data";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.version.Location = new System.Drawing.Point(18, 261);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(37, 13);
            this.version.TabIndex = 6;
            this.version.Text = "v1.0.0";
            // 
            // tabControl
            // 
            this.tabControl.AllowDrop = true;
            this.tabControl.Controls.Add(this.Start);
            this.tabControl.Controls.Add(this.History);
            this.tabControl.Controls.Add(this.Fails);
            this.tabControl.Controls.Add(this.Variants);
            this.tabControl.Location = new System.Drawing.Point(0, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(509, 333);
            this.tabControl.TabIndex = 7;
            // 
            // Start
            // 
            this.Start.Controls.Add(this.groupBox1);
            this.Start.Location = new System.Drawing.Point(4, 22);
            this.Start.Name = "Start";
            this.Start.Padding = new System.Windows.Forms.Padding(3);
            this.Start.Size = new System.Drawing.Size(501, 307);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            // 
            // History
            // 
            this.History.Location = new System.Drawing.Point(4, 22);
            this.History.Name = "History";
            this.History.Padding = new System.Windows.Forms.Padding(3);
            this.History.Size = new System.Drawing.Size(501, 307);
            this.History.TabIndex = 1;
            this.History.Text = " ";
            this.History.UseVisualStyleBackColor = true;
            // 
            // Fails
            // 
            this.Fails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Fails.Location = new System.Drawing.Point(4, 22);
            this.Fails.Name = "Fails";
            this.Fails.Size = new System.Drawing.Size(501, 307);
            this.Fails.TabIndex = 2;
            this.Fails.Text = "Fails";
            this.Fails.UseVisualStyleBackColor = true;
            // 
            // Variants
            // 
            this.Variants.Location = new System.Drawing.Point(4, 22);
            this.Variants.Name = "Variants";
            this.Variants.Size = new System.Drawing.Size(501, 307);
            this.Variants.TabIndex = 3;
            this.Variants.Text = "Variants";
            this.Variants.UseVisualStyleBackColor = true;
            // 
            // medium
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(504, 331);
            this.Controls.Add(this.tabControl);
            this.HelpButton = true;
            this.MaximumSize = new System.Drawing.Size(520, 370);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(520, 370);
            this.Name = "medium";
            this.Text = "ezTestReport";
            ((System.ComponentModel.ISupportInitialize)(this.chartFPY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.Start.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartFPY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fpyLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label failLabel;
        private System.Windows.Forms.Timer timer;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label serialLabel;
        private System.Windows.Forms.Label lastData;
        private System.Windows.Forms.Button s4;
        private System.Windows.Forms.Button s3;
        private System.Windows.Forms.Button s2;
        private System.Windows.Forms.Button s1;
        private System.Windows.Forms.Label cycleDuty;
        private System.Windows.Forms.Button s13;
        private System.Windows.Forms.Button s12;
        private System.Windows.Forms.Button s11;
        private System.Windows.Forms.Button s10;
        private System.Windows.Forms.Button s9;
        private System.Windows.Forms.Button s8;
        private System.Windows.Forms.Button s7;
        private System.Windows.Forms.Button s6;
        private System.Windows.Forms.Button s5;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Start;
        private System.Windows.Forms.TabPage History;
        private System.Windows.Forms.TabPage Fails;
        private System.Windows.Forms.TabPage Variants;
    }
}