using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ezTestReportViewer
{
    public class Window
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            string windowType = args[0];
            int unitsProcessed = Int32.Parse(args[1]);
            int passUnits = Int32.Parse(args[2]);
            int failUnits = Int32.Parse(args[3]);

            double fpyPercent = ((double)passUnits * 100) / (double)unitsProcessed;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (windowType == "tiny")
            {
                Application.Run(new tiny(fpyPercent));
            } else if (windowType == "medium")
            {
                Application.Run(new medium(passUnits,failUnits,fpyPercent));
            } else if (windowType == "large")
            {
                Application.Run(new large());
            }
            
        }
    }
}
