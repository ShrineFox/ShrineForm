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
using MetroSet_UI.Controls;

namespace ShrineForm
{
    public partial class ShrineForm_Form : MetroSet_UI.Forms.MetroSetForm
    {
        private void NewProject_Click(object sender, EventArgs e)
        {
            if (settings.Data != null)
                if (!Forms.YesNoMsgBox("Exit Current Project?",
                "Are you sure you want to close the current project and start a new one?"))
                    return;
            OpenSettingsForm(true);
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            OpenSettingsForm();
        }

        private bool OpenSettingsForm(bool newSettings = false)
        {
            // Back up current settings
            var oldSettings = new Settings() { Data = settings.Data, FormSettings = settings.FormSettings, YmlPath = settings.YmlPath };
            // Nullify current settings if newSettings is true
            if (newSettings)
                settings.Data = null;
            // Open Settings Form
            using (var dialog = settings.Form())
            {
                Output.VerboseLog("Opening Settings Form");
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    settings.Save(Path.Combine(projectPath, $"{settings.GetValue("ProjectName")}.yml"));
                    // TODO: Prompt to move files to new destination if newSettings is false and project dir changed

                    // Reload form if settings have changed
                    if (oldSettings.Data != settings.Data || oldSettings.YmlPath != settings.YmlPath)
                        LoadProject();
                }
                else
                {
                    // Revert settings if form closed without saving
                    Output.VerboseLog("Closing Settings Form Without Saving");
                    settings = oldSettings;
                    return false;
                }
            }

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
            // Load settings from .yml file
            settings.Load(ymlFile);

            UpdateMainFormOptions();

            // Remove existing form controls
            foreach (MetroSetTabControl tabCtrl in this.GetAllControls<MetroSetTabControl>())
                tabCtrl.Parent.Controls.Remove(tabCtrl);

            // Get settings
            string inputFolderPath = settings.GetValue("InputFolderPath");
            string projectFolderPath = settings.GetValue("ProjectFolderPath");
            // File Explorer Tabs with Treeviews
            var browserTabControl = FormControls.SFTabControl("metroSetTabControl_FileBrowser");
            var inputFilesTabPage = FormControls.SFTabPage("inputFilesTabPage", "Files");
            var inputFilesTreeView = FormControls.SFTreeView("inputFilesTreeView", 0);
            if (Directory.Exists(inputFolderPath))
                TreeViewBuilder.BuildTree(new DirectoryInfo(inputFolderPath), inputFilesTreeView.Nodes);
            inputFilesTabPage.Controls.Add(inputFilesTreeView);
            browserTabControl.TabPages.Add(inputFilesTabPage);

            var projectFilesTabPage = FormControls.SFTabPage("projectFilesTabPage", "Project");
            var projectFilesTreeView = FormControls.SFTreeView("projectFilesTreeView", 0);
            if (Directory.Exists(projectFolderPath))
                TreeViewBuilder.BuildTree(new DirectoryInfo(projectFolderPath), projectFilesTreeView.Nodes);
            projectFilesTabPage.Controls.Add(projectFilesTreeView);
            browserTabControl.TabPages.Add(projectFilesTabPage);

            tableLayoutPanel_Main.Controls.Add(browserTabControl, 0, 0);

            // Main Work Area Tabs with Panels

        }

        public void UpdateMainFormOptions()
        {
            // Add current project name to Title Bar
            if (settings.Data != null)
                this.Text = $"{Exe.Name()} - {settings.GetValue("ProjectName")}";
            else
                this.Text = $"{Exe.Name()} ";

            // Enable or disable Settings option
            if (!string.IsNullOrEmpty(settings.YmlPath))
                settingsToolStripMenuItem.Enabled = true;
            else
                settingsToolStripMenuItem.Enabled = true;
        }
    }
}
