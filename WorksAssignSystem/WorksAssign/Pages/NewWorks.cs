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
using WorksAssign.Util;
using WorksAssign.Persistence;


namespace WorksAssign.Pages {
    public partial class NewWorks : UIPage {
        DbAgent db;
        Dictionary<string, long> substations;
        Dictionary<string, long> employees;
        Dictionary<string, long> workType;
        Dictionary<string, bool> dictErr;


        public NewWorks() {
            InitializeComponent();
            InitializeData();

        }

        private void InitializeData() {
            using (db = new DbAgent()) {
                substations = db.GetSubstation().ToDictionary(k => k.SubstationName, v => v.Id);
                employees = db.GetEmployee().ToDictionary(k => k.Name, v => v.Id);
                workType = db.GetWorkType().ToDictionary(k => k.Content, v => v.ID);
                dictErr = new Dictionary<string, bool>();


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
            }
        }

        private void btn_OK_Click(object sender, EventArgs e) {
            #region 准备界面中的数据
            List<long> memberId = new List<long>();
            List<string> exMemberName = new List<string>();  // 外部人员名单
            DateTime workDate = dpk_WorkDate.Value;
            long substationId = cb_Substation.SelectedValue == null ? DbAgent.NOT_SUBSTATION : (long)cb_Substation.SelectedValue;
            long workTypeId = (long)cb_WorkType.SelectedValue;
            string workContent = txt_WorkContent.Text;

            long leaderId = cb_Leader.SelectedValue == null ? DbAgent.OUTSIDER : (long)cb_Leader.SelectedValue;
            long managerId = cb_Manager.SelectedValue == null ? DbAgent.OUTSIDER : (long)cb_Manager.SelectedValue;

            string[] memberName = txt_Member.Text.Split("、");
            foreach (var i in memberName) {
                try {
                    memberId.Add(employees[i]);
                }
                catch (KeyNotFoundException ex) {
                    exMemberName.Add(i);
                }
            }
            #endregion
            
            using (db = new DbAgent()) {
                #region 访问数据库中的数据
                List<WorkInvolve> list = new List<WorkInvolve>();
                string wcComment = null;
                string hintMsg = "";
                // add leader
                if (dictErr[cb_Leader.Name] && cb_Leader.Text != "" && leaderId == DbAgent.OUTSIDER) {
                    // 非表中人员，且有姓名，应存入WorkContent的备注
                    wcComment += "负责人：" + cb_Leader.Text + "|";
                    hintMsg += "存在非本班组的负责人：" + cb_Leader.Text + "\n";
                }
                else if (cb_Leader.Text == "") {
                    UIMessageBox.ShowError("工作无负责人。");
                    return;
                }
                else {
                    WorkInvolve w = new WorkInvolve();
                    w.EID = leaderId;
                    w.RID = db.GetRole(workTypeId, RoleNameType.Leader.GetEnumStringValue()).ID;
                    //w.WID = 0;
                    list.Add(w);
                }
                // add manager
                if (cb_Manager.Text == "") {
                    // NO manager
                    hintMsg += "不存在管理人员\n";
                }
                else if (dictErr[cb_Manager.Name] && cb_Manager.Text != "") {
                    // outsider manager
                    // 非表中人员，且有姓名，应存入WorkContent的备注
                    wcComment += "管理人员：" + cb_Manager.Text + "|";
                    hintMsg += "存在非本班组的管理人员：" + cb_Manager.Text + "\n";
                }
                else {
                    WorkInvolve w = new WorkInvolve();
                    w.EID = managerId;
                    w.RID = db.GetRole(workTypeId, RoleNameType.Manager.GetEnumStringValue()).ID;
                    list.Add(w);
                }
                // add member
                foreach (var i in memberId) {
                    // set all member as senior by default except the young guy judged by his join date
                    WorkInvolve w = new WorkInvolve();
                    w.EID = i;
                    DateTime tmp = db.GetEmployee(i).JoinDate;
                    string roleName;
                    if ((DateTime.Now - tmp).TotalDays < 365 * 2) {
                        roleName = RoleNameType.YoungGuy.GetEnumStringValue();
                    }
                    else {
                        roleName = RoleNameType.Senior.GetEnumStringValue();
                    }
                    w.RID = db.GetRole(workTypeId, roleName).ID;
                    list.Add(w);
                }
                #endregion

                #region 写入数据库前的准备，提示信息等

                // add ex-member 
                if (exMemberName != null && exMemberName.Count > 0 && exMemberName.First() != "") {
                    string ex = "外协人员：";
                    foreach (var i in exMemberName) {
                        ex += i + "、";
                    }
                    ex = ex.Substring(0, ex.Length - 1);
                    wcComment += ex;
                    hintMsg += "存在" + ex;
                }
                bool isContinue = true;
                if (hintMsg != "") {
                    hintMsg = "提示：\n" + hintMsg + "\n确认添加吗？";
                    isContinue = UIMessageDialog.ShowAskDialog(this, hintMsg);
                }

                #endregion             
                
                if (isContinue) {
                    db.AddWork(substationId, workTypeId, workContent, workDate, list, wcComment);
                    UIMessageBox.ShowSuccess("新增工作成功！");
                    ResetInput();
                }

            }
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
                dictErr[cb.Name] = false;
            }
            catch (KeyNotFoundException ex) {
                cb.SelectedIndex = -1;
                cb.SelectedValue = null;
                cb.Text = input;
                dictErr[cb.Name] = true;
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
            dpk_WorkDate.Value = DateTime.Now;
            txt_WorkContent.Text = "";
            txt_Member.Text = "";
        }


    }
}
