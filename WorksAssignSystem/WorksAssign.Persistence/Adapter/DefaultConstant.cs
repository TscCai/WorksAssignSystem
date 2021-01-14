using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Persistence.Adapter
{
    public class DefaultConstant
    {
        public static string WorkType { get { return "出勤"; } }
        public static string WorkContent { get { return "出勤"; } }

        public static string RoleName { get{ return ""; } }

        public static double RoleWgt { get { return 1.0; } }

        public static string IndoorSymbol { get { return "√"; } }
        public static string OutdoorSymbol { get { return "现"; } }
        /// <summary>
        /// 公休
        /// </summary>
        public static string DayoffSymbol { get  { return "休"; } }

        public static string HolidayWithSalary { get { return "H"; } }
    }
}
