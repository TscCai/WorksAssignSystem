using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Util.Export
{
    public class WorkSheetDefaultValues
    {
        /// <summary>
        /// 用于月度考勤的默认内勤工作符号：√
        /// </summary>
        public static string IndoorSymbol { get { return "√"; } }

        /// <summary>
        /// 用于月度考勤的默认外勤工作符号：现
        /// </summary>
        public static string OutdoorSymbol { get { return "现"; } }
        /// <summary>
        /// 用于月度考勤的默认公休（法定假日+周末）符号：休
        /// </summary>
        public static string DayoffSymbol { get { return "休"; } }

        /// <summary>
        /// 用于月度考勤的默认带薪年休符号：H
        /// </summary>
        public static string PaidHolidaySymbol { get { return "H"; } }
    }
}
