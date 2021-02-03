/******************************************************************************
 * WorksAssign.Util.Export 工作安排 Excel导出功能组件
 * CopyRight (C) 2020-2021 TscCai.
 * E-Mail：caijiran@hotmail.com
 *
 * GitHub: https://github.com/TscCai/WorksAssignSystem
 *
 ******************************************************************************
 * 文件名称: GeneralExporter.cs
 * 文件说明: Excel导出抽象类
 * 当前版本: 
 * 创建日期: 2021-02-03
 * 2021-02-03: 增加文件说明
******************************************************************************/
using NPOI.SS.UserModel;

namespace WorksAssign.Util.Export
{
    public abstract class GeneralExpoter
    {
        /// <summary>
        /// 内置Workbook对象
        /// </summary>
        protected IWorkbook Workbook;

        /// <summary>
        /// 活动页表格
        /// </summary>
        protected ISheet ActiveSheet;

        /// <summary>
        /// 默认日期格式，初始化为yyyy-MM-dd
        /// </summary>
        protected ICellStyle DefaultDateStyle;

        /// <summary>
        /// 子类需重写本方法
        /// </summary>
        /// <param name="filename"></param>
        //public void ExportExcel(string filename) {
        //    throw new NotImplementedException();
        //}

        public abstract void ExportExcel(string filename);

        /// <summary>
        /// 初始化
        /// </summary>
        protected void Init() {
            DefaultDateStyle = Workbook.CreateCellStyle();
            DefaultDateStyle.DataFormat = Workbook.CreateDataFormat().GetFormat("yyyy-MM-dd");
            ActiveSheet = Workbook.GetSheetAt(Workbook.ActiveSheetIndex);
        }

        protected void InsertRows(int fromRowIndex, int rowCount) {
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

        public void Dispose() {
            Workbook.Close();
        }

        //public void ExcelExport(string filename) {
        //    throw new NotImplementedException();
        //}
    }
}
