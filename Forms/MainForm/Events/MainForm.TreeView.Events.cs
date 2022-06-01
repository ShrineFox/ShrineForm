using ShrineFox.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ShrineForm
{
    public partial class ShrineForm_Form : MetroSet_UI.Forms.MetroSetForm
    {
        private void SetupTreeViews()
        {
            foreach (Control ctrl in tableLayoutPanel_Main.Controls)
            {
                if (ctrl.GetType() == typeof(TabControl))
                {
                    var tabCtrl = (TabControl)ctrl;
                    foreach (TabPage tabPage in tabCtrl.TabPages)
                    {
                        if (ctrl.Name.ToLower().Contains("project"))
                        {
                            // Build Project Directory Treeview
                            var treeView_Project = new TreeView();
                            var projectExpansionState = treeView_Project.Nodes.GetExpansionState();

                            treeView_Project.Nodes.Clear();
                            if (Directory.Exists(Path.GetDirectoryName(settings.Data["ProjectFolderPath"].Value<string>())))
                                TreeViewBuilder.BuildTree(new DirectoryInfo(Path.GetDirectoryName(settings.Data["ProjectFolderPath"].Value<string>())), treeView_Project.Nodes);

                            treeView_Project.Nodes.SetExpansionState(projectExpansionState);
                        }
                        else if (ctrl.Name.ToLower().Contains("inputFiles"))
                        {
                            // Build File Directory Treeview
                            var treeView_Files = new TreeView();
                            var filesExpansionState = treeView_Files.Nodes.GetExpansionState();

                            treeView_Files.Nodes.Clear();
                            if (Directory.Exists(Path.GetDirectoryName(settings.Data["InputFolderPath"].Value<string>())))
                                TreeViewBuilder.BuildTree(new DirectoryInfo(Path.GetDirectoryName(settings.Data["InputFolderPath"].Value<string>())), treeView_Files.Nodes);
                            treeView_Files.Nodes.SetExpansionState(filesExpansionState);
                        }
                    }
                }
            }
        }

        /* Treeview Events */
        private void TreeNode_Click(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Open right click treeview node context menu
            if (e.Button == MouseButtons.Right)
            {
                var treeNode = (TreeNode)sender;
                treeNode.TreeView.SelectedNode = e.Node;
                ContextMenuStrip rightClickMenu = FormControls.SFContextMenuStrip(treeNode);
                rightClickMenu.Show(Cursor.Position);
            }
        }

        private void TreeNode_DblClick(object sender, EventArgs e)
        {

        }

        /* Context Menu Events */
        private void MenuItem_Click(object sender, EventArgs e)
        {

        }

        /* Open/close right click treeview node context menus */
        private void FileNode_MouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {


        }

        /* Toggle sidebar and output log */
        private void ShowHide_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel_Main.ColumnStyles[0].SizeType == SizeType.Percent)
            {
                tableLayoutPanel_Main.ColumnStyles[0].SizeType = SizeType.AutoSize;
                tableLayoutPanel_Main.HideColumns(new int[] { 0 });
                tableLayoutPanel_Workspace.HideRows(new int[] { 1 });
                metroSetButton_ToggleSidebar.Text = "»";
            }
            else
            {
                tableLayoutPanel_Main.ShowColumns(new int[] { 0 });
                tableLayoutPanel_Workspace.ShowRows(new int[] { 1 });
                tableLayoutPanel_Main.ColumnStyles[0].SizeType = SizeType.Percent;
                tableLayoutPanel_Main.ColumnStyles[0].Width = 28f;
                metroSetButton_ToggleSidebar.Text = "«";
            }
        }
        private void HideContextMenus()
        {
            //contextMenuStrip_Project.Hide();
            //contextMenuStrip_Game.Hide();
        }
    }
}
