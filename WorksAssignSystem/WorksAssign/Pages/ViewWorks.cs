using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;
using WorksAssign.Persistence;
using WorksAssign.Persistence.Adapter;

namespace WorksAssign.Pages {
	public partial class ViewWorks : UIPage {
		public ViewWorks() {
			InitializeComponent();
			
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

					var mem_inv = i.WorkInvolve.Where(wi => wi.Role.RoleName != "负责人" && wi.Role.RoleName !="管理人员");
					foreach (var j in mem_inv) {
						member += j.Employee.Name+"、";
					}
					if (member != "") {
						member = member.Substring(0, member.Length - 1);
					}

					Dictionary<string,string> outsiders = ViewDataAdapter.GetOutsider(i);
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
					di.Date = date;
					di.Content = content;
					di.Leader = leaderName;
					di.Manager = manager;
					di.Member = member;
					di.ExMember = exMember;

					list.Add(di);

				}

				dg_worksAssign.DataSource = list;
				
				
			}

		}

		private void btn_Search_Click(object sender, EventArgs e) {
			InitializeData();
		}
	}
	class VWDataItem {
		public DateTime Date { get; set; }
		public string Content { get; set; }
		public string Leader { get; set; }
		public string Member { get; set; }
		public string Manager { get; set; }
		public string ExMember { get; set; }
	}
}
