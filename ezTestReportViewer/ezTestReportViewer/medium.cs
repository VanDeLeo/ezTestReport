using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ezTestReportViewer
{
    public partial class medium : Form
    {
        public medium(int passUnits, int failUnits, double fpyPercent)
        {
            InitializeComponent();

            double failPercent = (double)100 - fpyPercent;

            //chartFPY.Titles.Add("FPY");

            chartFPY.Series["s1"].Points.AddXY("PASS", fpyPercent.ToString("N2"));
            chartFPY.Series["s1"].Points.AddXY("FAIL", failPercent.ToString("N2"));
            //chartFPY.Series["s1"].Points.AddXY("1","70");
            //chartFPY.Series["s1"].Points.AddXY("2","30");
        }

        private void medium_Load(object sender, EventArgs e)
        {

        }

        private void chartFPY_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
