using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Persistence
{
    public class DbDefaultValues
    {
        /// <summary>
        /// 默认工作类型：出勤
        /// </summary>
        public static string WorkType { get { return "出勤"; } }

        /// <summary>
        /// 默认工作内容：出勤
        /// </summary>
        public static string WorkContent { get { return "出勤"; } }

        /// <summary>
        /// 默认角色名称：
        /// </summary>
        public static string RoleName { get{ return ""; } }

        /// <summary>
        /// 默认角色权重：1.0
        /// </summary>
        public static double RoleWgt { get { return 1.0; } }
        /*
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
        public static string DayoffSymbol { get  { return "休"; } }

        /// <summary>
        /// 用于月度考勤的默认带薪年休符号：H
        /// </summary>
        public static string PaidHoliday { get { return "H"; } }
        */
    }
}
