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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartFPY = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.fpyLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.failLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.chartFPY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // chartFPY
            // 
            chartArea2.Name = "ChartArea1";
            this.chartFPY.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartFPY.Legends.Add(legend2);
            this.chartFPY.Location = new System.Drawing.Point(145, 12);
            this.chartFPY.Name = "chartFPY";
            this.chartFPY.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartFPY.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Green,
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))};
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "s1";
            this.chartFPY.Series.Add(series2);
            this.chartFPY.Size = new System.Drawing.Size(297, 295);
            this.chartFPY.TabIndex = 1;
            this.chartFPY.Text = "chartFPY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "FPY";
            // 
            // fpyLabel
            // 
            this.fpyLabel.AutoSize = true;
            this.fpyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fpyLabel.Location = new System.Drawing.Point(12, 49);
            this.fpyLabel.Name = "fpyLabel";
            this.fpyLabel.Size = new System.Drawing.Size(71, 22);
            this.fpyLabel.TabIndex = 3;
            this.fpyLabel.Text = "99.99%";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passLabel.Location = new System.Drawing.Point(12, 94);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(115, 17);
            this.passLabel.TabIndex = 4;
            this.passLabel.Text = "Pass Units: 1000";
            // 
            // failLabel
            // 
            this.failLabel.AutoSize = true;
            this.failLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.failLabel.Location = new System.Drawing.Point(12, 148);
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
            // medium
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(454, 289);
            this.Controls.Add(this.failLabel);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.fpyLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartFPY);
            this.Name = "medium";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.chartFPY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartFPY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fpyLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label failLabel;
        private System.Windows.Forms.Timer timer;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}