using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorksAssign.Persistence;
using WorksAssign.Util.Export.DataModel;

namespace WorksAssign.Util.Export.DataBuilder
{
    public class MonthlyAttendanceBuilder :BaseDataModelBuilder<MonthlyAttendanceModel>
    {
        DateTime Date;
        public MonthlyAttendanceBuilder(DateTime date) {
            Date = date;
        }

        /// <summary>
        /// 生成全体成员的月度考勤数据模型
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public override List<MonthlyAttendanceModel> BuildData() {
            {
                List<MonthlyAttendanceModel> result = new List<MonthlyAttendanceModel>();
                using (db = new WasDbAgent()) {
                    var employees = db.GetEmployee(false);
                    hwd = new HolidayWorkdayDiscriminator(Date.Year);
                    foreach (var e in employees) {
                        DateTime beginOfMonth, endOfMonth;
                        beginOfMonth = new DateTime(Date.Year, Date.Month, 1);
                        endOfMonth = beginOfMonth.AddMonths(1).AddDays(-1);
                        var wi = db.GetWorkInvolve(beginOfMonth, endOfMonth, e.Id);
                        result.Add(CreatePersonalData(Date, e, wi));
                    }
                }

                return result;
            }

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

    }


}
