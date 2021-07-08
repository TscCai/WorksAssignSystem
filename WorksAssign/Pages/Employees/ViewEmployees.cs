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

namespace WorksAssign.Pages
{
    public partial class ViewEmployees : SimpleGridPage
    {
        public ViewEmployees() {
            InitializeComponent();
        }

        protected override void AppendControl() {

         //   this.pnl_Header.FlowDirection = FlowDirection.LeftToRight;
            this.col_IsCCP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_JoinDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            // 
            // col_IsCCP
            // 
            this.col_IsCCP.DataPropertyName = "IsCCp";
            this.col_IsCCP.HeaderText = "是否党员";
            this.col_IsCCP.Name = "col_IsCCP";
            this.col_IsCCP.ReadOnly = true;
            // 
            // col_JoinDate
            // 
            this.col_JoinDate.DataPropertyName = "JoinDate";
            this.col_JoinDate.HeaderText = "参工日期";
            this.col_JoinDate.Name = "col_JoinDate";
            this.col_JoinDate.ReadOnly = true;
            // 
            // col_Sex
            // 
            this.col_Sex.DataPropertyName = "Sex";
            this.col_Sex.HeaderText = "性别";
            this.col_Sex.Name = "col_Sex";
            this.col_Sex.ReadOnly = true;
            // 
            // col_Name
            // 
            this.col_Name.DataPropertyName = "Name";
            this.col_Name.HeaderText = "姓名";
            this.col_Name.Name = "col_Name";
            this.col_Name.ReadOnly = true;
            // 
            // col_Chk
            // 
            this.col_Chk.HeaderText = "选择";
            this.col_Chk.Name = "col_Chk";
            this.col_Chk.Resizable = DataGridViewTriState.True;
            this.col_Chk.SortMode = DataGridViewColumnSortMode.Automatic;

            this.dg_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_Data.Columns.AddRange(new DataGridViewColumn[] {
            this.col_Chk,this.col_Name,col_Sex,col_JoinDate,col_IsCCP});

            this.col_Chk.ReadOnly = false;
            pgr_Data.PageChanged += Pgr_Data_PageChanged;
            AddButtons();
        }

        private void Pgr_Data_PageChanged(object sender, object pagingSource, int pageIndex, int count) {
            dg_Data.DataSource = pagingSource;
        }

        protected override void InitializeData() {
            base.InitializeData();
            using (db = new WasDbAgent()) {
                var data = db.GetEmployee(false).ToList();
                pgr_Data.DataSource = data;
                pgr_Data.TotalCount = data.Count;
                pgr_Data.ActivePage = 1;

            }
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
            var items = GetChosenItems<Employee>();
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
            var items = GetChosenItems<Employee>();
            if (items.Count > 0) {
                if (items.Count > 1) {
                    this.ShowErrorDialog("仅能对选中的第一条记录进行编辑");
                }
                var i = items.First();
                EditEmployee frm_EditEmployee = new EditEmployee(i);
                frm_EditEmployee.ShowDialog();

                InitializeData();

                pgr_Data.ActivePage = 0;
                pgr_Data.ActivePage = 1;
            }

        }

        private void Btn_Add_Click(object sender, EventArgs e) {

            AddEmployee frm_AddEmployee = new AddEmployee();
            frm_AddEmployee.ShowDialog();

            InitializeData();
            pgr_Data.ActivePage = 0;
            pgr_Data.ActivePage = 1;
        }

        private void ViewEmployees_Initialize(object sender, EventArgs e) {
            if (!IsInited) {
                InitializeData();
                IsInited = true;
            }
        }
    }
}
