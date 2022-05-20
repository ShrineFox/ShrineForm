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
        // Configure form elements
        private void SetupFormControls()
        {
            // Create Click Events
            var TreeNode_MouseClick = new TreeNodeMouseClickEventHandler(TreeNode_Click);
            var TreeNode_DoubleClick = new TreeNodeMouseClickEventHandler(TreeNode_DblClick);
            var MenuItem_MouseClick = new EventHandler(MenuItem_Click);

            // Create Context Menus
            var contextMenuStrip_Files = FormControls.SFContextMenuStrip("contextMenuStrip_Files");
            var toolStripMenuItem_Add = FormControls.SFToolStripMenuItem("toolStripMenuItem_Add", "Add", MenuItem_MouseClick);
            var toolStripMenuItem_OpenAt = FormControls.SFToolStripMenuItem("toolStripMenuItem_OpenAt", "OpenAt", MenuItem_MouseClick);
            var toolStripMenuItem_Expand = FormControls.SFToolStripMenuItem("toolStripMenuItem_Expand", "Expand", MenuItem_MouseClick);
            var toolStripMenuItem_Collapse = FormControls.SFToolStripMenuItem("toolStripMenuItem_Collapse", "Collapse", MenuItem_MouseClick);
            contextMenuStrip_Files.Items.AddRange(new ToolStripMenuItem[] {
                toolStripMenuItem_Add, toolStripMenuItem_OpenAt, toolStripMenuItem_Expand, toolStripMenuItem_Collapse });
            var contextMenuStrip_Project = FormControls.SFContextMenuStrip("contextMenuStrip_Project");
            contextMenuStrip_Project.Items.AddRange(new ToolStripMenuItem[] {
                toolStripMenuItem_Add, toolStripMenuItem_OpenAt, toolStripMenuItem_Expand, toolStripMenuItem_Collapse });

            // Create 2 Tabs containing Treeviews
            var treeView_FileExplorer = FormControls.SFTreeView("treeView_FileExplorer", 0, TreeNode_MouseClick, TreeNode_DoubleClick);
            var treeView_ProjectExplorer = FormControls.SFTreeView("treeView_ProjectExplorer", 1, TreeNode_MouseClick, TreeNode_DoubleClick);
            var tabPage_Files = FormControls.SFTabPage("tabPage_Files", "Files", 0);
            var tabPage_Project = FormControls.SFTabPage("tabPage_Project", "Project", 1);
            tabPage_Files.Controls.Add(treeView_FileExplorer);
            tabPage_Project.Controls.Add(treeView_ProjectExplorer);
            // Create Tab Control for Sidebar
            var metroSetTabControl_FileExplorer = FormControls.SFTabControl("metroSetTabControl_FileExplorer", 2);
            metroSetTabControl_FileExplorer.Controls.Add(tabPage_Files);
            metroSetTabControl_FileExplorer.Controls.Add(tabPage_Project);
            tableLayoutPanel_Main.Controls.Add(metroSetTabControl_FileExplorer, 0, 0);

            // Create 2 Tabs containing Panels
            var panel_CMD = FormControls.SFPanel("panel_CMD", 2);
            var panel_Txt = FormControls.SFPanel("panel_Txt", 3);
            var tabPage_CMD = FormControls.SFTabPage("tabPage_CMD", "Command Prompt", 0);
            var tabPage_Txt = FormControls.SFTabPage("tabPage_Txt", "Text Editor", 1);
            tabPage_CMD.Controls.Add(panel_CMD);
            tabPage_Txt.Controls.Add(panel_Txt);
            // Create Tab Control for Workspace
            var metroSetTabControl_Workspace = FormControls.SFTabControl("metroSetTabControl_Workspace", 1);
            metroSetTabControl_Workspace.Controls.Add(tabPage_CMD);
            metroSetTabControl_Workspace.Controls.Add(tabPage_Txt);
            tableLayoutPanel_Workspace.Controls.Add(metroSetTabControl_Workspace, 0, 0);
        }
    }
}
