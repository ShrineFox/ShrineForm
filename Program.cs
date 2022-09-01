using ShrineFox.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShrineForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SFForm("ShrineForm", "FormSettings\\MainForm.json", "Saved\\MainUserData.json"));
        }

        public static void ScriptTest()
        {
            MessageBox.Show("Test");
        }
    }
}
