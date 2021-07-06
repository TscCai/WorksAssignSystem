/******************************************************************************
 * WorksAssign.Persistence 工作安排数据库访问组件
 * CopyRight (C) 2020-2021 TscCai.
 * E-Mail：caijiran@hotmail.com
 *
 * GitHub: https://github.com/TscCai/WorksAssignSystem
 *
 ******************************************************************************
 * 文件名称: HolidayWorkdayDiscriminator.cs
 * 文件说明: 假日及工作日判别器
 * 当前版本: 
 * 创建日期: 2021-02-03
 * 2021-02-03: 增加文件说明
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Persistence
{
    public class HolidayWorkdayDiscriminator
    {

        public List<ExWorkdays> HolidaysWorkdays { get; private set; }
        public HolidayWorkdayDiscriminator(List<ExWorkdays> days) {
            HolidaysWorkdays = days;
        }

        public HolidayWorkdayDiscriminator(int year) {
            using (var db = new WasDbAgent()) {
                HolidaysWorkdays = db.GetHolidaysWorkdays(year).ToList();
            }
        }


        /// <summary>
        /// 判断是否为假期
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="exDays"></param>
        /// <returns></returns>
        public bool IsHoliday(DateTime dt) {
            bool result = false;
            var tmp = HolidaysWorkdays.SingleOrDefault(w => w.Date.Date == dt);
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
        public bool IsWorkday(DateTime dt) {
            bool result = false;
            var tmp = HolidaysWorkdays.SingleOrDefault(w => w.Date.Date == dt.Date);
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

        public bool IsDayOff(DateTime dt, long id, IQueryable<DayOff> offDays) {
            var tmp = offDays.SingleOrDefault(o => o.Date == dt && o.EmployeeId == id);
            if (tmp != null) {
                return true;
            }
            else {
                return false;
            }
        }


    }
}
