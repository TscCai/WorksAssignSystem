using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorksAssign.Persistence;
using WorksAssign.Util.Export.DataModel;
using WorksAssign.Util.Formula;

namespace WorksAssign.Util.Export.DataBuilder
{
    public class WorkPointBuilder : BaseDataModelBuilder<WorkPointModel>
    {
        public DateTime BeginOfMonth { get; private set; }
        public WorkPointBuilder(DateTime beginOfMonth) {
            BeginOfMonth = beginOfMonth;
        }


        public override List<WorkPointModel> BuildData() {
            DateTime endOfMonth = BeginOfMonth.AddMonths(1).AddDays(-1);
            List<WorkPointModel> result = new List<WorkPointModel>();
            hwd = new HolidayWorkdayDiscriminator(BeginOfMonth.Year);
            using (db = new DbAgent()) {
                var allEmployees = db.GetEmployee(false);
                foreach (Employee emp in allEmployees) {

                    WorkPointModel wpm = new WorkPointModel();
                    wpm.EmloyeeName = emp.Name;
                    wpm.EmployeeId = emp.Id;
                    wpm.IsCCP = emp.IsCCP;
                    wpm.JoinDate = emp.JoinDate;
                    IQueryable<V_AllPoints> personal_points = db.GetWorkPoint(wpm.EmployeeId, BeginOfMonth, endOfMonth);

                    wpm.DailyWorks = CreateDailyWorks(personal_points, BeginOfMonth, endOfMonth);
                    FormulaManager.FormulaManagerValidVariable validFlag;
                    wpm.DailyPoints = CreateDailyPoints(wpm.DailyWorks, BeginOfMonth, wpm.JoinDate, out validFlag);

                    wpm.ValidVarible = validFlag;
                    result.Add(wpm);
                }
            }
            return result;
        }

        List<V_AllPoints> CreateDailyWorks(IQueryable<V_AllPoints> personalPoint, DateTime beginOfMonth, DateTime endOfMonth) {
            List<V_AllPoints> result = new List<V_AllPoints>();
            for (int day = beginOfMonth.Day; day <= endOfMonth.Day; day++) {
                DateTime datePointer = new DateTime(beginOfMonth.Year, beginOfMonth.Month, day);

                var thisDayWork = personalPoint.AsEnumerable().Where(p => p.WorkDate.Date == datePointer);
                if (thisDayWork != null && thisDayWork.Count() > 0) {
                    foreach (var item in thisDayWork) {
                        result.Add(item);
                    }
                }
                else {
                    V_AllPoints item = null;
                    if (hwd.IsWorkday(datePointer)) {
                        item = WorkSheetDefaultValues.PersonalWorkPoint(datePointer);
                    }
                    else if (hwd.IsHoliday(datePointer)) {
                        item = new V_AllPoints();
                        item.WorkContent = "休息";
                        item.WorkDate = datePointer;
                        item.RoleWgt = 0;
                        item.TypeWgt = 0;
                    }

                    result.Add(item);
                }

            }
            return result;
        }

        /// <summary>
        /// 必须在db作用域范围内使用
        /// </summary>
        /// <param name="works"></param>
        /// <param name=""></param>
        /// <returns></returns>
        List<double> CreateDailyPoints(List<V_AllPoints> works, DateTime staticsTime, DateTime joinDate, out FormulaManager.FormulaManagerValidVariable validFlag) {
            List<double> result = new List<double>();
            FormulaManager fm = new FormulaManager(staticsTime.Year, joinDate.Year);
            string exp1 = db.GetFormula("Seniority");
            string exp2 = db.GetFormula("DailyPoint");
            validFlag = fm.CreateValidVariableFlag(exp1) | fm.CreateValidVariableFlag(exp2);
            // 若使用简单公式计算，可注销下一行，并在数据库中编写公式
            exp1 = null;
            fm.SeniorityWgt = fm.Seniority(exp1);

            foreach (var w in works) {
                fm.TypeWgt = w.TypeWgt;
                fm.RoleWgt = w.RoleWgt;    
                double point = fm.DailyPoint(exp2);
                result.Add(point);
            }
            return result;
        }


    }
}
