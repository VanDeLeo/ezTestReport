/* made by leo

Title: EzTestReportViewer
Autor: leonardo.avalos.montes@continental-corporation.com
Position: Test Maintenance Technician
Location: Continental Periferico - Guadalajara
Date: 18/03/2024

*/

using System;
using System.IO;
using System.Windows.Forms;

namespace ezTestReportViewer
{

    public class Window
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        private static string filePath;
        private static string windowType;

        [STAThread]

        private protected static void Main(string[] args)
        {
            windowType = args[0];
            filePath = args[1];

            string appVersion = "v1.0.7";

            if (File.Exists(filePath))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (windowType == "tiny")
                {
                    
                    Application.Run(new tiny(filePath, appVersion));
                }
                else if (windowType == "medium")
                {
                    Application.Run(new medium(filePath, appVersion));
                }
                else if (windowType == "large")
                {
                    Application.Run(new large());
                }
            }

        }
        
    }
}

/*goin' hard*/