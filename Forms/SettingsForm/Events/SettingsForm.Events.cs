using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShrineForm
{
    public partial class SettingsForm : MetroSet_UI.Forms.MetroSetForm
    {
        /* Form Interaction Events */
        private void Save_Click(object sender, EventArgs e)
        {
            // Commit form changes to settings object
            UpdateSettings();

            // Make sure project name/paths are valid and then save YML
            if (!IsValid())
            {
                MessageBox.Show(this, "Project Name can't be empty,\n" +
                    "and must only include alphanumeric characters!",
                    "Warning: Invalid Project Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                Program.settings.ProjectName = "";
            }
            else
            {
                SaveSettings();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public void Path_Click(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Title = "Choose Folder...";
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtBox.Text = dialog.FileName;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
