﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Util {

    public class CommonUtil {
        public static bool IsHoliday(DateTime dt, IQueryable<ExWorkdays> exDays)
        {
            bool result = false;
            var tmp = exDays.SingleOrDefault(w => w.Date == dt);
            if (tmp != null) {
                if (tmp.IsHoliday) {
                    return true;
                }
            }
            else {
                if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday) {
                    return true;
                }
            }
            return result;

        }

        public static bool IsWorkday(DateTime dt, IQueryable<ExWorkdays> exDays)
        {
            bool result = false;
            var tmp = exDays.SingleOrDefault(w => w.Date == dt);
            if (tmp != null) {
                if (tmp.IsWorkday) {
                    return true;
                }
            }
            else {
                if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday) {
                    return true;
                }
            }
            return result;
        }

        public static bool IsDayOff(DateTime dt, long id, IQueryable<DayOff> offDays)
        {
            var tmp = offDays.SingleOrDefault(o => o.Date == dt && o.EID == id);
            if (tmp != null) {
                return true;
            }
            else {
                return false;
            }
        }

        public static double CalcWorkPoints(double typeWgt, double roleWgt)
        {
            return typeWgt * roleWgt;
        }
    }


}
