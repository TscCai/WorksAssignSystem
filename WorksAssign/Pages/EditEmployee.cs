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
    public partial class EditEmployee : AddEmployee
    {
        Employee employee;
        public EditEmployee() {
            InitializeComponent();
        }
        public EditEmployee(Employee e) : base() {
            InitializeComponent();
            employee = e;
            txt_Name.Text = e.Name;
            cb_Sex.Text = e.Sex;
            cb_Sex.SelectedItem = e.Sex;
            dpk_JoinDate.Value = e.JoinDate;
            chk_IsCCP.Checked = e.IsCCP;

        }

  
        protected override void Btn_OK_Click(object sender, EventArgs e) {
            using (var db = new DbAgent()) {
                Employee emp = db.GetEmployee(employee.Id);
                emp.Name = txt_Name.Text;
                emp.Sex = cb_Sex.SelectedItem.ToString();
                emp.JoinDate = dpk_JoinDate.Value.Date;
                emp.IsCCP = chk_IsCCP.Checked;
                db.UpdateEmployee();

            }
            this.ShowSuccessDialog("修改成功");
            this.Close();

        }

    }
}
