using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorksAssign;
using Sunny.UI;

namespace WorksAssign.Pages
{
    public partial class About : UIPage
    {
        public About() {
            InitializeComponent();
#if PRO
            lbl_AboutMsg.Text = AssemblyGetter.AssemblyTitle + " " + AssemblyGetter.AssemblyVersion + " Pro\n";
#else
            lbl_AboutMsg.Text = AssemblyGetter.AssemblyTitle+" "+ AssemblyGetter.AssemblyVersion +"\n";
#endif
            lbl_AboutMsg.Text += "Build at: " + System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location) + "\n";
            lbl_AboutMsg.Text += "Developed by: " + AssemblyGetter.AssemblyCompany + "\n";
            lbl_AboutMsg.Text += AssemblyGetter.AssemblyCopyright;
        }

    }
}
