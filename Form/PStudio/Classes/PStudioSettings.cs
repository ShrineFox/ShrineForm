using MetroSet_UI.Controls;
using Newtonsoft.Json;
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
        public static Settings settings = new Settings();

        public static void EditProject()
        {
            using (SFForm projectForm = new SFForm("New Project", "Form\\Project\\ProjectForm.json"))
            {
                // Apply current values of settings object to Project form
                LoadSettingsFormValues(projectForm);
                // Cancel changes if form not closed via OK Button
                if (projectForm.ShowDialog() != DialogResult.OK)
                    return;
                // Update settings values, save project file
                SaveProject(projectForm);
                // Apply changes to P-Studio form
                LoadProject(projectForm);
            }
           
        }

        private static void LoadSettingsFormValues(SFForm projectForm)
        {
            // Apply settings values to form
            foreach (var ctrl in WinForms.EnumerateControls(projectForm))
            {
                switch (ctrl.Name)
                {
                    case "txt_ProjectName":
                        ctrl.Text = settings.Title;
                        break;
                    case "txt_Authors":
                        ctrl.Text = settings.Authors;
                        break;
                    case "txt_Date":
                        ctrl.Text = settings.ReleaseDate;
                        break;
                    case "txt_Description":
                        ctrl.Text = settings.Description;
                        break;
                    case "comboBox_Game":
                        ComboBox game = (ComboBox)ctrl;
                        game.SelectedIndex = game.Items.IndexOf(settings.Game);
                        break;
                    case "txt_GameFolderPath":
                        ctrl.Text = settings.GamePath;
                        break;
                    case "txt_ProjectFolderPath":
                        ctrl.Text = settings.ProjectPath;
                        break;
                    case "txt_Version":
                        ctrl.Text = settings.Version;
                        break;
                    case "txt_ChangeLog":
                        ctrl.Text = settings.Changelog;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void SelectProject()
        {
            string projectFile = WinFormsEvents.FilePath_Click("Select Project",
                false, new string[] { "P-Studio Project (*.pst)" }).SingleOrDefault();

            if (File.Exists(projectFile))
                settings = JsonConvert.DeserializeObject<Settings>(projectFile);
        }

        private static void SaveProject(SFForm projectForm)
        {
            // Get settings values from form
            foreach (var ctrl in WinForms.EnumerateControls(projectForm))
            {
                switch (ctrl.Name)
                {
                    case "txt_ProjectName":
                        settings.Title = ctrl.Text;
                        break;
                    case "txt_Authors":
                        settings.Authors = ctrl.Text;
                        break;
                    case "txt_Date":
                        settings.ReleaseDate = ctrl.Text;
                        break;
                    case "txt_Description":
                        settings.Description = ctrl.Text;
                        break;
                    case "comboBox_Game":
                        settings.Game = ctrl.Text;
                        break;
                    case "txt_GameFolderPath":
                        settings.GamePath = ctrl.Text;
                        break;
                    case "txt_ProjectFolderPath":
                        settings.ProjectPath = ctrl.Text;
                        break;
                    case "txt_Version":
                        settings.Version = ctrl.Text;
                        break;
                    case "txt_ChangeLog":
                        settings.Changelog = ctrl.Text;
                        break;
                    default:
                        break;
                }
            }

            // Save settings object as JSON
            if (!string.IsNullOrEmpty(settings.ProjectPath))
            {
                if (!Directory.Exists(settings.ProjectPath))
                    Directory.CreateDirectory(settings.ProjectPath);

                string projectFile = Path.Combine(settings.ProjectPath, settings.Title + ".pst");
                File.WriteAllText(projectFile, JsonConvert.SerializeObject(settings));
                Output.Log($"Saved project: \"{projectFile}\"", ConsoleColor.Green);
            }
        }

        private static void CloseProject()
        {
            settings = new Settings();

            // Initialize Form Title and Log
            mainForm.Text = $"P-Studio v{version}";
            Output.Log("Project closed.");

            // Close all Workspace Tabs
            MetroSetTabControl workspace = (MetroSetTabControl)WinForms.GetControl(mainForm, "tabControl_Workspace");
            workspace.TabPages.Clear();

            // Initialize treeviews
            TreeView gameFiles = (TreeView)WinForms.GetControl(mainForm, "treeView_Game");
            TreeView projFiles = (TreeView)WinForms.GetControl(mainForm, "treeView_Project");
            gameFiles.Nodes.Clear();
            projFiles.Nodes.Clear();
        }

        private static void LoadProject(SFForm projectForm)
        {
            // Update Form Title and Log
            mainForm.Text = $"P-Studio v{version} - {settings.Title}";
            Output.Log($"Project loaded: \"{settings.Title}\"");

            // Update Project/Game Treeviews
        }

        private static void NewProject()
        {
            if (WinFormsmDialogs.YesNoMsgBox("Close Project?", "If you close this project, " +
                "all unsaved work will be lost. Are you sure you want to continue?"))
            {
                CloseProject();
                EditProject();
            }
        }
    }

    public class Settings
    {
        public string Game { get; set; } = "";
        public string ProjectPath { get; set; } = "";
        public string GamePath { get; set; } = "";
        public string ArchivePath { get; set; } = "";
        
        public string Title { get; set; } = "";
        public string Authors { get; set; } = "";
        public string ReleaseDate { get; set; } = "";
        public string Description { get; set; } = "";
        public string Version { get; set; } = "";
        public string Changelog { get; set; } = "";
        public string DownloadURL { get; set; } = "";
    }
}