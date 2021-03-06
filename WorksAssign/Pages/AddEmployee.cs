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

namespace WorksAssign.Pages
{
    public partial class AddEmployee : UIForm
    {
       
        public AddEmployee() {
            InitializeComponent();
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        protected virtual void Btn_OK_Click(object sender, EventArgs e) {
            using (var db = new DbAgent()) {
                Employee emp = new Employee();
                emp.Name = txt_Name.Text;
                emp.Sex = cb_Sex.SelectedItem.ToString();
                emp.JoinDate = dpk_JoinDate.Value.Date;
                emp.IsCCP = chk_IsCCP.Checked;
                db.AddEmployee(emp);
            }
            this.ShowSuccessDialog("新增成功");
            this.Close();

        }
    }
}
