/******************************************************************************
 * WorksAssign.Util.Export 工作安排 Excel导出功能组件
 * CopyRight (C) 2020-2021 TscCai.
 * E-Mail：caijiran@hotmail.com
 *
 * GitHub: https://github.com/TscCai/WorksAssignSystem
 *
 ******************************************************************************
 * 文件名称: WorkSheetDefaultValues.cs
 * 文件说明: 工作表默认值
 * 当前版本: 
 * 创建日期: 2021-02-03
 * 2021-02-03: 增加文件说明
******************************************************************************/

using System;
using WorksAssign.Persistence;

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


        /// <summary>
        /// 用于绩效表的默认工作类型：出勤
        /// </summary>
        public static string WorkType { get { return "出勤"; } }

        /// <summary>
        /// 用于绩效表的默认工作内容：出勤
        /// </summary>
        public static string WorkContent { get { return "出勤"; } }

        /// <summary>
        /// 用于绩效表的默认角色名称：
        /// </summary>
        public static string RoleName { get { return ""; } }

        /// <summary>
        /// 用于绩效表的默认角色权重：1.0
        /// </summary>
        public static double RoleWgt { get { return 1.0; } }

        /// <summary>
        /// 用于绩效表的默认工作内容的权重：1.0
        /// </summary>
        public static double TypeWgt { get { return 0.6; } }


        public static V_AllPoints PersonalWorkPoint(DateTime date) {
            V_AllPoints result = new V_AllPoints();
            result.WorkContent = WorkSheetDefaultValues.WorkContent;
            result.WorkType = WorkSheetDefaultValues.WorkType;
            result.TypeWgt = WorkSheetDefaultValues.TypeWgt;
            result.RoleName = WorkSheetDefaultValues.RoleName;
            result.RoleWgt = WorkSheetDefaultValues.RoleWgt;
            result.WorkDate = date;
            return result;
        }


    }
}
