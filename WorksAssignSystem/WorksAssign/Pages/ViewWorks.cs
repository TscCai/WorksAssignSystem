using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sunny.UI;
using WorksAssign.Persistence;
using WorksAssign.Persistence.Adapter;
using WorksAssign.Util.Export;
using WorksAssign.Util.DataModel;

namespace WorksAssign.Pages
{
    public partial class ViewWorks : UIPage
    {
        List<DailyWorkModel> WorkList;

        public ViewWorks() {
            InitializeComponent();

            for (int i = 1; i < 15; i++) {
                UIPanel c = this.GetControl("uiPanel" + i) as UIPanel;
                c.Text = "";
                c.RectSides = ToolStripStatusLabelBorderSides.None;
            }
        }

        public override void Init() {
            base.Init();

            dpk_Start.Value = DateTime.Now.Date;
            dpk_Start.Text = dpk_Start.Value.ToString("yyyy-MM-dd");

            dpk_End.Value = dpk_Start.Value.AddDays(1);
            dpk_End.Text = dpk_End.Value.ToString("yyyy-MM-dd");
            col_Date.DefaultCellStyle.Format = "yyyy-MM-dd";

        }

        /// <summary>
        /// Need to be refactor
        /// </summary>
        void InitializeData() {

            using (var db = new DbAgent()) {
                var works = db.GetWorkContent(dpk_Start.Value, dpk_End.Value);
                WorkList = new List<DailyWorkModel>();
                foreach (var i in works) {
                    DateTime date = i.WorkDate;
                    string content = i.Content;
                    string leaderAlias = RoleNameType.Leader.GetEnumStringValue();
                    string managerAlias = RoleNameType.Manager.GetEnumStringValue();

                    string leaderName = ViewDataAdapter.GetName(i, leaderAlias);
                    string manager = ViewDataAdapter.GetName(i, managerAlias);
                    string exMember = null;
                    string member = "";

                    var mem_involve = i.WorkInvolve.Where(wi => wi.Role.RoleName != leaderAlias && wi.Role.RoleName != managerAlias);
                    foreach (var j in mem_involve) {
                        member += j.Employee.Name + "、";
                    }
                    if (member != "") {
                        member = member.Substring(0, member.Length - 1);
                    }

                    Dictionary<string, string> outsiders = ViewDataAdapter.GetOutsider(i);
                    string key = RoleNameType.Leader.ToString();
                    if (leaderName == null && outsiders != null && outsiders.Keys.Contains(key)) {
                        leaderName = outsiders[key];
                    }
                    key = RoleNameType.Manager.ToString();
                    if (manager == null && outsiders != null && outsiders.Keys.Contains(key)) {
                        manager = outsiders[key];
                    }
                    key = RoleNameType.ExMember.ToString();
                    if (outsiders != null && outsiders.Keys.Contains(key)) {
                        exMember = outsiders[key];
                    }

                    DailyWorkModel di = new DailyWorkModel();
                    di.Id = i.Id;
                    di.Date = date;
                    di.Substation = i.Substations.SubstationName;
                    di.Location = i.Substations.Location;
                    di.WorkType = i.WorkType.Content;
                    di.Content = content;
                    di.Leader = leaderName;
                    di.Manager = manager;
                    di.Member = member;
                    di.Voltage = i.Substations.Voltage;
                    di.ExMember = exMember;

                    WorkList.Add(di);

                }

                // Controls data binding
                dg_worksAssign.AutoGenerateColumns = false;

                pgr_workContent.DataSource = WorkList;

                pgr_workContent.TotalCount = WorkList.Count;


            }

        }

        private void btn_Search_Click(object sender, EventArgs e) {
            InitializeData();
            pgr_workContent.ActivePage = 1;

        }

        private void btn_Del_Click(object sender, EventArgs e) {
            bool canDelete = UIMessageDialog.ShowAskDialog(this, "确认要删除工作吗？");
            if (canDelete) {
                List<DailyWorkModel> chosenWorkId = GetChosenWork();
                int cnt = 0;
                string errMsg = "";
                using (var db = new DbAgent()) {
                    foreach (var i in chosenWorkId) {
                        try {
                            db.DelWorkContent(i.Id);
                            cnt++;
                        }
                        catch (InvalidOperationException ex) {
                            errMsg += "工作Id: " + i + "删除失败，";
                            continue;
                        }
                    }
                }
                string msg = cnt + "项工作删除成功。" + errMsg;
                UIMessageBox.ShowInfo(msg);
            }

            InitializeData();
            pgr_workContent.ActivePage = 1;
        }

        private void btn_Edit_Click(object sender, EventArgs e) {
            // Tips: Row count start at 0
            List<DailyWorkModel> chosenWork = GetChosenWork();
            if (chosenWork.Count < 1) {
                return;
            }
            if (chosenWork.Count > 1) {
                UIMessageBox.ShowInfo("选中多个工作，编辑模式下只能对第一个进行操作。");
            }
            EditWorks frm_EditWorks = new EditWorks(chosenWork.First());
            frm_EditWorks.FormClosed += Frm_EditWorks_FormClosed;

            frm_EditWorks.ShowDialog();
        }

        private void Frm_EditWorks_FormClosed(object sender, FormClosedEventArgs e) {
            InitializeData();
            pgr_workContent.ActivePage = 0;
            pgr_workContent.ActivePage = 1;
        }

        private void pgr_workContent_PageChanged(object sender, object pagingSource, int pageIndex, int count) {
            dg_worksAssign.DataSource = pagingSource;
        }

        /// <summary>
        /// 根据选中情况返回数据，未显式在DataGridView中显式的列也可获取。
        /// </summary>
        /// <returns></returns>
        private List<DailyWorkModel> GetChosenWork() {
            DataGridViewRowCollection dt = dg_worksAssign.Rows;
            List<DailyWorkModel> chosenWork = new List<DailyWorkModel>();
            foreach (DataGridViewRow i in dt) {
                if (i.Cells[0].Value != null && (bool)i.Cells[0].Value) {
                    chosenWork.Add(((DailyWorkModel)i.DataBoundItem));
                }
            }
            return chosenWork;
        }

        private void btn_Export_Click(object sender, EventArgs e) {
            if (WorkList != null && WorkList.Count > 0) {
                DateTime start = dpk_Start.Value;
                DateTime end = dpk_End.Value;
                string template = "Template/daily_assign_template.xlsx";
                using (DailyWork dw = new DailyWork(template)) {

                    dw.ExportExcel("Export/每日工作安排["+start.ToString("MM.dd")+"-"+end.ToString("MM.dd")+"].xlsx",WorkList);
                    
                    dw.Dispose();
                }
                this.ShowInfoDialog("导出成功。");

            }
        }
    }

}
