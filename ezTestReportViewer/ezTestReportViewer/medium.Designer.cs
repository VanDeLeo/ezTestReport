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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartFPY = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.fpyLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.failLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.version = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartFPY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartFPY
            // 
            chartArea3.Name = "ChartArea1";
            this.chartFPY.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartFPY.Legends.Add(legend3);
            this.chartFPY.Location = new System.Drawing.Point(130, 19);
            this.chartFPY.Name = "chartFPY";
            this.chartFPY.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartFPY.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Green,
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))};
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "s1";
            this.chartFPY.Series.Add(series3);
            this.chartFPY.Size = new System.Drawing.Size(294, 240);
            this.chartFPY.TabIndex = 1;
            this.chartFPY.Text = "chartFPY";
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
            this.groupBox1.Controls.Add(this.version);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chartFPY);
            this.groupBox1.Controls.Add(this.failLabel);
            this.groupBox1.Controls.Add(this.fpyLabel);
            this.groupBox1.Controls.Add(this.passLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 265);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.version.Location = new System.Drawing.Point(9, 246);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(37, 13);
            this.version.TabIndex = 6;
            this.version.Text = "v1.0.0";
            // 
            // medium
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(454, 289);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.MaximumSize = new System.Drawing.Size(470, 328);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(470, 328);
            this.Name = "medium";
            this.Text = "ezTestReportViewer";
            ((System.ComponentModel.ISupportInitialize)(this.chartFPY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}