using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Persistence.Adapter {
	public class ViewDataAdapter {
		public static string GetName(WorkContent wc,string key) {
			WorkInvolve w = wc.WorkInvolve.SingleOrDefault(wi => wi.Role.RoleName == key);
			if (w != null) {
				return w.Employee.Name;
			}
			else {
				return null;
			}
		}

		public static Dictionary<string, string> GetOutsider(WorkContent wc) {
			Dictionary<string, string> result=null;
			if (!String.IsNullOrEmpty(wc.Comment)) {
				result = new Dictionary<string, string>();
				string[] tmp = wc.Comment.Split('|');
				foreach (var i in tmp) {
					if (i.StartsWith("负责人：")) {
						string value = i.Substring(4);
						result.Add("leader", value);
					}
					else if (i.StartsWith("管理人员：")) {
						string value = i.Substring(5);
						result.Add("manager", value);
					}
					else if (i.StartsWith("外协人员：")) {
						string value = i.Substring(5);
						result.Add("exMember", value);
					}
				}			
			}
			return result;
		}
	}
}
