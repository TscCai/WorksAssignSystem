using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sunny.UI;
using WorksAssign.Persistence;
using WorksAssign.Util.Export;
using WorksAssign.Util.Export.DataBuilder;
using WorksAssign.Util.Export.DataModel;

namespace WorksAssign.Pages
{
    public partial class ViewWorks : UIPage
    {
        List<DailyWorkModel> WorkList;
        EditWorks frm_EditWorks;


        public ViewWorks() {
            InitializeComponent();

            dpk_Start.Value = DateTime.Now.Date;
            dpk_Start.Text = dpk_Start.Value.ToString("yyyy-MM-dd");

            dpk_End.Value = dpk_Start.Value.AddDays(1);
            dpk_End.Text = dpk_End.Value.ToString("yyyy-MM-dd");
            col_Date.DefaultCellStyle.Format = "yyyy-MM-dd";


            frm_EditWorks = new EditWorks();
            frm_EditWorks.FormClosed += Frm_EditWorks_FormClosed;
        }



        /// <summary>
        /// Need to be refactor
        /// </summary>
        void InitializeData() {

            using (var db = new DbAgent()) {
                var works = db.GetWorkContent(dpk_Start.Value, dpk_End.Value);

                //IDataModelBuilder<DailyWorkModel> builder = new DailyWorkBuilder(works);
                DailyWorkBuilder builder = new DailyWorkBuilder(works);
                WorkList = builder.BuildData();

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
            //EditWorks frm_EditWorks = new EditWorks(chosenWork.First());
            //frm_EditWorks.FormClosed += Frm_EditWorks_FormClosed;
            frm_EditWorks.SetDataModel(chosenWork.First());
            frm_EditWorks.ShowDialog();

        }

        private void btn_Export_Click(object sender, EventArgs e) {
            if (WorkList != null && WorkList.Count > 0) {
                DateTime start = dpk_Start.Value;
                DateTime end = dpk_End.Value;
                string template = "Template/daily_assign_template.xlsx";
                using (DailyWorkExporter dw = new DailyWorkExporter(template, WorkList)) {

                    dw.ExportExcel("Export/每日工作安排[" + start.ToString("MM.dd") + "-" + end.ToString("MM.dd") + "].xlsx");

                    dw.Dispose();
                }
                this.ShowInfoDialog("导出成功。");

            }
        }

        private void Frm_EditWorks_FormClosed(object sender, FormClosedEventArgs e) {
            if (!frm_EditWorks.CancelEditFlag) {
                InitializeData();
                pgr_workContent.ActivePage = 0;
                pgr_workContent.ActivePage = 1;
            }
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

    }

}
