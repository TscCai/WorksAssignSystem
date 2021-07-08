using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using WorksAssign.Pages.MasterPage;

namespace WorksAssign.Pages.Devices
{
    public partial class ViewDevice : SimpleGridPage
    {
        public ViewDevice() {
            InitializeComponent();



            // 
            // uiSymbolButton1
            // 
            pnl_Header.FlowDirection = FlowDirection.LeftToRight;
       
            this.pnl_Header.AddControl(this.uiSymbolButton1);
        }
    }
}
