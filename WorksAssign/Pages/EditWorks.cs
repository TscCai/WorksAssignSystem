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
using WorksAssign.Util.Export.DataModel;
using WorksAssign.Pages.Master;

namespace WorksAssign.Pages
{
    public partial class EditWorks : AbstractForm
    {
        long workId;

        object tmpCellForUpdate;
        int dgOriginCnt = 0;
        protected Dictionary<string, long> roles;

        public bool CancelEditFlag { get; private set; }

        DailyWorkModel chosenData;
        /// <summary>
        /// 原工作内容
        /// </summary>


        public EditWorks() {
            InitializeComponent();
            CancelEditFlag = false;

        }

        protected override void InitializeData() {
            base.InitializeData();

            //  db = new DbAgent();
            #region 绑定ComboBox数据
            cb_Substation.DataSource = new BindingSource(substations, null);
            cb_Substation.ValueMember = "Value";
            cb_Substation.DisplayMember = "Key";
            dictErr.Add(cb_Substation.Name, false);

            cb_WorkType.DataSource = new BindingSource(workType, null);
            cb_WorkType.ValueMember = "Value";
            cb_WorkType.DisplayMember = "Key";
            cb_WorkType.SelectedIndex = 0;
            dictErr.Add(cb_WorkType.Name, false);

            cb_Leader.DataSource = new BindingSource(employees, null);
            cb_Leader.ValueMember = "Value";
            cb_Leader.DisplayMember = "Key";
            dictErr.Add(cb_Leader.Name, false);

            cb_Manager.DataSource = new BindingSource(employees, null);
            cb_Manager.ValueMember = "Value";
            cb_Manager.DisplayMember = "Key";
            dictErr.Add(cb_Manager.Name, false);
            #endregion


            cb_Substation.Text = chosenData.Substation;
            cb_WorkType.Text = chosenData.WorkType;
            cb_Leader.Text = chosenData.Leader;
            cb_Manager.Text = chosenData.Manager;

            // 短类型无需绑定
            cb_ShortType.Text = chosenData.ShortType;


            ComboBox_EditorLostFocus(cb_Substation, substations);
            ComboBox_EditorLostFocus(cb_WorkType, workType);
            ComboBox_EditorLostFocus(cb_Leader, employees);
            ComboBox_EditorLostFocus(cb_Manager, employees);

            WorkContent chosenWorkContent;
            IEnumerable<WorkInvolve> originalMembers;

            using (db = new WasDbAgent()) {

                chosenWorkContent = db.GetWorkContent(workId);
                roles = db.GetRole(chosenWorkContent.WorkType.Id).ToDictionary(k => k.RoleName, v => v.Id);

                string leaderAlias = RoleNameType.Leader.GetEnumStringValue();
                string managerAlias = RoleNameType.Manager.GetEnumStringValue();

                col_Role.Items.AddRange(roles.Keys.Where(k => k != leaderAlias && k != managerAlias).ToArray());


                originalMembers = chosenWorkContent.WorkInvolve.Where(
                    wi => wi.Role.RoleName != leaderAlias && wi.Role.RoleName != managerAlias
                    );
                List<MemberDataRow> data = new List<MemberDataRow>();
                foreach (var i in originalMembers) {
                    var tmp = new MemberDataRow();
                    tmp.EmployeeName = i.Employee.Name;
                    tmp.EmployeeId = i.EmployeeId;
                    tmp.RoleId = i.RoleId;
                    tmp.RoleName = i.Role.RoleName;
                    data.Add(tmp);
                }
                dg_Member.AutoGenerateColumns = false;
                BindingSource bs = new BindingSource();
                bs.DataSource = data;
                dg_Member.DataSource = bs;

                dgOriginCnt = dg_Member.Rows.Count;
            }


        }

        public EditWorks(DailyWorkModel data)
            : this() {
            this.chosenData = data;
            dpk_WorkDate.Value = this.chosenData.Date;
            cb_Leader.Text = this.chosenData.Leader;
            cb_Substation.Text = this.chosenData.Substation;
            cb_Manager.Text = this.chosenData.Manager;
            cb_WorkType.Text = this.chosenData.WorkType;
            txt_WorkContent.Text = this.chosenData.Content;
            workId = this.chosenData.Id;
            // 外协人员不计入绩效，直接覆盖，存入WorkContent.Comments即可
            txt_exMember.Text = chosenData.ExMember;

            InitializeData();
        }


        public void SetDataModel(DailyWorkModel data) {
            this.chosenData = data;
            dpk_WorkDate.Value = this.chosenData.Date;
            cb_Leader.Text = this.chosenData.Leader;
            cb_Substation.Text = this.chosenData.Substation;
            cb_Manager.Text = this.chosenData.Manager;
            cb_WorkType.Text = this.chosenData.WorkType;
            txt_WorkContent.Text = this.chosenData.Content;
            workId = this.chosenData.Id;
            // 外协人员不计入绩效，直接覆盖，存入WorkContent.Comments即可
            txt_exMember.Text = chosenData.ExMember;

            InitializeData();
        }


        private void btn_Cancel_Click(object sender, EventArgs e) {
            CancelEditFlag = true;
            this.Close();

        }

        private void cb_Substation_EditorLostFocus(object sender, EventArgs e) {
            ComboBox_EditorLostFocus(cb_Substation, substations);
        }

        private void cb_Leader_EditorLostFocus(object sender, EventArgs e) {
            ComboBox_EditorLostFocus(cb_Leader, employees);
        }

        private void cb_Manager_EditorLostFocus(object sender, EventArgs e) {
            ComboBox_EditorLostFocus(cb_Manager, employees);
        }

        /// <summary>
        /// 更新WorkInvove数据采取全部清除重新添加的方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e) {
            EditWorkModel model = CreateViewDataModel();
            if (model.Error) {
                this.ShowErrorDialog(model.ErrorMessage);
                return;
            }
            else {
                bool isContinue = true;
                if (model.HintMessage != "") {
                    string hintMsg = "提示：\n" + model.HintMessage + "\n确认添加吗？";
                    isContinue = UIMessageDialog.ShowAskDialog(this, hintMsg);
                }
                if (isContinue) {
                    // Remove orginal members involve, then add new ones.

                    using (db = new WasDbAgent()) {
                        WorkContent originalData = db.GetWorkContent(workId);
                        originalData.ExMember = model.Outsider;
                        originalData.WorkDate = model.WorkDate;
                        originalData.SubstationId = model.SubstationId;
                        originalData.TypeId = model.WorkTypeId;
                        originalData.Content = model.WorkContent;
                        originalData.ShortType = model.ShortType;
                        db.UpdateWork(originalData, model.InvolveList, true);
                    }
                    // 更新成功后，必须先关闭本模态窗口，再弹对话框
                    this.ShowSuccessDialog("编辑工作成功！");
                    this.Close();
                }

            }
        }

        private List<MemberDataRow> ExtractMemberFromDataGrid() {
            List<MemberDataRow> result = new List<MemberDataRow>();
            foreach (DataGridViewRow row in dg_Member.Rows) {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null) {
                    string employeeName = ((DataGridViewTextBoxCell)row.Cells[0]).Value.ToString();
                    string roleName = ((DataGridViewComboBoxCell)row.Cells[1]).Value.ToString();
                    MemberDataRow item = new MemberDataRow();
                    item.EmployeeName = employeeName;
                    item.RoleName = roleName;

                    item.EmployeeId = employees[employeeName];

                    item.RoleId = roles[roleName];
                    result.Add(item);
                }
                else if ((row.Cells[0].Value == null && row.Cells[1].Value == null)) { continue; }
                else {
                    throw new InvalidOperationException("工作班成员信息不完整。");
                }
            }

            return result;
        }



        private void cb_WorkType_SelectedIndexChanged(object sender, EventArgs e) {
            long typeId = (long)cb_WorkType.SelectedValue;
            using (db = new WasDbAgent()) {
                roles = db.GetRole(typeId).ToDictionary(k => k.RoleName, v => v.Id);
            }
        }

        private EditWorkModel CreateViewDataModel() {
            EditWorkModel result = new EditWorkModel();
            List<WorkInvolve> involveList = new List<WorkInvolve>();
            string shortType = cb_ShortType.Text;

            List<long> memberId = new List<long>();
            List<string> exMemberName = new List<string>();  // 外部人员名单

            DateTime workDate = dpk_WorkDate.Value.Date;
            long substationId = cb_Substation.SelectedValue == null ? WasDbAgent.NOT_SUBSTATION : (long)cb_Substation.SelectedValue;
            long workTypeId = (long)cb_WorkType.SelectedValue;
            string workContent = txt_WorkContent.Text;

            long leaderId = cb_Leader.SelectedValue == null ? WasDbAgent.OUTSIDER : (long)cb_Leader.SelectedValue;
            long managerId = cb_Manager.SelectedValue == null ? WasDbAgent.OUTSIDER : (long)cb_Manager.SelectedValue;


            string outsider = null;
            string hintMsg = "";
            // add leader
            if (cb_Leader.Text != "" && leaderId == WasDbAgent.OUTSIDER) {
                // 非表中人员，且有姓名，应存入WorkContent的ExMember
                outsider += RoleNameType.Leader.GetEnumStringValue() + "：" + cb_Leader.Text + "|";
                hintMsg += "存在非本班组的负责人：" + cb_Leader.Text + "\n";
            }
            else if (cb_Leader.Text == "") {
                result.ErrorMessage += "工作无负责人。";
                result.Error = true;
            }
            else {
                WorkInvolve wi = new WorkInvolve();
                wi.EmployeeId = leaderId;
                wi.RoleId = roles[RoleNameType.Leader.GetEnumStringValue()];
                involveList.Add(wi);
            }
            // add manager
            if (cb_Manager.Text == "") {
                // NO manager
                hintMsg += "不存在管理人员\n";
            }
            else if (cb_Manager.Text != "" && managerId == WasDbAgent.OUTSIDER) {
                // outsider manager
                // 非表中人员，且有姓名，应存入WorkContent的ExMember
                outsider += RoleNameType.Manager.GetEnumStringValue() + "：" + cb_Manager.Text + "|";
                hintMsg += "存在非本班组的管理人员：" + cb_Manager.Text + "\n";
            }
            else {
                WorkInvolve wi = new WorkInvolve();
                wi.EmployeeId = managerId;
                wi.RoleId = roles[RoleNameType.Manager.GetEnumStringValue()];
                involveList.Add(wi);
            }

            // add member
            try {
                List<MemberDataRow> currentMembers = ExtractMemberFromDataGrid();

                foreach (var i in currentMembers) {

                    WorkInvolve wi = new WorkInvolve();
                    wi.EmployeeId = i.EmployeeId;
                    wi.RoleId = i.RoleId;
                    involveList.Add(wi);
                }


                // add ex-member 

                if (!txt_exMember.Text.IsNullOrEmpty()) {
                    string ex = "外协人员：" + txt_exMember.Text;
                    outsider += ex;
                    hintMsg += "存在" + ex;
                }

                result.SubstationId = substationId;
                result.WorkTypeId = workTypeId;
                result.WorkContent = workContent;
                result.WorkDate = workDate;
                result.ShortType = shortType;
                result.Outsider = outsider;
                result.HintMessage = hintMsg;
                // 暂无备注，下一行代码注释掉
                //result.Comment = null;
                result.InvolveList = involveList;

            }
            catch (InvalidOperationException ex) {
                result.ErrorMessage = ex.Message;
                result.Error = true;

            }
            catch (KeyNotFoundException ex) {
                result.ErrorMessage = "存在未知的班组成员";
                result.Error = true;

            }

            return result;

        }

    }

    class MemberDataRow
    {
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public class EditWorkModel : NewWorkModel { }
}