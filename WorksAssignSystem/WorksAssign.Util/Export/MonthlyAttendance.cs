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
    public class MonthlyAttendance:IDisposable
    {
        /// <summary>
        /// 内置Workbook对象
        /// </summary>
        IWorkbook Workbook;

        /// <summary>
        /// 活动页表格
        /// </summary>
        ISheet ActiveSheet;


        /// <summary>
        /// 默认日期格式，初始化为yyyy-MM-dd
        /// </summary>
        ICellStyle DefaultDateStyle;


        public MonthlyAttendance(string templateFilename) {
            using (FileStream fs = new FileStream(templateFilename, FileMode.Open, FileAccess.Read)) {
                Workbook = WorkbookFactory.Create(fs);
                Workbook.MissingCellPolicy = MissingCellPolicy.CREATE_NULL_AS_BLANK;
            }

            DefaultDateStyle = Workbook.CreateCellStyle();
            DefaultDateStyle.DataFormat = Workbook.CreateDataFormat().GetFormat("yyyy-MM-dd");
            ActiveSheet = Workbook.GetSheetAt(Workbook.ActiveSheetIndex);
        }

        public void ExportExcel(string filename, DateTime staticsTime, List<MonthlyAttendanceModel> list) {
            ActiveSheet.SetDefaultColumnStyle(MonthlyAttendanceTableDefine.StaticsTime.Column, DefaultDateStyle);
            int seqCnt = 1;
            IRow row = ActiveSheet.GetRow(MonthlyAttendanceTableDefine.StartRow);
            foreach (var data in list) {
                row.GetCell(MonthlyAttendanceTableDefine.Name).SetCellValue(data.EmployeeName);
                row.GetCell(MonthlyAttendanceTableDefine.Sequence).SetCellValue(seqCnt);
                seqCnt++;
                foreach(var k in data.AttendanceFlag.Keys) {
                    string flag = data.AttendanceFlag[k];
                    int col = MonthlyAttendanceTableDefine.FirstDate + k - 1;
                    row.GetCell(col).SetCellValue(flag);
                }
                // 因为有footer，故必须用插入行命令
                row = ActiveSheet.CreateRow(row.RowNum);
            }

            using (FileStream fs = new FileStream(filename, FileMode.Create)) {
                Workbook.Write(fs);
            }


        }

        public void Dispose() {
            Workbook.Close();
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
