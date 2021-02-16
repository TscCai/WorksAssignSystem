/******************************************************************************
 * WorksAssign.Util.Export 工作安排 Excel导出功能组件
 * CopyRight (C) 2020-2021 TscCai.
 * E-Mail：caijiran@hotmail.com
 *
 * GitHub: https://github.com/TscCai/WorksAssignSystem
 *
 ******************************************************************************
 * 文件名称: BaseWorkPointExporter.cs
 * 文件说明: 月度考勤表导出
 * 当前版本: 
 * 创建日期: 2021-02-03
 * 2021-02-03: 增加文件说明
 * 2021-02-09：增加功能扩展方法
 * 2021-02-16：更名为BaseWorkPointExporter.cs
******************************************************************************/
using System;
using System.Collections.Generic;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WorksAssign.Persistence;
using WorksAssign.Util.Export.DataModel;

namespace WorksAssign.Util.Export
{
    public class BaseWorkPointExporter : BaseExpoter, IDisposable
    {


        /// <summary>
        /// 表格所统计的月份，从给定的日期开始
        /// </summary>
        public DateTime StaticsMonth { get; set; }

        List<WorkPointModel> WorkPoints;

        /// <summary>
        /// 汇总页表格
        /// </summary>
        ISheet SummarySheet;


        /// <summary>
        /// 初始化资源，创建汇总表表头、默认日期格式
        /// </summary>
        /// <param name="staticsTime">统计时间</param>
        public BaseWorkPointExporter(DateTime staticsTime, List<WorkPointModel> wpm) {
            Workbook = new XSSFWorkbook();
            StaticsMonth = staticsTime;
            WorkPoints = wpm;
            CreateSummarySheetHeader("当月绩效表");
            Init();

        }

        /// <summary>
        /// 填充表格，实现以下功能：
        /// 1. 遍历属性WorkPoints，逐个成员填充个人表格；
        /// 2. 在汇总页填写总分数。 
        /// 若需完全重写表格填充的逻辑则覆盖本方法，若需追加，则先调用父类实现
        /// </summary>
        protected override void FillTable() {
            foreach (var i in WorkPoints) {
                ISheet personal_sheet = CreatePersonalSheet(i.EmloyeeName);
                foreach (var j in i.DailyWorks) {
                    IRow row = FillPersonalSheetRow(personal_sheet, j, i);
                }
                // 在汇总表中写入总分
                IRow sum_row = FillSummarySheetRow(i);
            }
        }
      

        /// <summary>
        /// 汇总页表格填充，实现以下功能：
        /// 1. 写入成员姓名及总分
        /// 若需追加汇总页数据字段，则覆盖本方法，并首先调用父类实现，并应同时覆盖CreateSummarySheetHeader方法
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        protected virtual IRow FillSummarySheetRow(WorkPointModel i) {
            IRow sum_row = Workbook.GetSheet("当月绩效表").CreateRow(SummarySheet.LastRowNum + 1);
            sum_row.CreateCell(0).SetCellValue(i.EmloyeeName);
            sum_row.CreateCell(sum_row.LastCellNum).SetCellValue(i.TotalPoints());
            return sum_row;

        }

        /// <summary>
        /// 创建汇总表表头，共写入3个字段：姓名、当月工分、当月绩效；
        /// 若新增字段只能追加（不支持插入），应覆盖本方法，并首先调用父类实现
        /// </summary>
        /// <param name="name">汇总表名称</param>
        /// <returns></returns>
        protected virtual IRow CreateSummarySheetHeader(string name) {
            SummarySheet = Workbook.CreateSheet(name);
            int row_sheet_sum = 0;
            IRow hdr = SummarySheet.CreateRow(row_sheet_sum);
            row_sheet_sum++;
            hdr.CreateCell(0).SetCellValue("姓名");
            hdr.CreateCell(hdr.LastCellNum).SetCellValue("当月工分");
            hdr.CreateCell(hdr.LastCellNum).SetCellValue("当月绩效");
            return hdr;
        }

        /// <summary>
        /// 创建1个以人员姓名命名的工作表(WorkSheet)，并初始化表头信息
        /// 若需新增个人页字段表头，应覆盖本方法
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual ISheet CreatePersonalSheet(string name) {
            ISheet result = Workbook.CreateSheet(name);
            result.SetColumnWidth(0, 12 * 256);
            // 首行(row = 0)留白，从row1开始
            IRow r = result.CreateRow(1);
            r.CreateCell(0).SetCellValue("时间");   //0
            r.CreateCell(r.LastCellNum).SetCellValue("工作内容");
            r.CreateCell(r.LastCellNum).SetCellValue("工作类别");
            r.CreateCell(r.LastCellNum).SetCellValue("类别系数");
            r.CreateCell(r.LastCellNum).SetCellValue("角色");
            r.CreateCell(r.LastCellNum).SetCellValue("角色系数");
            return result;
        }

        /// <summary>
        /// 写入个人页详细信息，若需增加字段应覆盖本方法
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="pointTable"></param>
        /// <param name="wp"></param>
        /// <returns></returns>
        protected virtual IRow FillPersonalSheetRow(ISheet sheet, V_AllPoints pointTable, WorkPointModel wp) {
            IRow row = FillPersonalSheetRow(sheet, pointTable.WorkDate, pointTable.WorkContent, pointTable.WorkType,
               pointTable.TypeWgt, pointTable.RoleName, pointTable.RoleWgt);
            return row;
        }


        IRow FillPersonalSheetRow(ISheet sheet, DateTime date, string workContent, string workType, double typeWgt, string role, double roleWgt) {
            IRow r = sheet.CreateRow(sheet.LastRowNum + 1);
            r.CreateCell(0).SetCellValue(date);
            r.GetCell(0).CellStyle = DefaultDateStyle;
            r.CreateCell(r.LastCellNum).SetCellValue(workContent);
            r.CreateCell(r.LastCellNum).SetCellValue(workType);
            r.CreateCell(r.LastCellNum).SetCellValue(typeWgt);
            r.CreateCell(r.LastCellNum).SetCellValue(role);
            r.CreateCell(r.LastCellNum).SetCellValue(roleWgt);
            return r;
        }

        public new void Dispose() {
            base.Dispose();
        }
    }

}
