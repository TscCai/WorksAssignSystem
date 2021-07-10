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
using WorksAssign.Persistence;

namespace WorksAssign.Pages.Devices
{
    public partial class ViewDevice : SimpleGridPage
    {
        public ViewDevice() {
            InitializeComponent();
           
        }

       

        private void btn_Search_Click(object sender, EventArgs e) {
            using (var db = new DeviceDbAgent()) {
                var data = db.GetAllDeviceView().ToList();
                pgr_Data.DataSource = data;
                pgr_Data.TotalCount = data.Count();
                pgr_Data.ActivePage = 1;
            }
        }
    }
}
