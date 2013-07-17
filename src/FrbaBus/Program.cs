using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaBus
{
    static class Program
    {
        /// <summary>
        /// The main entry poInt32 for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Inicio());
        }
    }
}
