using System;
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
				List<VWDataItem> list = new List<VWDataItem>();
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

					VWDataItem di = new VWDataItem();
					di.Id = i.ID;
					di.Date = date;
					di.Content = content;
					di.Leader = leaderName;
					di.Manager = manager;
					di.Member = member;
					di.ExMember = exMember;

					list.Add(di);

				}
				dg_worksAssign.AutoGenerateColumns = false;
				
				pgr_workContent.DataSource = list;
				pgr_workContent.ActivePage = 1;
				pgr_workContent.TotalCount = list.Count;


			}

		}

		private void btn_Search_Click(object sender, EventArgs e) {
			InitializeData();

		}

		private void btn_Del_Click(object sender, EventArgs e) {
			List<long> chosenWorkId = GetChosenWorkId();


			string msg = "will be deleted workId: ";
			foreach (var i in chosenWorkId) {
				msg += i + ", ";
			}
			UIMessageBox.ShowInfo(msg);
		}

		private void btn_Edit_Click(object sender, EventArgs e) {
			// Tips: Row count start at 0
			List<long> chosenWorkId = GetChosenWorkId();
			

			string msg = "chosen workId: ";
			foreach (var i in chosenWorkId) {
				msg += i + ", ";
			}
			UIMessageBox.ShowInfo(msg);

		}

		private void pgr_workContent_PageChanged(object sender, object pagingSource, int pageIndex, int count) {
			dg_worksAssign.DataSource = pagingSource;
		}

		private List<long> GetChosenWorkId() {
			DataGridViewRowCollection dt = dg_worksAssign.Rows;
			List<long> chosenWorkId = new List<long>();
			foreach (DataGridViewRow i in dt) {
				if (i.Cells[0].Value != null && (bool)i.Cells[0].Value) {
					chosenWorkId.Add(((VWDataItem)i.DataBoundItem).Id);
				}
			}
			return chosenWorkId;
		}
	}
	class VWDataItem {
		public long Id { get; set; }
		public DateTime Date { get; set; }
		public string Content { get; set; }
		public string Leader { get; set; }
		public string Member { get; set; }
		public string Manager { get; set; }
		public string ExMember { get; set; }
	}
}
