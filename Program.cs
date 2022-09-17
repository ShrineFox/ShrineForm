using ShrineFox.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShrineForm
{
    static partial class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            SyncUIHelper.Initialize();
            Application.Run(mainForm);
        }

        private static SFForm mainForm = new SFForm($"P-Studio v{version}", "Form\\PStudio\\PStudio.json");
        public static string version = "0.2";
    }
}
