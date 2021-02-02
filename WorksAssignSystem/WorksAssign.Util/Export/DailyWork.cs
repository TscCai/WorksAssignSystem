using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WorksAssign.Persistence;
using WorksAssign.Persistence.Adapter;
using WorksAssign.Util.DataModel;

namespace WorksAssign.Util.Export
{
    public class DailyWork: GeneralExpoter, IDisposable
    {


        List<DailyWorkModel> DailyWorkList;

        public DailyWork(string templateFilename, List<DailyWorkModel> list) {
            using (FileStream fs = new FileStream(templateFilename, FileMode.Open, FileAccess.Read)) {
                Workbook = WorkbookFactory.Create(fs);
                Workbook.MissingCellPolicy = MissingCellPolicy.CREATE_NULL_AS_BLANK;
            }
            DailyWorkList = list;

            Init();
            ActiveSheet = Workbook.GetSheetAt(Workbook.ActiveSheetIndex);
        }

        public override void ExportExcel(string filename) {
            int rowNum = DailyWorkTableDefine.StartRow;
            ActiveSheet.SetDefaultColumnStyle(DailyWorkTableDefine.Date, DefaultDateStyle);
            foreach(var item in DailyWorkList) {
               IRow row=  ActiveSheet.GetRow(rowNum);
                row.GetCell(DailyWorkTableDefine.Date).SetCellValue(item.Date.ToString("yyyy-MM-dd"));
                row.GetCell(DailyWorkTableDefine.Location).SetCellValue(item.Location);
                row.GetCell(DailyWorkTableDefine.Substation).SetCellValue(item.Substation);
                row.GetCell(DailyWorkTableDefine.Voltage).SetCellValue(item.Voltage);
                row.GetCell(DailyWorkTableDefine.Content).SetCellValue(item.Content);
                row.GetCell(DailyWorkTableDefine.Leader).SetCellValue(item.Leader);
                row.GetCell(DailyWorkTableDefine.Member).SetCellValue(item.Member);
                row.GetCell(DailyWorkTableDefine.ExMember).SetCellValue(item.ExMember);
                row.GetCell(DailyWorkTableDefine.Manager).SetCellValue(item.Manager);
                row.GetCell(DailyWorkTableDefine.ShortType).SetCellValue(item.ShortType);
                rowNum++;
            }

            using (FileStream file = new FileStream(filename, FileMode.Create)) {
                Workbook.Write(file);
            }

        }
        /*
        public void ExportExcel(string filename, DateTime date) {

        }

        public void ExportExcel(string filename, DateTime start, DateTime end) {

        }
        */
    }
    struct DailyWorkTableDefine
    {
        public const int StartRow = 1;
        public const int Date = 1;
        public const int Location = 2;
        public const int Substation = 3;
        public const int Voltage = 4;
        public const int ShortType = 5;
        public const int Content = 6;
        public const int Leader = 7;
        public const int Member = 8;
        public const int ExMember = 9;
        public const int Manager = 10;
    }
}
