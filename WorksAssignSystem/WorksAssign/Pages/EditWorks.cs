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
using WorksAssign.Persistence.Adapter;

namespace WorksAssign.Pages {
	public partial class EditWorks : AbstractForm {
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

        }
    }

    

    class MemberDataRow {
		public long EmployeeId { get; set; }
		public string EmployeeName { get; set; }
		public long RoleId { get; set; }
		public string RoleName { get; set; }
	}
}
