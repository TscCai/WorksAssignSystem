﻿using System;
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

namespace WorksAssign.Pages
{
    public partial class EditWorks : AbstractForm
    {
        long workId;
        List<string> exMembers;
        IEnumerable<WorkInvolve> members;

        protected Dictionary<string, long> roles;
        WorkAbstractDataRow chosenData;


        public EditWorks() {
            InitializeComponent();


        }

        protected override void InitializeData() {
            base.InitializeData();

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

            ComboBox_EditorLostFocus(cb_Substation, substations);
            ComboBox_EditorLostFocus(cb_WorkType, workType);
            ComboBox_EditorLostFocus(cb_Leader, employees);
            ComboBox_EditorLostFocus(cb_Manager, employees);


            using (db = new DbAgent()) {

                WorkContent wc = db.GetWorkContent(workId);
                roles = db.GetRole(wc.WorkType.ID).ToDictionary(k => k.RoleName, v => v.ID);
                roles.Remove("负责人");
                roles.Remove("管理人员");

                col_Role.Items.AddRange(roles.Keys.ToArray());


                members = wc.WorkInvolve.Where(
                    wi => wi.Role.RoleName != "负责人" && wi.Role.RoleName != "管理人员"
                    );
                List<MemberDataRow> data = new List<MemberDataRow>();
                foreach (var i in members) {
                    var tmp = new MemberDataRow();
                    tmp.EmployeeName = i.Employee.Name;
                    tmp.EmployeeId = i.EID;
                    tmp.RoleId = i.RID;
                    tmp.RoleName = i.Role.RoleName;
                    data.Add(tmp);
                }
                dg_Member.AutoGenerateColumns = false;
                BindingSource bs = new BindingSource();
                bs.DataSource = data;
                dg_Member.DataSource = bs;




            }


        }

        public EditWorks(WorkAbstractDataRow data)
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



        private void btn_Cancel_Click(object sender, EventArgs e) {
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

        private void btn_OK_Click(object sender, EventArgs e) {
            #region 准备界面中的数据
            List<long> memberId = new List<long>();
            List<string> exMemberName = new List<string>();  // 外部人员名单
            DateTime workDate = dpk_WorkDate.Value.Date;
            long substationId = cb_Substation.SelectedValue == null ? DbAgent.NOT_SUBSTATION : (long)cb_Substation.SelectedValue;
            long workTypeId = (long)cb_WorkType.SelectedValue;
            string workContent = txt_WorkContent.Text;

            long leaderId = cb_Leader.SelectedValue == null ? DbAgent.OUTSIDER : (long)cb_Leader.SelectedValue;
            long managerId = cb_Manager.SelectedValue == null ? DbAgent.OUTSIDER : (long)cb_Manager.SelectedValue;



            string[] memberName = new string[] { };
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
                string wcExMember = null;
                string hintMsg = "";
                // add leader
                if (dictErr[cb_Leader.Name] && cb_Leader.Text != "" && leaderId == DbAgent.OUTSIDER) {
                    // 非表中人员，且有姓名，应存入WorkContent的ExMember
                    wcExMember += "负责人：" + cb_Leader.Text + "|";
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
                    // 非表中人员，且有姓名，应存入WorkContent的ExMember
                    wcExMember += "管理人员：" + cb_Manager.Text + "|";
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
                    wcExMember += ex;
                    hintMsg += "存在" + ex;
                }
                bool isContinue = true;
                if (hintMsg != "") {
                    hintMsg = "提示：\n" + hintMsg + "\n确认添加吗？";
                    isContinue = UIMessageDialog.ShowAskDialog(this, hintMsg);
                }

                #endregion

                if (isContinue) {
                    db.AddWork(substationId, workTypeId, workContent, workDate, list, wcExMember);
                    UIMessageBox.ShowSuccess("新增工作成功！");
                    this.Close();
                }



            }
        }



        class MemberDataRow
        {
            public long EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public long RoleId { get; set; }
            public string RoleName { get; set; }
        }
    }
}
