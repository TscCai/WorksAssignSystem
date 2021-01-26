/******************************************************************************
 * WorksAssign.Util 工作安排业务逻辑组件
 * CopyRight (C) 2020-2021 TscCai.
 * E-Mail：caijiran@hotmail.com
 *
 * GitHub: https://github.com/TscCai/WorksAssignSystem
 *
 ******************************************************************************
 * 文件名称: MonthlyAttendanceModel.cs
 * 文件说明: 月度出勤数据模型
 * 当前版本: 
 * 创建日期: 2020-11-28
 * 2020-01-23: 增加文件说明
******************************************************************************/
using System;
using System.Collections.Generic;

namespace WorksAssign.Util.DataModel
{
    public class MonthlyAttendanceModel {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string Department { get { return "变电二次班"; } }

        /// <summary>
        /// 统计时间
        /// </summary>
        public DateTime StaticsTime { get; private set; }

        /// <summary>
        /// 成员名称
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// 成员Id（数据库中）
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// 出勤情况符号，按1~31（或30,29,28）号排列
        /// Key: 日期1~31（或30,29,28）
        /// Value: 出勤情况符号，用于填充出勤统计表格
        /// </summary>
        public Dictionary<int,string> AttendanceFlag { get; set; }

        /// <summary>
        /// 构造方法，实例化AttendanceFlag字典
        /// </summary>
        public MonthlyAttendanceModel() {
            AttendanceFlag = new Dictionary<int, string>();
        }
    }
}
