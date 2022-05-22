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
            
            // Create form elements based on loaded settings
            ShrineForm_Form.settings.CreateFormControls(this);
            // Load settings from settings.yml
            ShrineForm_Form.settings.Load();
            // Update form with values loaded from settings.yml
            ShrineForm_Form.settings.UpdateForm(this);
        }

        public static bool IsValid()
        {
            string stringToCheck = ShrineForm_Form.settings.GetValue("ProjectName");
            if (string.IsNullOrEmpty(stringToCheck) || 
                !Regex.IsMatch(stringToCheck, "^[a-zA-Z0-9-_ .]*$"))
            {
                Output.Log($"[ERROR] Failed to load project: invalid Project Name \"{stringToCheck}\"", ConsoleColor.Red);
                return false;
            }
            stringToCheck = ShrineForm_Form.settings.GetValue("InputFolderPath");
            if (!Directory.Exists(stringToCheck))
            {
                Output.Log($"[ERROR] Failed to load project: invalid Input Folder Path \"{stringToCheck}\"", ConsoleColor.Red);
                return false;
            }
            stringToCheck = ShrineForm_Form.settings.GetValue("ProjectFolderPath");
            if (!Directory.Exists(stringToCheck))
            {
                Output.Log($"[ERROR] Failed to load project: invalid Project Path \"{stringToCheck}\"", ConsoleColor.Red);
                return false;
            }

            Output.Log($"[INFO] Successfully loaded project: \"{stringToCheck}\"");
            return true;
        }
    }
}
