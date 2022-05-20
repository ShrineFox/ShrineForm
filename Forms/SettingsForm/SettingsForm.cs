using Microsoft.WindowsAPICodePack.Dialogs;
using ShrineFox.IO;
using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ShrineForm
{
    public partial class SettingsForm : MetroSet_UI.Forms.MetroSetForm
    {
        public SettingsForm()
        {
            InitializeComponent();

            SetupSettingsForm();

            if (File.Exists(Program.settings.YMLPath()))
                LoadSettings();
        }

        // Create rows/controls for each property of Settings object
        private void SetupSettingsForm()
        {
            int i = 0;
            foreach (PropertyInfo propertyInfo in Program.settings.GetType().GetProperties())
            {
                // If setting is a string...
                if (propertyInfo.PropertyType.Equals(typeof(string)))
                {
                    // Create new row
                    tableLayoutPanel_SettingsContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
                    // Create new label and add to first column of row
                    tableLayoutPanel_SettingsContent.Controls.Add(new Label() { Text = propertyInfo.Name, 
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 10F), 
                        AutoSize = true }, 0, i);
                    // Create new textbox
                    TextBox txtBox = new TextBox() { Tag = propertyInfo.Name, Width = 300,
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 10F),
                        BackColor = System.Drawing.Color.FromArgb(20,20,20), 
                        ForeColor = System.Drawing.Color.White };
                    // Make readonly and add click event to browse for file if name contains "path"
                    if (propertyInfo.Name.ToLower().Contains("path"))
                    {
                        txtBox.ReadOnly = true;
                        txtBox.Click += Path_Click;
                    }
                    // Add textbox to second column of row
                    tableLayoutPanel_SettingsContent.Controls.Add(txtBox, 1, i);
                    i++;
                }
            }
        }

        // Update Settings object with current values of each form control
        private void UpdateSettings()
        {
            foreach (Control ctrl in tableLayoutPanel_SettingsContent.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    var property = Program.settings.GetType().GetProperty(ctrl.Tag.ToString());
                    property.SetValue(Program.settings, ctrl.Text, null);
                }
            }
        }
        
        // Update form controls with current values of Settings object
        private void UpdateForm()
        {
            foreach (PropertyInfo propertyInfo in Program.settings.GetType().GetProperties())
            {
                foreach (Control ctrl in tableLayoutPanel_SettingsContent.Controls)
                {
                    if (ctrl.Tag != null && 
                        propertyInfo.PropertyType.Equals(typeof(string)) && ctrl.Tag.Equals(propertyInfo.Name))
                    {
                        ctrl.Text = propertyInfo.GetValue(Program.settings).ToString();
                    }
                }
            }
        }

        public static void SaveSettings()
        {
            var serializer = new SerializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build();
            string yamlPath = Program.settings.YMLPath();
            var yaml = serializer.Serialize(Program.settings);
            using (FileSys.WaitForFile(yamlPath)) { };
            File.WriteAllText(yamlPath, yaml);

            MessageBox.Show(new SettingsForm(), $"Saved project \"{Program.settings.ProjectName}\" to \"{yamlPath}\"", "Project Saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadSettings()
        {
            var deserializer = new DeserializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build();
            Program.settings = deserializer.Deserialize<Settings>(File.ReadAllText(Program.settings.YMLPath()));

            UpdateForm();
        }

        public static bool IsValid()
        {
            if (string.IsNullOrEmpty(Program.settings.ProjectName) || 
                !Regex.IsMatch(Program.settings.ProjectName, "^[a-zA-Z0-9-_ .]*$"))
            {
                Output.Log($"[ERROR] Failed to load project: invalid Project Name \"{Program.settings.ProjectName}\"", ConsoleColor.Red);
                return false;
            }
            if (!Directory.Exists(Program.settings.InputFolderPath))
            {
                Output.Log($"[ERROR] Failed to load project: invalid Input Folder Path \"{Program.settings.InputFolderPath}\"", ConsoleColor.Red);
                return false;
            }
            if (!Directory.Exists(Program.settings.ProjectFolderPath))
            {
                Output.Log($"[ERROR] Failed to load project: invalid Project Path \"{Program.settings.ProjectFolderPath}\"", ConsoleColor.Red);
                return false;
            }

            Output.Log($"[INFO] Successfully loaded project: \"{Program.settings.ProjectName}\"");
            return true;
        }
    }
}
