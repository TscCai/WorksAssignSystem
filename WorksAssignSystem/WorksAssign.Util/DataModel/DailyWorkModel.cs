/******************************************************************************
 * WorksAssign.Util.DataModel 工作安排业务功能组件
 * CopyRight (C) 2020-2021 TscCai.
 * E-Mail：caijiran@hotmail.com
 *
 * GitHub: https://github.com/TscCai/WorksAssignSystem
 *
 ******************************************************************************
 * 文件名称: DailyWorkModel.cs
 * 文件说明: 传递每日工作安排UI显示、导出Excel的数据模型
 * 当前版本: 
 * 创建日期: 2021-02-03
 * 2021-02-03: 增加文件说明
******************************************************************************/
using System;

namespace WorksAssign.Util.DataModel
{
    public class DailyWorkModel
    {
        /// <summary>
        /// 工作Id，WorkContent.Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 工作时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 变电站名称
        /// </summary>
        public string Substation { get; set; }

        /// <summary>
        /// 工作短类型
        /// </summary>
        public string ShortType { get; set; }

        /// <summary>
        /// 片区
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 电压等级
        /// </summary>
        public long Voltage { get; set; }

        /// <summary>
        /// 工作类型（详细）
        /// </summary>
        public string WorkType { get; set; }

        /// <summary>
        /// 工作内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 工作负责人
        /// </summary>
        public string Leader { get; set; }

        /// <summary>
        /// 工作班成员
        /// </summary>
        public string Member { get; set; }

        /// <summary>
        /// 管理人员
        /// </summary>
        public string Manager { get; set; }

        /// <summary>
        /// 外协人员，外部的负责人、管理人员均在此字段以"|"分割，
        /// 如："负责人：张三|管理人员：李四|外协人员：王五"
        /// </summary>
        public string ExMember { get; set; }
    }
}
