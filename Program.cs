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

        public static void SetColor(string ctrlName, string colorValue, string txt)
        {
            Control ctrl = WinForms.GetControl(mainForm, ctrlName);
            ctrl.SyncUI(() => { ctrl.BackColor = System.Drawing.ColorTranslator.FromHtml(colorValue); ctrl.Text = txt; }, true);
        }

        public static void SaveFormText()
        {
            mainForm.SaveData();
        }
    }
}
