﻿/******************************************************************************
 * WorksAssign.Util 工作安排业务逻辑组件
 * CopyRight (C) 2020-2021 TscCai.
 * E-Mail：caijiran@hotmail.com
 *
 * GitHub: https://github.com/TscCai/WorksAssignSystem
 *
 ******************************************************************************
 * 文件名称: WorkPointModel.cs
 * 文件说明: 传递月度绩效导出Excel的数据模型
 * 当前版本: 
 * 创建日期: 2021-02-03
 * 2021-02-03: 增加文件说明
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorksAssign.Persistence;

namespace WorksAssign.Util.Export.DataModel
{
    public class WorkPointModel {
        /// <summary>
        /// 人员姓名
        /// </summary>
        public string EmloyeeName { get; set; }

        /// <summary>
        /// 人员Id
        /// </summary>
        public long EmployeeId { get; set; }

        public DateTime JoinDate { get; set; }

        public bool IsCCP { get; set; }

        public Formula.FormulaManager.FormulaManagerValidVariable ValidVarible { get; set; }

        /// <summary>
        /// 每日工作
        /// </summary>
        public List<V_AllPoints> DailyWorks{get;set;}

        public List<double> DailyPoints { get; set; }


        public double TotalPoints() {
            double result = 0;
            foreach(var i in DailyPoints) {
                result += i;
            }
            return result;
        }
    }

 

}
