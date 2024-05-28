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

        [STAThread]

        private protected static void Main(string[] args)
        {
            filePath = args[0];

            string appVersion = "v1.1.5";

            if (File.Exists(filePath))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new medium(filePath, appVersion));

            }

        }
        
    }
}

/*goin' hard*/