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
using WorksAssign.Util.DataModel;
using WorksAssign.Persistence.Adapter;
using WorksAssign.Util;
using WorksAssign.Util.Export;

namespace WorksAssign.Pages
{
    public partial class AttendanceManage : UIPage
    {
        DbAgent db;
        IQueryable<ExWorkdays> holidaysWorkdays;
        public AttendanceManage() {
            InitializeComponent();
            dpk_MonthlyAttendance.Value = DateTime.Now.Date;
        }

        private void btn_ExportMonthlyAttendance_Click(object sender, EventArgs e) {
            string template = "/Template/monthly_attendance_template.xlsx";
            using (MonthlyAttendance ma = new MonthlyAttendance(template)) {
                DateTime date = dpk_MonthlyAttendance.Value;
                string filename = "/Export/[" + date.ToString("yyyy.MM") + "]考勤统计-二次班";
                List<MonthlyAttendanceModel> list = CreateMonthlyAttendanceData(date);
                ma.ExportExcel(filename, date, list);
            }
            this.ShowSuccessDialog("月度考勤表导出成功。");
        }

        List<MonthlyAttendanceModel> CreateMonthlyAttendanceData(DateTime date) {
            List<MonthlyAttendanceModel> result = new List<MonthlyAttendanceModel>();
            using (db = new DbAgent()) {
                holidaysWorkdays = db.GetHolidaysWorkdays(date.Year);
                var employees = db.GetEmployee();
                foreach (var e in employees) {
                    result.Add(CreatePersonalData(date, e));
                }
            }
            return result;
        }

        MonthlyAttendanceModel CreatePersonalData(DateTime date, Employee employee) {
            MonthlyAttendanceModel result = new MonthlyAttendanceModel();
            result.EmployeeId = employee.Id;
            result.EmployeeName = employee.Name;
            result.AttendanceFlag = new Dictionary<int, string>();
            var wi = db.GetWorkInvolve(date.BeginOfMonth(), date.EndOfMonth(), employee.Id);
            foreach (var i in wi) {
                int key = i.WorkContent.WorkDate.Day;
                string value = i.WorkContent.WorkType.IsOutdoor == true ? DefaultConstant.OutdoorSymbol : DefaultConstant.IndoorSymbol;
                if (result.AttendanceFlag.ContainsKey(key)) {
                    if (result.AttendanceFlag[key] == DefaultConstant.OutdoorSymbol && value == DefaultConstant.IndoorSymbol) {
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

            for (int day = date.BeginOfMonth().Day; day <= date.EndOfMonth().Day; day++) {
                if (!result.AttendanceFlag.ContainsKey(day) && CommonUtil.IsWorkday(new DateTime(date.Year, date.Month, day), holidaysWorkdays)) {
                    result.AttendanceFlag[day] = DefaultConstant.IndoorSymbol;
                }
            }


            return result;
        }
    }
}
