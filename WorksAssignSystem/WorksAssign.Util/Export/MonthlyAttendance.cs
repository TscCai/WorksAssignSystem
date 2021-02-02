using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using WorksAssign.Util.DataModel;

namespace WorksAssign.Util.Export
{
    public class MonthlyAttendance : GeneralExpoter, IDisposable
    {
        DateTime StaticsTime;
        List<MonthlyAttendanceModel> AttendanceList;

        public MonthlyAttendance(string templateFilename, DateTime staticsTime, List<MonthlyAttendanceModel> list) {
            using (FileStream fs = new FileStream(templateFilename, FileMode.Open, FileAccess.Read)) {
                Workbook = WorkbookFactory.Create(fs);
                Workbook.MissingCellPolicy = MissingCellPolicy.CREATE_NULL_AS_BLANK;
            }
            StaticsTime = staticsTime;
            AttendanceList = list;
            Init();
            
        }

        public override void ExportExcel(string filename) {
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
                //row = ActiveSheet.CreateRow(row.RowNum);
                InsertRows(row.RowNum + 1, 1);
                row = ActiveSheet.GetRow(row.RowNum + 1);
                // ActiveSheet.ShiftRows(MonthlyAttendanceTableDefine.StartRow + 1, MonthlyAttendanceTableDefine.StartRow + 2, 1);

            }

            using (FileStream fs = new FileStream(filename, FileMode.Create)) {
                Workbook.Write(fs);
            }


        }     

        void InsertRows(int fromRowIndex, int rowCount) {
            // sheet1.ShiftRows(fromRowIndex, sheet1.LastRowNum, rowCount, true, false, true);
            ActiveSheet.ShiftRows(fromRowIndex, ActiveSheet.LastRowNum, rowCount);
            for (int rowIndex = fromRowIndex; rowIndex < fromRowIndex + rowCount; rowIndex++) {
                IRow rowSource = ActiveSheet.GetRow(rowIndex + rowCount);
                IRow rowInsert = ActiveSheet.CreateRow(rowIndex);
                rowInsert.Height = rowSource.Height;
                for (int colIndex = 0; colIndex < rowSource.LastCellNum; colIndex++) {
                    ICell cellSource = rowSource.GetCell(colIndex);
                    ICell cellInsert = rowInsert.CreateCell(colIndex);
                    if (cellSource != null) {
                        cellInsert.CellStyle = cellSource.CellStyle;
                    }
                }
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
