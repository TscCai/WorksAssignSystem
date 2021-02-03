using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorksAssign.Persistence;
using WorksAssign.Persistence.Adapter;
using WorksAssign.Util.Export;

namespace WorksAssign.Util.DataModel
{
    public class DataModelBuilder
    {
        DbAgent db;
        HolidayWorkdayDiscriminator hwd;
        
        public List<DailyWorkModel> CreateDailyWorkData(IQueryable<WorkContent> works) {
            var workList = new List<DailyWorkModel>();
            foreach (var i in works) {
                DateTime date = i.WorkDate;
                string content = i.Content;
                string leaderAlias = RoleNameType.Leader.GetEnumStringValue();
                string managerAlias = RoleNameType.Manager.GetEnumStringValue();

                string leaderName = ViewDataAdapter.GetName(i, RoleNameType.Leader);
                string manager = ViewDataAdapter.GetName(i, RoleNameType.Manager);
                string exMember = null;
                string member = "";

                var mem_involve = i.WorkInvolve.Where(wi => wi.Role.RoleName != leaderAlias && wi.Role.RoleName != managerAlias);
                foreach (var j in mem_involve) {
                    member += j.Employee.Name + "、";
                }
                if (member != "") {
                    member = member.Substring(0, member.Length - 1);
                }

                Dictionary<string, string> outsiders = ViewDataAdapter.GetOutsider(i);
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

        /// <summary>
        /// 生成全体成员的月度考勤数据模型
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<MonthlyAttendanceModel> CreateMonthlyAttendanceData(DateTime date) {
            List<MonthlyAttendanceModel> result = new List<MonthlyAttendanceModel>();
            using (db = new DbAgent()) {
                var employees = db.GetEmployee(false);
                hwd = new HolidayWorkdayDiscriminator(date.Year);
                foreach (var e in employees) {
                    DateTime beginOfMonth, endOfMonth;
                    beginOfMonth = new DateTime(date.Year, date.Month, 1);
                    endOfMonth = beginOfMonth.AddMonths(1).AddDays(-1);
                    var wi = db.GetWorkInvolve(beginOfMonth, endOfMonth, e.Id);
                    result.Add(CreatePersonalData(date, e, wi));
                }
            }

            return result;
        }

        /// <summary>
        /// 按月份生成单个成员的月度考勤数据模型
        /// </summary>
        /// <param name="date">目标月份，其中Day属性并不被使用</param>
        /// <param name="employee">成员实例</param>
        /// <returns>该月份该成员的出勤数据模型</returns>
        MonthlyAttendanceModel CreatePersonalData(DateTime date, Employee employee, IQueryable<WorkInvolve> wi) {

            MonthlyAttendanceModel result = new MonthlyAttendanceModel();
            result.EmployeeId = employee.Id;
            result.EmployeeName = employee.Name;
            result.AttendanceFlag = new Dictionary<int, string>();

            DateTime beginOfMonth, endOfMonth;
            beginOfMonth = new DateTime(date.Year, date.Month, 1);
            endOfMonth = beginOfMonth.AddMonths(1).AddDays(-1);

            foreach (var i in wi) {
                int key = i.WorkContent.WorkDate.Day;
                string value = i.WorkContent.WorkType.IsOutdoor == true ? WorkSheetDefaultValues.OutdoorSymbol : WorkSheetDefaultValues.IndoorSymbol;
                if (result.AttendanceFlag.ContainsKey(key)) {
                    if (result.AttendanceFlag[key] == WorkSheetDefaultValues.OutdoorSymbol && value == WorkSheetDefaultValues.IndoorSymbol) {
                        continue;
                    }
                    else {
                        result.AttendanceFlag[key] = value;
                    }
                }
                else {
                    result.AttendanceFlag[key] = value;
                }
            }

            // 对未外勤工作的日期进行填充，默认为出勤
            for (int day = beginOfMonth.Day; day <= endOfMonth.Day; day++) {
                if (!result.AttendanceFlag.ContainsKey(day)) {
                    DateTime thisDay = new DateTime(date.Year, date.Month, day);
                    if (hwd.IsWorkday(thisDay)) {
                        result.AttendanceFlag[day] = WorkSheetDefaultValues.IndoorSymbol;
                    }
                    else if (hwd.IsHoliday(thisDay)) {
                        result.AttendanceFlag[day] = WorkSheetDefaultValues.DayoffSymbol;
                    }
                }
            }
            return result;
        }


        public List<WorkPointModel> CreateWorkPointData(DateTime beginOfMonth) {
            DateTime endOfMonth = beginOfMonth.AddMonths(1).AddDays(-1);
            List<WorkPointModel> result = new List<WorkPointModel>();
            using (var db = new DbAgent()) {
                var allEmployees = db.GetEmployee(false);
                foreach (Employee emp in allEmployees) {
                    WorkPointModel wpm = new WorkPointModel();
                    wpm.EmloyeeName = emp.Name;
                    wpm.EmployeeId = emp.Id;
                    IQueryable<V_AllPoints> personal_points = db.GetWorkPoint(wpm.EmployeeId, beginOfMonth, endOfMonth);

                    wpm.MonthWorkPoints = CreatePersonalWorkPoint(personal_points, beginOfMonth, endOfMonth);

                    result.Add(wpm);
                }
            }
            return result;
        }

        List<DailyWorkPointModel> CreatePersonalWorkPoint(IQueryable<V_AllPoints> personalPoint, DateTime beginOfMonth, DateTime endOfMonth) {
            List<DailyWorkPointModel> result = new List<DailyWorkPointModel>();
            for (int i = beginOfMonth.Day; i<endOfMonth.Day; i++) {
                DailyWorkPointModel item = new DailyWorkPointModel();
                var list = personalPoint.ToList();
                
            }

            result.Sort();

            return result;
        }


    }
}
