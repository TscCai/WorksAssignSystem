using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorksAssign.Persistence;
using WorksAssign.Persistence.Extension;
using WorksAssign.Util.Export.DataModel;

namespace WorksAssign.Util.Export.DataBuilder
{
    public class DailyWorkBuilder : BaseDataModelBuilder<DailyWorkModel>
    {
        IQueryable<WorkContent> Works;
        public DailyWorkBuilder(IQueryable<WorkContent> works) {
            Works = works;
        }


        public override List<DailyWorkModel> BuildData() {
            var workList = new List<DailyWorkModel>();
            foreach (var i in Works) {
                DateTime date = i.WorkDate;
                string content = i.Content;
                string leaderAlias = RoleNameType.Leader.GetEnumStringValue();
                string managerAlias = RoleNameType.Manager.GetEnumStringValue();

                string leaderName = i.GetName(RoleNameType.Leader);
                string manager = i.GetName(RoleNameType.Manager);
                string exMember = null;
                string member = "";

                var mem_involve = i.WorkInvolve.Where(wi => wi.Role.RoleName != leaderAlias && wi.Role.RoleName != managerAlias);
                foreach (var j in mem_involve) {
                    member += j.Employee.Name + "、";
                }
                if (member != "") {
                    member = member.Substring(0, member.Length - 1);
                }

                Dictionary<string, string> outsiders =i.GetOutsider();
                string key = RoleNameType.Leader.ToString();
                if (leaderName == null && outsiders != null && outsiders.Keys.Contains(key)) {
                    leaderName = outsiders[key];
                }
                key = RoleNameType.Manager.ToString();
                if (manager == null && outsiders != null && outsiders.Keys.Contains(key)) {
                    manager = outsiders[key];
                }
                key = RoleNameType.ExMember.ToString();
                if (outsiders != null && outsiders.Keys.Contains(key)) {
                    exMember = outsiders[key];
                }

                DailyWorkModel di = new DailyWorkModel();
                di.Id = i.Id;
                di.Date = date;
                di.Substation = i.Substations.SubstationName;
                di.Location = i.Substations.Location;
                di.WorkType = i.WorkType.Content;
                di.Content = content;
                di.Leader = leaderName;
                di.Manager = manager;
                di.Member = member;
                di.Voltage = i.Substations.Voltage;
                di.ExMember = exMember;
                di.ShortType = i.ShortType;

                workList.Add(di);

            }
            return workList;
        }
        
   
        public DataTable Build() {

        


            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Date");
            dt.Columns.Add("Substation");
            dt.Columns.Add("Location");
            dt.Columns.Add("WorkType");
            dt.Columns.Add("Content");
            dt.Columns.Add("Leader");
            dt.Columns.Add("Manager");
            dt.Columns.Add("Member");
            dt.Columns.Add("Voltage");
            dt.Columns.Add("ExMember");
            dt.Columns.Add("ShortType");
            

            foreach (var i in Works) {
                var dr = dt.NewRow();
                DateTime date = i.WorkDate;
                string content = i.Content;
                string leaderAlias = RoleNameType.Leader.GetEnumStringValue();
                string managerAlias = RoleNameType.Manager.GetEnumStringValue();

                string leaderName = i.GetName(RoleNameType.Leader);
                string manager = i.GetName(RoleNameType.Manager);
                string exMember = null;
                string member = "";

                var mem_involve = i.WorkInvolve.Where(wi => wi.Role.RoleName != leaderAlias && wi.Role.RoleName != managerAlias);
                foreach (var j in mem_involve) {
                    member += j.Employee.Name + "、";
                }
                if (member != "") {
                    member = member.Substring(0, member.Length - 1);
                }

                Dictionary<string, string> outsiders = i.GetOutsider();
                string key = RoleNameType.Leader.ToString();
                if (leaderName == null && outsiders != null && outsiders.Keys.Contains(key)) {
                    leaderName = outsiders[key];
                }
                key = RoleNameType.Manager.ToString();
                if (manager == null && outsiders != null && outsiders.Keys.Contains(key)) {
                    manager = outsiders[key];
                }
                key = RoleNameType.ExMember.ToString();
                if (outsiders != null && outsiders.Keys.Contains(key)) {
                    exMember = outsiders[key];
                }
                dr["Id"] = i.Id;
                dr["Date"] = date;
                dr["Substation"] = i.Substations.SubstationName;
                dr["Location"] = i.Substations.Location;
                dr["WorkType"] = i.WorkType.Content;
                dr["Content"] = content;
                dr["Leader"] = leaderName;
                dr["Manager"] = manager;
                dr["Member"] = member;
                dr["Voltage"] = i.Substations.Voltage;
                dr["ExMember"] = exMember;
                dr["ShortType"] = i.ShortType;

                dt.Rows.Add(dr);

            }

            return dt;
        }


    }
}
