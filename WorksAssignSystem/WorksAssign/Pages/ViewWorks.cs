﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Sunny.UI;
using WorksAssign.Persistence;
using WorksAssign.Persistence.Adapter;

namespace WorksAssign.Pages {
	public partial class ViewWorks : UIPage {
		public ViewWorks() {
			InitializeComponent();
		}

		public override void Init() {
			base.Init();

			dpk_Start.Value = DateTime.Now.Date;
			dpk_Start.Text = dpk_Start.Value.ToString("yyyy-MM-dd");

			dpk_End.Value = dpk_Start.Value.AddDays(1);
			dpk_End.Text = dpk_End.Value.ToString("yyyy-MM-dd");

		}

		/// <summary>
		/// Need to be refactor
		/// </summary>
		void InitializeData() {

			using (var db = new DbAgent()) {
				var works = db.GetWorkContent(dpk_Start.Value, dpk_End.Value);
				List<WorkAbstractDataRow> list = new List<WorkAbstractDataRow>();
				foreach (var i in works) {
					DateTime date = i.WorkDate;
					string content = i.Content;
					string leaderName = ViewDataAdapter.GetName(i, "负责人");
					string manager = ViewDataAdapter.GetName(i, "管理人员");
					string exMember = null;
					string member = "";

					var mem_inv = i.WorkInvolve.Where(wi => wi.Role.RoleName != "负责人" && wi.Role.RoleName != "管理人员");
					foreach (var j in mem_inv) {
						member += j.Employee.Name + "、";
					}
					if (member != "") {
						member = member.Substring(0, member.Length - 1);
					}

					Dictionary<string, string> outsiders = ViewDataAdapter.GetOutsider(i);
					if (leaderName == null && outsiders != null && outsiders.Keys.Contains("leader")) {
						leaderName = outsiders["leader"];
					}
					if (manager == null && outsiders != null && outsiders.Keys.Contains("manager")) {
						manager = outsiders["manager"];
					}
					if (outsiders != null && outsiders.Keys.Contains("exMember")) {
						exMember = outsiders["exMember"];
					}

					WorkAbstractDataRow di = new WorkAbstractDataRow();
					di.Id = i.ID;
					di.Date = date;
					di.Substation = i.Substations.SubstationName;
					di.Location = i.Substations.Location;
					di.WorkType = i.WorkType.Content;
					di.Content = content;
					di.Leader = leaderName;
					di.Manager = manager;
					di.Member = member;
					di.ExMember = exMember;

					list.Add(di);

				}

                #region Data binding
                dg_worksAssign.AutoGenerateColumns = false;

				pgr_workContent.DataSource = list;
				pgr_workContent.ActivePage = 1;
				pgr_workContent.TotalCount = list.Count;

                #endregion

            }

		}

		private void btn_Search_Click(object sender, EventArgs e) {
			InitializeData();

		}

		private void btn_Del_Click(object sender, EventArgs e) {
			bool canDelete = UIMessageDialog.ShowAskDialog(this, "确认要删除工作吗？");
			if (canDelete) {
				List<WorkAbstractDataRow> chosenWorkId = GetChosenWork();
				int cnt = 0;
				string err = "";
				using (var db = new DbAgent()) {
					foreach (var i in chosenWorkId) {
						try {
							db.DelWorkContent(i.Id);
							cnt++;
						}
						catch (InvalidOperationException ex) {
							err += "工作Id: " + i + "删除失败，";
							continue;
						}
					}
				}
				string msg = cnt + "项工作删除成功。" + err;
				UIMessageBox.ShowInfo(msg);
			}

			InitializeData();
		}

		private void btn_Edit_Click(object sender, EventArgs e) {
			// Tips: Row count start at 0
			List<WorkAbstractDataRow> chosenWork = GetChosenWork();
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
		private List<WorkAbstractDataRow> GetChosenWork() {
			DataGridViewRowCollection dt = dg_worksAssign.Rows;
			List<WorkAbstractDataRow> chosenWork = new List<WorkAbstractDataRow>();
			foreach (DataGridViewRow i in dt) {
				if (i.Cells[0].Value != null && (bool)i.Cells[0].Value) {
					chosenWork.Add(((WorkAbstractDataRow)i.DataBoundItem));
				}
			}
			return chosenWork;
		}
	}
	public class WorkAbstractDataRow {
		public long Id { get; set; }
		public DateTime Date { get; set; }
		public string Substation { get; set; }
		public string Location { get; set; }
		public string WorkType { get; set; }
		public string Content { get; set; }
		public string Leader { get; set; }
		public string Member { get; set; }
		public string Manager { get; set; }
		public string ExMember { get; set; }
	}
}
