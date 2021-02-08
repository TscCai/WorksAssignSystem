using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WorksAssign.Persistence;
using WorksAssign.Util.Export.DataModel;

namespace WorksAssign.Util.Export
{
    public class WorkPoint : GenericExpoter, IDisposable
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
        public WorkPoint(DateTime staticsTime, List<WorkPointModel> wpm) {
            Workbook = new XSSFWorkbook();
            StaticsMonth = staticsTime;
            WorkPoints = wpm;
            CreateSheetSumHeader("当月绩效表");
            Init();

        }
        
        /// <summary>
        /// 导出绩效统计表Excel
        /// </summary>
        /// <param name="filename">文件名</param>
        public override void ExportExcel(string filename) {
           // ExportExcel(filename, StaticsMonth);
            foreach(var i in WorkPoints) {
                ISheet personal_sheet = CreatePersonalSheet(i.EmloyeeName);
                foreach(var j in i.MonthWorkPoints) {
                    FillPersonalSheet(personal_sheet, j);
                }

                // 在汇总表中写入总分
                IRow sum_row = Workbook.GetSheet("当月绩效表").CreateRow(SummarySheet.LastRowNum + 1);
                sum_row.CreateCell(0).SetCellValue(i.EmloyeeName);
                sum_row.CreateCell(1).SetCellValue(i.TotalPoints());
            }

            using (FileStream file = new FileStream(filename, FileMode.Create)) {
                Workbook.Write(file);
            }


        }


        /// <summary>
        /// 创建汇总表表头
        /// </summary>
        /// <param name="name">汇总表名称</param>
        /// <returns></returns>
        void CreateSheetSumHeader(string name) {
            SummarySheet = Workbook.CreateSheet(name);
            int row_sheet_sum = 0;
            IRow hdr = SummarySheet.CreateRow(row_sheet_sum);
            row_sheet_sum++;
            hdr.CreateCell(0).SetCellValue("姓名");
            hdr.CreateCell(1).SetCellValue("当月工分");
            hdr.CreateCell(2).SetCellValue("当月绩效");
          
        }

        /// <summary>
        /// 创建1个以人员姓名命名的工作表(WorkSheet)，并初始化表头信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ISheet CreatePersonalSheet(string name) {
            ISheet result = Workbook.CreateSheet(name);
            result.SetColumnWidth(0, 12 * 256);
            // 首行(row = 0)留白，从row1开始
            IRow r = result.CreateRow(1);
            r.CreateCell(0).SetCellValue("时间");
            r.CreateCell(1).SetCellValue("工作内容");
            r.CreateCell(2).SetCellValue("工作类别");
            r.CreateCell(3).SetCellValue("类别系数");
            r.CreateCell(4).SetCellValue("角色");
            r.CreateCell(5).SetCellValue("角色系数");
            return result;
        }
       
        void FillPersonalSheet(ISheet sheet, V_AllPoints pointTable) {
            FillPersonalSheet(sheet, pointTable.WorkDate, pointTable.WorkContent, pointTable.WorkType,
                pointTable.TypeWgt, pointTable.RoleName, pointTable.RoleWgt);
        }

        void FillPersonalSheet(ISheet sheet, DateTime date, string workContent, string workType, double typeWgt, string role, double roleWgt) {
            IRow r = sheet.CreateRow(sheet.LastRowNum + 1);
            r.CreateCell(0).SetCellValue(date);
            r.GetCell(0).CellStyle = DefaultDateStyle;

            r.CreateCell(1).SetCellValue(workContent);
            r.CreateCell(2).SetCellValue(workType);
            r.CreateCell(3).SetCellValue(typeWgt);
            r.CreateCell(4).SetCellValue(role);
            r.CreateCell(5).SetCellValue(roleWgt);
        }

        public new void Dispose() {
            base.Dispose();
        }
    }

}
