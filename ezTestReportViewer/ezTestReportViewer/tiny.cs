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
    public partial class tiny : Form
    {
        public tiny(double percentValue)
        {

            InitializeComponent();
            labelPercent.Text = percentValue.ToString("N2");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void labelPercent_Click(object sender, EventArgs e)
        {

        }
    }
}
