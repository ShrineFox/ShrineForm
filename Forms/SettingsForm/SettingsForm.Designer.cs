
namespace ShrineForm
{
    partial class SettingsForm : MetroSet_UI.Forms.MetroSetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tableLayoutPanel_Settings = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_SettingsButtons = new System.Windows.Forms.TableLayoutPanel();
            this.metroSetButton_Cancel = new MetroSet_UI.Controls.MetroSetButton();
            this.metroSetButton_Save = new MetroSet_UI.Controls.MetroSetButton();
            this.panel_SettingsScroller = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_SettingsContent = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_Settings.SuspendLayout();
            this.tableLayoutPanel_SettingsButtons.SuspendLayout();
            this.panel_SettingsScroller.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Settings
            // 
            this.tableLayoutPanel_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tableLayoutPanel_Settings.ColumnCount = 1;
            this.tableLayoutPanel_Settings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Settings.Controls.Add(this.tableLayoutPanel_SettingsButtons, 0, 1);
            this.tableLayoutPanel_Settings.Controls.Add(this.panel_SettingsScroller, 0, 0);
            this.tableLayoutPanel_Settings.Location = new System.Drawing.Point(13, 14);
            this.tableLayoutPanel_Settings.Name = "tableLayoutPanel_Settings";
            this.tableLayoutPanel_Settings.RowCount = 2;
            this.tableLayoutPanel_Settings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Settings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_Settings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Settings.Size = new System.Drawing.Size(586, 412);
            this.tableLayoutPanel_Settings.TabIndex = 28;
            // 
            // tableLayoutPanel_SettingsButtons
            // 
            this.tableLayoutPanel_SettingsButtons.ColumnCount = 3;
            this.tableLayoutPanel_SettingsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel_SettingsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_SettingsButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_SettingsButtons.Controls.Add(this.metroSetButton_Cancel, 1, 0);
            this.tableLayoutPanel_SettingsButtons.Controls.Add(this.metroSetButton_Save, 2, 0);
            this.tableLayoutPanel_SettingsButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_SettingsButtons.Location = new System.Drawing.Point(3, 375);
            this.tableLayoutPanel_SettingsButtons.Name = "tableLayoutPanel_SettingsButtons";
            this.tableLayoutPanel_SettingsButtons.RowCount = 1;
            this.tableLayoutPanel_SettingsButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_SettingsButtons.Size = new System.Drawing.Size(580, 34);
            this.tableLayoutPanel_SettingsButtons.TabIndex = 34;
            // 
            // metroSetButton_Cancel
            // 
            this.metroSetButton_Cancel.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton_Cancel.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton_Cancel.DisabledForeColor = System.Drawing.Color.Gray;
            this.metroSetButton_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroSetButton_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetButton_Cancel.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton_Cancel.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton_Cancel.HoverTextColor = System.Drawing.Color.White;
            this.metroSetButton_Cancel.IsDerivedStyle = true;
            this.metroSetButton_Cancel.Location = new System.Drawing.Point(351, 3);
            this.metroSetButton_Cancel.Name = "metroSetButton_Cancel";
            this.metroSetButton_Cancel.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton_Cancel.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton_Cancel.NormalTextColor = System.Drawing.Color.White;
            this.metroSetButton_Cancel.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton_Cancel.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton_Cancel.PressTextColor = System.Drawing.Color.White;
            this.metroSetButton_Cancel.Size = new System.Drawing.Size(110, 28);
            this.metroSetButton_Cancel.Style = MetroSet_UI.Enums.Style.Dark;
            this.metroSetButton_Cancel.StyleManager = null;
            this.metroSetButton_Cancel.TabIndex = 0;
            this.metroSetButton_Cancel.Text = "Cancel";
            this.metroSetButton_Cancel.ThemeAuthor = "Narwin";
            this.metroSetButton_Cancel.ThemeName = "MetroDark";
            this.metroSetButton_Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // metroSetButton_Save
            // 
            this.metroSetButton_Save.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton_Save.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton_Save.DisabledForeColor = System.Drawing.Color.Gray;
            this.metroSetButton_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroSetButton_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetButton_Save.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton_Save.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton_Save.HoverTextColor = System.Drawing.Color.White;
            this.metroSetButton_Save.IsDerivedStyle = true;
            this.metroSetButton_Save.Location = new System.Drawing.Point(467, 3);
            this.metroSetButton_Save.Name = "metroSetButton_Save";
            this.metroSetButton_Save.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton_Save.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton_Save.NormalTextColor = System.Drawing.Color.White;
            this.metroSetButton_Save.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton_Save.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton_Save.PressTextColor = System.Drawing.Color.White;
            this.metroSetButton_Save.Size = new System.Drawing.Size(110, 28);
            this.metroSetButton_Save.Style = MetroSet_UI.Enums.Style.Dark;
            this.metroSetButton_Save.StyleManager = null;
            this.metroSetButton_Save.TabIndex = 1;
            this.metroSetButton_Save.Text = "Save";
            this.metroSetButton_Save.ThemeAuthor = "Narwin";
            this.metroSetButton_Save.ThemeName = "MetroDark";
            this.metroSetButton_Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // panel_SettingsScroller
            // 
            this.panel_SettingsScroller.Controls.Add(this.tableLayoutPanel_SettingsContent);
            this.panel_SettingsScroller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_SettingsScroller.Location = new System.Drawing.Point(3, 3);
            this.panel_SettingsScroller.Name = "panel_SettingsScroller";
            this.panel_SettingsScroller.Size = new System.Drawing.Size(580, 366);
            this.panel_SettingsScroller.TabIndex = 35;
            // 
            // tableLayoutPanel_SettingsContent
            // 
            this.tableLayoutPanel_SettingsContent.AutoScroll = true;
            this.tableLayoutPanel_SettingsContent.ColumnCount = 2;
            this.tableLayoutPanel_SettingsContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel_SettingsContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel_SettingsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_SettingsContent.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_SettingsContent.Name = "tableLayoutPanel_SettingsContent";
            this.tableLayoutPanel_SettingsContent.RowCount = 1;
            this.tableLayoutPanel_SettingsContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_SettingsContent.Size = new System.Drawing.Size(580, 366);
            this.tableLayoutPanel_SettingsContent.TabIndex = 36;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BorderThickness = 0F;
            this.ClientSize = new System.Drawing.Size(612, 443);
            this.Controls.Add(this.tableLayoutPanel_Settings);
            this.DropShadowEffect = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.HeaderHeight = -40;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.ShowHeader = true;
            this.ShowLeftRect = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Style = MetroSet_UI.Enums.Style.Dark;
            this.Text = "Settings";
            this.ThemeName = "MetroDark";
            this.tableLayoutPanel_Settings.ResumeLayout(false);
            this.tableLayoutPanel_SettingsButtons.ResumeLayout(false);
            this.panel_SettingsScroller.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Settings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_SettingsButtons;
        private MetroSet_UI.Controls.MetroSetButton metroSetButton_Cancel;
        private MetroSet_UI.Controls.MetroSetButton metroSetButton_Save;
        private System.Windows.Forms.Panel panel_SettingsScroller;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_SettingsContent;
    }
}