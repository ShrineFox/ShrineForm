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
            SyncUIHelper.Initialize();
            Application.Run(mainForm);
        }

        private static SFForm mainForm = new SFForm("ShrineForm", "FormSettings\\MainForm.json", "Saved\\MainUserData.json");

        public static void ScriptTest()
        {
            Control ctrl = WinForms.GetControl(mainForm, "panel_Inner_4");
            ctrl.SyncUI(() => { ctrl.BackColor = System.Drawing.Color.Red; ctrl.Text = "Set background to red!"; }, true);
        }
    }
}
