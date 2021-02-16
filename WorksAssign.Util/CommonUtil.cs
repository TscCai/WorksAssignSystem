using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorksAssign.Persistence;

namespace WorksAssign.Util
{

    public class CommonUtil
    {
        /*
        /// <summary>
        /// 判断是否为假期
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="exDays"></param>
        /// <returns></returns>
        public static bool IsHoliday(DateTime dt, IQueryable<ExWorkdays> exDays) {
            bool result = false;
            var tmp = exDays.AsEnumerable().SingleOrDefault(w => w.Date.Date == dt);
            if (tmp != null && tmp.IsHoliday) {
                return true;
            }
            else if (tmp != null && tmp.IsWorkday) {
                return false;
            }
            else if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday) {
                return true;
            }
            return result;

        }

        /// <summary>
        /// 判断是否为工作日
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="exDays"></param>
        /// <returns></returns>
        public static bool IsWorkday(DateTime dt, IQueryable<ExWorkdays> exDays) {
            bool result = false;
            var tmp = exDays.AsEnumerable().SingleOrDefault(w => w.Date.Date == dt.Date);
            if (tmp != null && tmp.IsWorkday) {
                return true;
            }
            else if (tmp != null && tmp.IsHoliday) {
                return false;
            }
            else if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday) {
                return true;
            }
            return result;
        }

        public static bool IsDayOff(DateTime dt, long id, IQueryable<DayOff> offDays) {
            var tmp = offDays.SingleOrDefault(o => o.Date == dt && o.EmployeeId == id);
            if (tmp != null) {
                return true;
            }
            else {
                return false;
            }
        }
        */
    }


}
