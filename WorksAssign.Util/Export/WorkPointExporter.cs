/******************************************************************************
 * WorksAssign.Util.Export 工作安排 Excel导出功能组件
 * CopyRight (C) 2020-2021 TscCai.
 * E-Mail：caijiran@hotmail.com
 *
 * GitHub: https://github.com/TscCai/WorksAssignSystem
 *
 ******************************************************************************
 * 文件名称: WorkPointExporter.cs
 * 文件说明: 月度考勤表导出
 * 当前版本: 
 * 创建日期: 2021-02-16
 * 2021-02-16: 增加文件说明
******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using WorksAssign.Persistence;
using WorksAssign.Util.Export.DataModel;

namespace WorksAssign.Util.Export
{
    public class WorkPointExporter : BaseWorkPointExporter
    {
        public WorkPointExporter(DateTime staticsTime, List<WorkPointModel> wpm) : base(staticsTime, wpm) {
        }

        protected override IRow FillPersonalSheetRow(ISheet sheet, V_AllPoints pointTable, WorkPointModel wp) {
            IRow row =  base.FillPersonalSheetRow(sheet, pointTable, wp);
            
            return row;
        }

        protected override ISheet CreatePersonalSheet(string name) {
            ISheet sheet = base.CreatePersonalSheet(name);
            IRow row = sheet.GetRow(sheet.LastRowNum);
            return sheet;
        }
    }
}
