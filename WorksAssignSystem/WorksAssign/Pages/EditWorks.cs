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
using WorksAssign.Persistence;
using WorksAssign.Persistence.Adapter;

namespace WorksAssign.Pages {
	public partial class EditWorks : UIForm {
		public EditWorks() {
			InitializeComponent();
		}

        public EditWorks(long workId):this() {
            UIMessageBox.ShowInfo("You pass the workId: " + workId);
        }

        private void btn_Cancel_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
