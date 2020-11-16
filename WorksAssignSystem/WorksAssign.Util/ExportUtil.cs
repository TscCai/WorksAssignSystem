using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WorksAssign.Persistence;

namespace WorksAssign.Util {
    public class ExportUtil {

        DbService Db;
        /// <summary>
        /// 内置Workbook对象
        /// </summary>
        IWorkbook wb;

        /// <summary>
        /// 内置日期指针
        /// </summary>
        DateTime datePointer;

        /// <summary>
        /// 汇总页表格
        /// </summary>
        ISheet SummarySheet;

        /// <summary>
        /// 默认日期格式，初始化为yyyy-MM-dd
        /// </summary>
        ICellStyle DefaultDateStyle;

        /// <summary>
        /// 初始化资源，创建汇总表表头、默认日期格式
        /// </summary>
        /// <param name="db">外部DbAgent实例</param>
        public ExportUtil()
        {
            wb = new XSSFWorkbook();
            Db = new DbService();
            CreateSheetSumHeader("当月绩效表");
            DefaultDateStyle = wb.CreateCellStyle();
            DefaultDateStyle.DataFormat = wb.CreateDataFormat().GetFormat("yyyy-mm-dd");
        }

        /// <summary>
        /// 创建汇总表表头
        /// </summary>
        /// <param name="name">汇总表名称</param>
        /// <returns></returns>
        void CreateSheetSumHeader(string name)
        {
            SummarySheet = wb.CreateSheet(name);
            int row_sheet_sum = 0;
            IRow hdr = SummarySheet.CreateRow(row_sheet_sum);
            row_sheet_sum++;
            hdr.CreateCell(0).SetCellValue("姓名");
            hdr.CreateCell(1).SetCellValue("当月工分");
            hdr.CreateCell(2).SetCellValue("当月绩效");

            return;
        }


        ISheet CreatePersonalSheet(string name)
        {
            ISheet result = wb.CreateSheet(name);
            result.SetColumnWidth(0, 12 * 256);
            // 首行留白，从row1开始
            IRow r = result.CreateRow(1);
            r.CreateCell(0).SetCellValue("时间");
            r.CreateCell(1).SetCellValue("工作内容");
            r.CreateCell(2).SetCellValue("工作类别");
            r.CreateCell(3).SetCellValue("类别系数");
            r.CreateCell(4).SetCellValue("角色");
            r.CreateCell(5).SetCellValue("角色系数");
            return result;
        }
        /// <summary>
        /// 导出绩效统计表Excel
        /// </summary>
        /// <param name="filename">文件名</param>
        public void ExportExcel(string filename)
        {
            ExportExcel(filename, Db.StartDate);
        }

        public void ExportExcel(string filename, DateTime startDate)
        {
            int currentMonth = startDate.Month;

            // 逐个计算个人绩效
            foreach (Employee emp in Db.GetEmpolyee()) {

                // Id=1 为外部人员，不参与绩效计算
                if (emp.Id == 1) {
                    continue;
                }
                double total_points = 0;
                datePointer = startDate;

                // 取出该人员的所有工作内容
                IQueryable<V_AllPoints> personal_points = Db.GetWorkScoreById(emp.Id);

                ISheet personal_sheet = CreatePersonalSheet(emp.Name);

                while (datePointer.Month == currentMonth) {
                    // search if this day have work
                    List<V_AllPoints> item = personal_points.Where(s => s.WorkDate == datePointer).ToList();

                    total_points += CalcPoints(item, personal_sheet);

                    //TODO: append bonus items


                    datePointer = datePointer.AddDays(1);
                }

                // 在汇总表中写入总分
                IRow sum_row = wb.GetSheet("当月绩效表").CreateRow(SummarySheet.LastRowNum + 1);
                sum_row.CreateCell(0).SetCellValue(emp.Name);
                sum_row.CreateCell(1).SetCellValue(total_points);

            }
            using (FileStream file = new FileStream(filename, FileMode.Create)) {
                wb.Write(file);
            }

        }


        double CalcPoints(List<V_AllPoints> workOfOneDay, ISheet personalSheet)
        {
            double total_score = 0;
            if (workOfOneDay != null && workOfOneDay.Count > 0) {
                foreach (var i in workOfOneDay) {
                    FillPersonalSheet(personalSheet, i);
                    // 绩效计算公式
                    total_score += CommonUtil.CalcWorkPoints(i.TypeWgt, i.RoleWgt);
                }
            }
            else {
                if (CommonUtil.IsHoliday(datePointer, Db.HolidaysWorkdays)) {
                    FillPersonalSheet(personalSheet, datePointer, "休息", "休息", 0, "", 0);
                }
                else if (CommonUtil.IsWorkday(datePointer, Db.HolidaysWorkdays)) {
                    var def_score = Db.DefaultWorkScore;
                    def_score.WorkDate = datePointer;
                    FillPersonalSheet(personalSheet, def_score);

                    // 绩效计算公式
                    total_score += CommonUtil.CalcWorkPoints(def_score.TypeWgt, def_score.RoleWgt);
                }
                else if (CommonUtil.IsDayOff(datePointer, 0, null)) {
                    FillPersonalSheet(personalSheet, datePointer, "休息", "休息", 0, "", 0);
                }
            }
            return total_score;
        }

        void FillPersonalSheet(ISheet sheet, V_AllPoints scoreTable)
        {
            FillPersonalSheet(sheet, scoreTable.WorkDate, scoreTable.WorkContent, scoreTable.WorkType,
                scoreTable.TypeWgt, scoreTable.RoleName, scoreTable.RoleWgt);
        }
        void FillPersonalSheet(ISheet sheet, DateTime date, string workContent, string workType, double typeWgt, string role, double roleWgt)
        {
            IRow r = sheet.CreateRow(sheet.LastRowNum + 1);
            r.CreateCell(0).SetCellValue(date);
            r.GetCell(0).CellStyle = DefaultDateStyle;

            r.CreateCell(1).SetCellValue(workContent);
            r.CreateCell(2).SetCellValue(workType);
            r.CreateCell(3).SetCellValue(typeWgt);
            r.CreateCell(4).SetCellValue(role);
            r.CreateCell(5).SetCellValue(roleWgt);
        }

    }

}
