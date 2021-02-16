using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using Sunny.UI;
using WorksAssign.Persistence;


namespace WorksAssign.Pages
{
    public partial class NewWorks : UIPage
    {

        DbAgent db;
        Dictionary<string, long> substations;
        Dictionary<string, long> employees;
        Dictionary<string, long> workType;
        //  Dictionary<string, bool> dictErr;


        public NewWorks() {
            InitializeComponent();
            // additional component init.
            dpk_WorkDate.Value = DateTime.Now.AddDays(1).Date;
            cb_ShortType.SelectedIndex = 1;
            InitializeData();

        }

        private void InitializeData() {
            using (db = new DbAgent()) {
                substations = db.GetSubstation().ToDictionary(k => k.SubstationName, v => v.Id);
                employees = db.GetEmployee().ToDictionary(k => k.Name, v => v.Id);
                workType = db.GetWorkType().ToDictionary(k => k.Content, v => v.Id);
                //  dictErr = new Dictionary<string, bool>();


                cb_Substation.DataSource = new BindingSource(substations, null);
                cb_Substation.ValueMember = "Value";
                cb_Substation.DisplayMember = "Key";
                // dictErr.Add(cb_Substation.Name, false);

                cb_WorkType.DataSource = new BindingSource(workType, null);
                cb_WorkType.ValueMember = "Value";
                cb_WorkType.DisplayMember = "Key";
                cb_WorkType.SelectedIndex = 0;
                //   dictErr.Add(cb_WorkType.Name, false);

                cb_Leader.DataSource = new BindingSource(employees, null);
                cb_Leader.ValueMember = "Value";
                cb_Leader.DisplayMember = "Key";
                //  dictErr.Add(cb_Leader.Name, false);

                cb_Manager.DataSource = new BindingSource(employees, null);
                cb_Manager.ValueMember = "Value";
                cb_Manager.DisplayMember = "Key";
                // dictErr.Add(cb_Manager.Name, false);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e) {
            using (db = new DbAgent()) {
                NewWorkModel model = CreateViewDataModel();
                if (model.Error) {
                    this.ShowErrorDialog(model.ErrorMessage);
                    return;
                }
                bool isContinue = true;
                if (!model.HintMessage.IsNullOrEmpty()) {
                    isContinue = this.ShowAskDialog(model.HintMessage + "确认添加吗？");
                }
                if (isContinue) {
                    db.AddWork(model.SubstationId, model.WorkTypeId, model.WorkContent, model.WorkDate, model.ShortType,model.InvolveList, model.Outsider);
                    this.ShowSuccessNotifier("新增工作成功！");
                    ResetInput();
                }
            }

        }

        /// <summary>
        /// Must invoke after DbAgent init, and it won't dispose the Database Entity
        /// </summary>
        /// <returns></returns>
        private NewWorkModel CreateViewDataModel() {

            NewWorkModel result = new NewWorkModel();

            string outsider = "";
            string hintMsg = "";
            bool error = false;
            string errorMsg = "";
            List<long> memberId = new List<long>();
            List<string> exMemberName = new List<string>();  // 外部人员名单

            // 获取简单字段的值
            DateTime workDate = dpk_WorkDate.Value.Date;
            long substationId = DbAgent.NOT_SUBSTATION;
            if (cb_Substation.SelectedValue != null) {
                substationId = (long)cb_Substation.SelectedValue;
            }
            else {
                hintMsg += "注意，该工作未选择变电站，将以“其他”填充\n";
            }
             

            long workTypeId = (long)cb_WorkType.SelectedValue;
            string workContent = txt_WorkContent.Text;
            if (workContent.IsNullOrEmpty()) {
                error = true;
                errorMsg += "无工作内容\n";
            }
            string shortType = cb_ShortType.Text;

            // leader, manager下拉框的选择值为空则为外部人员
            long leaderId = cb_Leader.SelectedValue == null ? DbAgent.OUTSIDER : (long)cb_Leader.SelectedValue;
            long managerId = cb_Manager.SelectedValue == null ? DbAgent.OUTSIDER : (long)cb_Manager.SelectedValue;

            // 将工作班成员文本框中的人员按符号分割，不在employees字典里的即为外部人员
            string[] memberName = txt_Member.Text.Split("、");
            foreach (var i in memberName) {
                if (employees.ContainsKey(i)) {
                    memberId.Add(employees[i]);
                }
                else {
                    exMemberName.Add(i);
                }
            }

            // 访问数据库中的数据，取Role相关值

            List<WorkInvolve> involveList = new List<WorkInvolve>();

            // add leader
            if (cb_Leader.Text != "" && leaderId == DbAgent.OUTSIDER) {
                // 非表中人员，且有姓名，应存入WorkContent的ExMember
                outsider += "负责人：" + cb_Leader.Text + "|";
                hintMsg += "存在非本班组的负责人：" + cb_Leader.Text + "\n";
            }
            else if (cb_Leader.Text == "") {
                errorMsg += "无工作负责人";
                error = true;
            }
            else {
                WorkInvolve wi = new WorkInvolve();
                wi.EmployeeId = leaderId;
                wi.RoleId = db.GetRole(workTypeId, RoleNameType.Leader.GetEnumStringValue()).Id;
                involveList.Add(wi);
            }

            // add manager
            if (cb_Manager.Text == "") {
                // NO manager, 无管理人员不作为错误的判据
                hintMsg += "不存在管理人员\n";
                // error = true;
                // errorMsg +="不存在管理人员\n";

            }
            else if (cb_Manager.Text != "" && managerId == DbAgent.OUTSIDER) {
                // outsider manager
                // 非表中人员，且有姓名，应存入WorkContent的ExMember
                outsider += "管理人员：" + cb_Manager.Text + "|";
                hintMsg += "存在非本班组的管理人员：" + cb_Manager.Text + "\n";
            }
            else {
                WorkInvolve wi = new WorkInvolve();
                wi.EmployeeId = managerId;
                wi.RoleId = db.GetRole(workTypeId, RoleNameType.Manager.GetEnumStringValue()).Id;
                involveList.Add(wi);
            }


            // add member
            foreach (var i in memberId) {
                // set all member as senior by default except the young guy judged by his join date
                WorkInvolve wi = new WorkInvolve();
                wi.EmployeeId = i;
                DateTime tmp = db.GetEmployee(i).JoinDate;
                string roleName;
                if ((DateTime.Now - tmp).TotalDays < 365 * 2) {
                    roleName = RoleNameType.YoungGuy.GetEnumStringValue();
                }
                else {
                    roleName = RoleNameType.Senior.GetEnumStringValue();
                }
                wi.RoleId = db.GetRole(workTypeId, roleName).Id;
                involveList.Add(wi);
            }




            // add ex-member 
            if (exMemberName != null && exMemberName.Count > 0 && exMemberName.First() != "") {
                string ex = "外协人员：";
                foreach (var i in exMemberName) {
                    ex += i + "、";
                }
                ex = ex.Substring(0, ex.Length - 1);
                outsider += ex;
                hintMsg += "存在" + ex;
            }


            result.SubstationId = substationId;
            result.WorkTypeId = workTypeId;
            result.WorkContent = workContent;
            result.WorkDate = workDate;
            result.Outsider = outsider;
            result.HintMessage = hintMsg;
            result.ShortType = shortType;
            // 暂无备注，下一行代码注释掉
            //result.Comment = null;
            result.InvolveList = involveList;
            result.Error = error;
            result.ErrorMessage = errorMsg;
            return result;




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


        private void btn_Reset_Click(object sender, EventArgs e) {
            ResetInput();
        }

        void ComboBox_EditorLostFocus(UIComboBox cb, Dictionary<string, long> dict) {
            string input = cb.Text;
            try {
                long data = dict[input];
                cb.SelectedValue = data;
                //dictErr[cb.Name] = false;
            }
            catch (KeyNotFoundException ex) {
                cb.SelectedIndex = -1;
                cb.SelectedValue = null;
                cb.Text = input;
                //dictErr[cb.Name] = true;
            }
        }

        void ResetInput() {
            cb_Substation.SelectedValue = null;
            cb_Substation.Text = "";
            cb_Leader.SelectedValue = null;
            cb_Leader.Text = "";
            cb_Manager.SelectedValue = null;
            cb_Manager.Text = "";

            cb_WorkType.SelectedIndex = 0;
            dpk_WorkDate.Value = DateTime.Now.AddDays(1).Date;
            txt_WorkContent.Text = "";
            txt_Member.Text = "";
        }



    }

    public class NewWorkModel
    {
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
        public string HintMessage { get; set; }
        public long SubstationId { get; set; }
        public long WorkTypeId { get; set; }
        public string WorkContent { get; set; }
        public string ShortType { get; set; }
        public DateTime WorkDate { get; set; }
        public List<WorkInvolve> InvolveList { get; set; }
        public string Outsider { get; set; }
        public string Comment { get; set; }

        public NewWorkModel() { Error = false; }
    }
}
