﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WorksAssign.Persistence;

namespace WorksAssign.Util.Export
{
    public class WorkPoint : IDisposable
    {

        DbAgent db;

        /// <summary>
        /// 内置Workbook对象
        /// </summary>
        IWorkbook wb;

        /// <summary>
        /// 在ExportExcel中初始化
        /// </summary>
        IQueryable<ExWorkdays> holidaysWorkdays;

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
        HolidayWorkdayDiscriminator hwd;
        /// <summary>
        /// 初始化资源，创建汇总表表头、默认日期格式
        /// </summary>
        /// <param name="db">外部DbAgent实例</param>
        public WorkPoint() {
            wb = new XSSFWorkbook();
            db = new DbAgent();
            CreateSheetSumHeader("当月绩效表");
            DefaultDateStyle = wb.CreateCellStyle();

            DefaultDateStyle.DataFormat = wb.CreateDataFormat().GetFormat("yyyy-MM-dd");

        }

        /// <summary>
        /// 导出绩效统计表Excel
        /// </summary>
        /// <param name="filename">文件名</param>
        public void ExportExcel(string filename) {
            ExportExcel(filename, DateTime.Now);
        }

        /// <summary>
        /// 导出指定月份的绩效分数
        /// </summary>
        /// <param name="filename">导出文件文件名，支持相对路径</param>
        /// <param name="beginOfMonth">指定月份的首日</param>
        public void ExportExcel(string filename, DateTime beginOfMonth) {


            hwd = new HolidayWorkdayDiscriminator(beginOfMonth.Year);
            //holidaysWorkdays = db.GetHolidaysWorkdays(beginOfMonth.Year);
            int currentMonth = beginOfMonth.Month;

            // 逐个计算个人绩效
            foreach (Employee emp in db.GetEmployee(false)) {

                double total_points = 0;
                datePointer = beginOfMonth;

                // 取出该人员在所有时间范围内的的全部工作内容
                DateTime endOfMonth = beginOfMonth.AddMonths(1).AddDays(-1);
                IQueryable<V_AllPoints> personal_points = db.GetWorkPoint(emp.Id, beginOfMonth, endOfMonth);

                ISheet personal_sheet = CreatePersonalSheet(emp.Name);

                while (datePointer.Month == currentMonth) {
                    // search if this day have work
                    List<V_AllPoints> item = personal_points.Where(s => s.WorkDate == datePointer).ToList();

                    total_points += GetDailyPoints(item, personal_sheet);

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


        /// <summary>
        /// 创建汇总表表头
        /// </summary>
        /// <param name="name">汇总表名称</param>
        /// <returns></returns>
        void CreateSheetSumHeader(string name) {
            SummarySheet = wb.CreateSheet(name);
            int row_sheet_sum = 0;
            IRow hdr = SummarySheet.CreateRow(row_sheet_sum);
            row_sheet_sum++;
            hdr.CreateCell(0).SetCellValue("姓名");
            hdr.CreateCell(1).SetCellValue("当月工分");
            hdr.CreateCell(2).SetCellValue("当月绩效");

            return;
        }

        /// <summary>
        /// 创建1个以人员姓名命名的工作表(WorkSheet)，并初始化表头信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ISheet CreatePersonalSheet(string name) {
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

        double GetDailyPoints(List<V_AllPoints> workOfOneDay, ISheet personalSheet) {
            double total_point = 0;
            if (workOfOneDay != null && workOfOneDay.Count > 0) {
                foreach (var i in workOfOneDay) {
                    FillPersonalSheet(personalSheet, i);
                    // 绩效计算公式
                    total_point += CalcWorkPoints(i.TypeWgt, i.RoleWgt);
                }
            }
            else {
                if (hwd.IsHoliday(datePointer)) {
                    //if (CommonUtil.IsHoliday(datePointer, holidaysWorkdays)) {
                    FillPersonalSheet(personalSheet, datePointer, "休息", "休息", 0, "", 0);
                }
                else if (hwd.IsWorkday(datePointer)) {
                    var defaultWorkPoint = db.GetDefaultWorkPoint();
                    defaultWorkPoint.WorkDate = datePointer;
                    FillPersonalSheet(personalSheet, defaultWorkPoint);

                    // 绩效计算公式
                    total_point += CalcWorkPoints(defaultWorkPoint.TypeWgt, defaultWorkPoint.RoleWgt);
                }
                // 以下方法尚未完成
                else if (hwd.IsDayOff(datePointer, 0, null)) {
                    FillPersonalSheet(personalSheet, datePointer, "休息", "休息", 0, "", 0);
                }
            }
            return total_point;
        }

        double CalcWorkPoints(double typeWgt, double roleWgt) {
            return typeWgt * roleWgt;
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

        public void Dispose() {
            db.Dispose();
        }
    }

}
