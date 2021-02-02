using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public virtual void ExportExcel(string filename) {
            throw new NotImplementedException();
        }

        protected void Init() {
            DefaultDateStyle = Workbook.CreateCellStyle();
            DefaultDateStyle.DataFormat = Workbook.CreateDataFormat().GetFormat("yyyy-MM-dd");
            ActiveSheet = Workbook.GetSheetAt(Workbook.ActiveSheetIndex);
        }

        public void Dispose() {
            Workbook.Close();
        }
    }
}
