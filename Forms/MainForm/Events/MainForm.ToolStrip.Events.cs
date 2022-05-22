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
            // Clear Title Bar
            this.Text = $"{AssemblyName.GetAssemblyName(Assembly.GetExecutingAssembly().Location).Name} ";
            // Disable Save As... option
            saveProjectToolStripMenuItem.Enabled = false;
            // Initialize settings
            settings = new Settings();
            OpenSettingsForm();
            //metroSetTabControl_FileExplorer.SelectedIndex = 0;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            OpenSettingsForm();
        }

        private void OpenSettingsForm()
        {
            using (var dialog = new SettingsForm())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;
            }
            LoadProject();
        }

        private void LoadProject_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Filters.Add(new CommonFileDialogFilter("P-Studio Project", "*.yml"));
            dialog.Title = "Open Project File...";
            // Start in Projects folder
            string initialDir = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Projects");
            Directory.CreateDirectory(initialDir);
            dialog.InitialDirectory = initialDir;
            // Load Settings if YML file chosen
            var deserializer = new DeserializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build();
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                settings = deserializer.Deserialize<Settings>(File.ReadAllText(dialog.FileName));
                LoadProject();
            }
            //metroSetTabControl_FileExplorer.SelectedIndex = 1;
        }

        /// <summary>
        /// Load Files/Project treeviews and update title after validating settings.
        /// </summary>
        private void LoadProject()
        {
            if (SettingsForm.IsValid())
            {
                // Add current project name to Title Bar
                this.Text = $"{Exe.Name()} - {settings.GetValue("ProjectName")}";

                // Set up form controls
                SetupFormControls();

                // Enable Save option
                saveProjectToolStripMenuItem.Enabled = true;
            }
        }

        private void SetupFormControls()
        {
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
            if (SettingsForm.IsValid())
            {
                string originalProj = settings.YmlPath;
                string projDir = Path.GetDirectoryName(originalProj);
                RenameForm rename = new RenameForm(Path.GetFileName(projDir));
                var result = rename.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string newProjName = rename.RenameText;
                    string newProjDir = Path.Combine(Path.GetDirectoryName(projDir), newProjName);
                    if (!Directory.Exists(Path.GetDirectoryName(newProjDir)))
                    {
                        settings.SetValue("ProjectName", newProjName);
                        Output.Log($"[INFO] Copying project files from \"{Path.GetFileNameWithoutExtension(originalProj)}\" to \"{Path.GetFileNameWithoutExtension(newProjDir)}\"");
                        // Copy all project files to new directory
                        FileSys.CopyDir(projDir, newProjDir);
                        // Delete original project file copied with other project stuff
                        File.Delete(Path.Combine(newProjDir, Path.GetFileName(originalProj)));
                        // Save and reload new project
                       // SettingsForm.SaveSettings();
                        LoadProject();
                    }
                    else
                        Output.Log($"[ERROR] Failed to save project as \"{newProjName}\", directory already exists");
                }
            }
        }
    }
}
