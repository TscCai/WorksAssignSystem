using System;
using System.Collections.Generic;
using System.Linq;
using Sunny.UI;
using System.Configuration;
using WorksAssign.Persistence;
using WorksAssign.Util.DataModel;
using WorksAssign.Util;
using WorksAssign.Util.Export;
using System.Text;

namespace WorksAssign.Pages
{
    public partial class AttendanceManage : UIPage
    {
        /// <summary>
        /// 数据库访问器
        /// </summary>
        DbAgent db;

        /// <summary>
        /// 法定假日调休及工作日判别器
        /// </summary>
        HolidayWorkdayDiscriminator hwd;


        public AttendanceManage() {
            InitializeComponent();
            dpk_MonthlyAttendance.Value = DateTime.Now.Date;
        }


        /// <summary>
        /// 出勤表导出按钮响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ExportMonthlyAttendance_Click(object sender, EventArgs e) {
            string template = ConfigurationManager.AppSettings["MonthlyAttendanceTemplatePath"];
            using (MonthlyAttendance ma = new MonthlyAttendance(template)) {
                DateTime date = dpk_MonthlyAttendance.Value;
                hwd = new HolidayWorkdayDiscriminator(date.Year);
                // 创建目录，若存在则不会创建
                DirEx.CreateDir(ConfigurationManager.AppSettings["ExportFilePath"]);
                string filename = ConfigurationManager.AppSettings["ExportFilePath"] + date.ToString("[yyyy.MM]") + "考勤统计-二次班.xlsx";
                List<MonthlyAttendanceModel> list = CreateMonthlyAttendanceData(date);
                ma.ExportExcel(filename, date, list);
            }
            this.ShowSuccessDialog("月度考勤表导出成功。");
        }

        /// <summary>
        /// 绩效表导出按钮响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ExportWorkPoints_Click(object sender, EventArgs e) {
            DateTime date = dpk_MonthlyAttendance.Value.BeginOfMonth();
            hwd = new HolidayWorkdayDiscriminator(date.Year);
            string filename = "Export/" + date.ToString("[yyyy.MM]") + "绩效表-二次班.xlsx";
            WorkPoint wp = new WorkPoint();
            wp.ExportExcel(filename, date);
            this.ShowSuccessDialog("月度绩效表导出成功。");
        }

        /// <summary>
        /// 生成全体成员的月度考勤数据模型
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        List<MonthlyAttendanceModel> CreateMonthlyAttendanceData(DateTime date) {
            List<MonthlyAttendanceModel> result = new List<MonthlyAttendanceModel>();
            using (db = new DbAgent()) {
                var employees = db.GetEmployee(false);
                foreach (var e in employees) {
                    result.Add(CreatePersonalData(date, e));
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
        MonthlyAttendanceModel CreatePersonalData(DateTime date, Employee employee) {
            MonthlyAttendanceModel result = new MonthlyAttendanceModel();
            result.EmployeeId = employee.Id;
            result.EmployeeName = employee.Name;
            result.AttendanceFlag = new Dictionary<int, string>();
            var wi = db.GetWorkInvolve(date.BeginOfMonth(), date.EndOfMonth(), employee.Id);
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
            for (int day = date.BeginOfMonth().Day; day <= date.EndOfMonth().Day; day++) {
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
