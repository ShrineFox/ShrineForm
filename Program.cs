using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShrineForm
{
    public class Settings
    {
        public string ProjectName { get; set; } = "";
        public string InputFolderPath { get; set; } = "";
        public string ProjectFolderPath { get; set; } = "";
        public string YMLPath()
        {
            return Path.Combine(Path.Combine("Projects", this.ProjectName), this.ProjectName + ".yml");
        }
    }

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
            Application.Run(new ShrineForm_Form());
        }

        public static Settings settings { get; set; } = new Settings();
    }
}
