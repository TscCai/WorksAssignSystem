using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Persistence.Adapter {
	public class ViewDataAdapter {
		/// <summary>
		/// 通过角色名(RoleName)获取成员姓名
		/// </summary>
		/// <param name="wc"></param>
		/// <param name="roleName"></param>
		/// <returns></returns>
		public static string GetName(WorkContent wc,string roleName) {
			WorkInvolve w = wc.WorkInvolve.SingleOrDefault(wi => wi.Role.RoleName == roleName);
			if (w != null) {
				return w.Employee.Name;
			}
			else {
				return null;
			}
		}

		/// <summary>
		/// 获取外部人员（非本班组的负责人、管理人员、外协民工及厂家）
		/// </summary>
		/// <param name="wc"></param>
		/// <returns>
		///		result["Leader"]: 负责人
		///		result["Manager"]: 管理人员
		///		result["ExMember"]: 外协人员
		/// </returns>
		public static Dictionary<string, string> GetOutsider(WorkContent wc) {
			Dictionary<string, string> result=null;
			if (!String.IsNullOrEmpty(wc.ExMember)) {
				result = new Dictionary<string, string>();
				string[] tmp = wc.ExMember.Split('|');
				foreach (var i in tmp) {
					if (i.StartsWith(RoleNameType.Leader.GetEnumStringValue()+"：")) {
						string value = i.Substring(4);
						result.Add(RoleNameType.Leader.ToString(), value);
					}
					else if (i.StartsWith(RoleNameType.Manager.GetEnumStringValue()+"：")) {
						string value = i.Substring(5);
						result.Add(RoleNameType.Manager.ToString(), value);
					}
					else if (i.StartsWith(RoleNameType.ExMember.GetEnumStringValue() + "：")) {
						string value = i.Substring(5);
						result.Add(RoleNameType.ExMember.ToString(), value);
					}
				}			
			}
			return result;
		}


	}
}
