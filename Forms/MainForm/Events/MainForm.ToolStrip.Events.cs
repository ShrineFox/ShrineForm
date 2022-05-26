using Microsoft.WindowsAPICodePack.Dialogs;
using ShrineFox.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ShrineForm
{
    public partial class ShrineForm_Form : MetroSet_UI.Forms.MetroSetForm
    {
        private void NewProject_Click(object sender, EventArgs e)
        {
            if (Forms.YesNoMsgBox("Exit Current Project?", 
                "Are you sure you want to close the current project and start a new one?"))
                NewProject();
        }

        private void NewProject()
        {
            this.Text = $"{Exe.Name()} ";
            settings = new Settings();
            tableLayoutPanel_Main.Controls.Clear();
            OpenSettingsForm();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            OpenSettingsForm();
        }

        private bool OpenSettingsForm()
        {
            using (var dialog = settings.Form())
            {
                Output.VerboseLog("Opening Settings Form");
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    Output.VerboseLog("Closing Settings Form Without Saving");
                    return false;
                } 
            }
            Output.VerboseLog("Saving Settings and Loading Project");
            LoadProject();
            return true;
        }

        private void LoadProject_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Filters.Add(new CommonFileDialogFilter($"{Exe.Name()} Project", "*.yml"));
            dialog.Title = "Open Project File...";
            // Start in Projects folder
            string initialDir = Path.Combine(Exe.Directory(), "Projects");
            Directory.CreateDirectory(initialDir);
            dialog.InitialDirectory = initialDir;
            // Load Settings if YML file chosen
            var deserializer = new DeserializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build();
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                LoadProject(dialog.FileName);
            //metroSetTabControl_FileExplorer.SelectedIndex = 1;
        }

        /// <summary>
        /// Load Files/Project treeviews and update title after validating settings.
        /// </summary>
        private void LoadProject(string ymlFile = "")
        {
            if (ymlFile == "" )
            // Load settings from .yml file
            settings.Load(ymlFile);

            // Add current project name to Title Bar
            this.Text = $"{Exe.Name()} - {settings.GetValue("ProjectName")}";

            string inputFolderPath = settings.GetValue("InputFolderPath");
            string projectFolderPath = settings.GetValue("ProjectFolderPath");
            // File Explorer Tabs with Treeviews
            var browserTabControl = FormControls.SFTabControl("metroSetTabControl_FileBrowser");
            var inputFilesTabPage = FormControls.SFTabPage("inputFilesTabPage", "Files");
            var inputFilesTreeView = FormControls.SFTreeView("inputFilesTreeView", 0);
            if (Directory.Exists(Path.GetDirectoryName(inputFolderPath)))
                TreeViewBuilder.BuildTree(new DirectoryInfo(Path.GetDirectoryName(inputFolderPath)), inputFilesTreeView.Nodes);
            inputFilesTabPage.Controls.Add(inputFilesTreeView);
            browserTabControl.TabPages.Add(inputFilesTabPage);

            var projectFilesTabPage = FormControls.SFTabPage("projectFilesTabPage", "Project");
            var projectFilesTreeView = FormControls.SFTreeView("projectFilesTreeView", 0);
            if (Directory.Exists(Path.GetDirectoryName(projectFolderPath)))
                TreeViewBuilder.BuildTree(new DirectoryInfo(Path.GetDirectoryName(projectFolderPath)), projectFilesTreeView.Nodes);
            projectFilesTabPage.Controls.Add(projectFilesTreeView);
            browserTabControl.TabPages.Add(projectFilesTabPage);

            tableLayoutPanel_Main.Controls.Add(browserTabControl, 0, 0);

            // Main Work Area Tabs with Panels

        }

        private void SaveProjectAs_Click(object sender, EventArgs e)
        {
            
        }
    }
}
