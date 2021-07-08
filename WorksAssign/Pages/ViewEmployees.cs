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
    public partial class ViewEmployees : UIPage
    {
        WasDbAgent db;
        bool IsInited = false;
        public ViewEmployees() {
            InitializeComponent();
            AddButtons();


        }

        void InitializeData() {
            dg_Employee.AutoGenerateColumns = false;
            using (db = new WasDbAgent()) {
                var data = db.GetEmployee(false).ToList();
                pgr_Employee.DataSource = data;
                pgr_Employee.TotalCount = data.Count;
                pgr_Employee.ActivePage = 1;
            }
        }
        private void pgr_Employee_PageChanged(object sender, object pagingSource, int pageIndex, int count) {
            dg_Employee.DataSource = pagingSource;
        }

        List<Employee> GetChosenItems() {
            List<Employee> result = new List<Employee>();
            DataGridViewRowCollection dt = dg_Employee.Rows;

            foreach (DataGridViewRow i in dt) {
                if (i.Cells[0].Value != null && (bool)i.Cells[0].Value) {
                    result.Add(((Employee)i.DataBoundItem));
                }
            }
            return result;
        }

        void AddButtons() {
            UISymbolButton btn_Add = new UISymbolButton();
            UISymbolButton btn_Edit = new UISymbolButton();
            UISymbolButton btn_Del = new UISymbolButton();

            btn_Add.Margin = new Padding(10, 10, 10, 5);
            btn_Edit.Margin = new Padding(10, 10, 10, 5);
            btn_Del.Margin = new Padding(10, 10, 10, 5);

            btn_Add.Text = "添加";
            btn_Edit.Text = "编辑";
            btn_Del.Text = "删除";


            btn_Add.Click += Btn_Add_Click;
            btn_Edit.Click += Btn_Edit_Click;
            btn_Del.Click += Btn_Del_Click;

            pnl_Header.AddControl(btn_Del);
            pnl_Header.AddControl(btn_Edit);
            pnl_Header.AddControl(btn_Add);




        }

        private void Btn_Del_Click(object sender, EventArgs e) {
            var items = GetChosenItems();
            if (items.Count > 0 && this.ShowAskDialog("删除操作将级联删除该成员所参与的所有工作，要继续吗？")) {
                using (db = new WasDbAgent()) {
                    foreach (var i in items) {
                        db.DelEmployee(i.Id);
                    }
                }

                this.ShowSuccessDialog("删除成功。");
                InitializeData();
            }

        }

        private void Btn_Edit_Click(object sender, EventArgs e) {
            var items = GetChosenItems();
            if (items.Count > 1) {
                this.ShowErrorDialog("仅能对选中的第一条记录进行编辑");
            }
            var i = items.First();
            EditEmployee frm_EditEmployee = new EditEmployee(i);
            frm_EditEmployee.ShowDialog();

            InitializeData();

            pgr_Employee.ActivePage = 0;
            pgr_Employee.ActivePage = 1;
        }

        private void Btn_Add_Click(object sender, EventArgs e) {

            AddEmployee frm_AddEmployee = new AddEmployee();
            frm_AddEmployee.ShowDialog();

            InitializeData();
            pgr_Employee.ActivePage = 0;
            pgr_Employee.ActivePage = 1;
        }

        private void Employee_Initialize(object sender, EventArgs e) {
            if (!IsInited) {
                InitializeData();
                IsInited = true;
            }
        }



    }


}
