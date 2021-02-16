/******************************************************************************
 * WorksAssign.Util.Export 工作安排 Excel导出功能组件
 * CopyRight (C) 2020-2021 TscCai.
 * E-Mail：caijiran@hotmail.com
 *
 * GitHub: https://github.com/TscCai/WorksAssignSystem
 *
 ******************************************************************************
 * 文件名称: MonthlyAttendance.cs
 * 文件说明: 月度考勤表导出
 * 当前版本: 
 * 创建日期: 2021-02-03
 * 2021-02-03: 增加文件说明
******************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using NPOI.SS.UserModel;
using WorksAssign.Util.Export.DataModel;

namespace WorksAssign.Util.Export
{
    public class MonthlyAttendanceExporter : BaseExpoter, IDisposable
    {
        DateTime StaticsTime;
        List<MonthlyAttendanceModel> AttendanceList;

        public MonthlyAttendanceExporter(string templateFilename, DateTime staticsTime, List<MonthlyAttendanceModel> list) {
            using (FileStream fs = new FileStream(templateFilename, FileMode.Open, FileAccess.Read)) {
                Workbook = WorkbookFactory.Create(fs);
                Workbook.MissingCellPolicy = MissingCellPolicy.CREATE_NULL_AS_BLANK;
            }
            StaticsTime = staticsTime;
            AttendanceList = list;
            Init();
        }
        
        protected override void FillTable() {
            ActiveSheet.SetDefaultColumnStyle(MonthlyAttendanceTableDefine.StaticsTime.Column, DefaultDateStyle);
            int seqCnt = 1;
            IRow row = ActiveSheet.GetRow(MonthlyAttendanceTableDefine.StartRow);
            foreach (var data in AttendanceList) {
                row.GetCell(MonthlyAttendanceTableDefine.Name).SetCellValue(data.EmployeeName);
                row.GetCell(MonthlyAttendanceTableDefine.Sequence).SetCellValue(seqCnt);
                seqCnt++;
                foreach (var k in data.AttendanceFlag.Keys) {
                    string flag = data.AttendanceFlag[k];
                    int col = MonthlyAttendanceTableDefine.FirstDate + k - 1;
                    row.GetCell(col).SetCellValue(flag);
                }
                // 因为有footer，故必须用插入行命令
                InsertRows(row.RowNum + 1, 1);
                row = ActiveSheet.GetRow(row.RowNum + 1);
            }
        }

       

    }

    class MonthlyAttendanceTableDefine
    {
        public static CellPosition Department { get { return new CellPosition(6, 0); } }
        public static CellPosition StaticsTime { get { return new CellPosition(6, 18); } }

        public const int StartRow = 10;
        public const int Sequence = 0;
        public const int Name = 1;
        public const int FirstDate = 19;


    }

    struct CellPosition
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public CellPosition(int row, int col) {
            Row = row;
            Column = col;
        }


    }
}
