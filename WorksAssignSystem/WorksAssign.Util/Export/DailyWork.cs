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
    public class DailyWork:IDisposable
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


        public DailyWork(string templateFilename) {
            using (FileStream fs = new FileStream(templateFilename, FileMode.Open, FileAccess.Read)) {
                Workbook = WorkbookFactory.Create(fs);
                Workbook.MissingCellPolicy = MissingCellPolicy.CREATE_NULL_AS_BLANK;
            }
            
            
            //CreateSheetHeader("出勤流水");
            DefaultDateStyle = Workbook.CreateCellStyle();
            DefaultDateStyle.DataFormat = Workbook.CreateDataFormat().GetFormat("yyyy-MM-dd");
            ActiveSheet = Workbook.GetSheetAt(Workbook.ActiveSheetIndex);
        }

        public void ExportExcel(string filename, List<DailyWorkModel> list) {
            int rowNum = DailyWorkTableDefine.StartRow;
            ActiveSheet.SetDefaultColumnStyle(DailyWorkTableDefine.Date, DefaultDateStyle);
            foreach(var item in list) {
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

        public void ExportExcel(string filename) {

        }

        public void ExportExcel(string filename, DateTime date) {

        }

        public void ExportExcel(string filename, DateTime start, DateTime end) {

        }

        public void Dispose() {
            Workbook.Close();
        }
    }
    class DailyWorkTableDefine
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
