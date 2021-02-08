using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorksAssign.Persistence;

namespace WorksAssign.Util.Export.DataModel
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
            using (var db = new DbAgent()) {
                var allEmployees = db.GetEmployee(false);
                foreach (Employee emp in allEmployees) {
                    WorkPointModel wpm = new WorkPointModel();
                    wpm.EmloyeeName = emp.Name;
                    wpm.EmployeeId = emp.Id;
                    IQueryable<V_AllPoints> personal_points = db.GetWorkPoint(wpm.EmployeeId, BeginOfMonth, endOfMonth);

                    wpm.MonthWorkPoints = CreatePersonalWorkPoint(personal_points, BeginOfMonth, endOfMonth);

                    result.Add(wpm);
                }
            }
            return result;
        }

        List<V_AllPoints> CreatePersonalWorkPoint(IQueryable<V_AllPoints> personalPoint, DateTime beginOfMonth, DateTime endOfMonth) {
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




    }
}
