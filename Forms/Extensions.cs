using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShrineForm
{
    public class Extensions
    {
        // Improve menustrip rendering for dark theme
        public static ToolStripProfessionalRenderer renderer =
            new ToolStripProfessionalRenderer(new MyColorTable(Color.FromArgb(255, 20, 20, 20)));
        public class MyColorTable : ProfessionalColorTable
        {
            private Color menuItemSelectedColor;
            public MyColorTable(Color color) : base()
            {
                menuItemSelectedColor = color;
            }
            public override Color MenuItemSelected
            {
                get { return menuItemSelectedColor; }
            }
        }
    }

    // Toggle TableLayoutPanel rows/columns that are set to autosize
    public static class TableLayoutPanelExtensions
    {
        public static void HideRows(this TableLayoutPanel panel, params int[] rowNumbers)
        {
            foreach (Control c in panel.Controls)
                if (rowNumbers.Contains(panel.GetRow(c)))
                    c.Visible = false;
        }
        public static void ShowRows(this TableLayoutPanel panel, params int[] rowNumbers)
        {
            foreach (Control c in panel.Controls)
                if (rowNumbers.Contains(panel.GetRow(c)))
                    c.Visible = true;
        }
        public static void HideColumns(this TableLayoutPanel panel, params int[] colNumbers)
        {
            foreach (Control c in panel.Controls)
                if (colNumbers.Contains(panel.GetColumn(c)))
                    c.Visible = false;
        }
        public static void ShowColumns(this TableLayoutPanel panel, params int[] colNumbers)
        {
            foreach (Control c in panel.Controls)
                if (colNumbers.Contains(panel.GetColumn(c)))
                    c.Visible = true;
        }
    }
}
