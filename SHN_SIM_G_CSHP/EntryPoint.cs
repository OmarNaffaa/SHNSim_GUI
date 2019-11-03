using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHNSim_GUI
{
    public partial class EntryPoint
    {
        /// <summary>
        /// The main entry PointF for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            setupGUI GUI = new setupGUI();
            Application.Run(GUI);

        }


    }
    
}
