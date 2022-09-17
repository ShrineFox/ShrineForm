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
        public static bool notSaved = false;

        public static void NewProject_Click()
        {
            NewProject();
        }

        public static void LoadProject_Click()
        {
            SelectProject();
        }

        public static void EditProject_Click()
        {
            EditProject();
        }
    }
}