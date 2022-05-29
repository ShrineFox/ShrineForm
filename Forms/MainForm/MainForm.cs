using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using ShrineFox.IO;
using System.Collections.Generic;
using MetroSet_UI.Controls;

namespace ShrineForm
{
    public partial class ShrineForm_Form : MetroSet_UI.Forms.MetroSetForm
    {
        public static Settings settings = new Settings();
        public static string projectPath = Path.Combine(Exe.Directory(), "Projects");

        public ShrineForm_Form()
        {
            InitializeComponent();
            this.Text = $"{Exe.Name()} ";

            Forms.SetDefaultIcon();
            SetTreeviewImages();
            SetupLogging();

            SetupToolstripRenderer();
            settings.Initialize("SettingsForm");
        }

        private void SetTreeviewImages()
        {
            string iconPath = Path.Combine(Path.Combine(Exe.Directory(), "FormSettings"), "Icons");
            TreeViewBuilder.SetIcon(Path.Combine(iconPath, "page_white.png"), ".file");
            TreeViewBuilder.SetIcon(Path.Combine(iconPath, "folder.png"), ".folder");
        }

        private void SetupToolstripRenderer()
        {
            ToolStripManager.Renderer = Extensions.renderer;
            menuStrip_Main.Renderer = Extensions.renderer;
        }

        /// Configure output logging
        private void SetupLogging()
        {
            Output.LogPath = "log.txt";
            Output.LogControl = richTextBox_OutputLog;
            #if DEBUG
                Output.VerboseLogging = true;
            #endif

            Output.VerboseLog("Program started.", ConsoleColor.Gray);
            Output.Log("Create a new project or load an existing one to get started.", ConsoleColor.Green);
            Output.Log("Log test.");
        }

        // Resize windows mounted to control when form is resized
        private void MainForm_Resize(object sender, EventArgs e)
        {
            //int formWidth = panel_Asset.Width;
            //int formHeight = panel_Asset.Height;
        }
    }
}
