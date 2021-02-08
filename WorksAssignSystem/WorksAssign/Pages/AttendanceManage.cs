/******************************************************************************
 * WorksAssign 工作安排应用程序界面
 * CopyRight (C) 2020-2021 TscCai.
 * E-Mail：caijiran@hotmail.com
 *
 * GitHub: https://github.com/TscCai/WorksAssignSystem
 *
 ******************************************************************************
 * 文件名称: AttendanceManage.cs
 * 文件说明: 出勤管理
 * 当前版本: 
 * 创建日期: 2021-02-03
 * 2021-02-03: 增加文件说明
******************************************************************************/
using System;
using System.Collections.Generic;
using Sunny.UI;
using System.Configuration;
using WorksAssign.Persistence;
using WorksAssign.Util.Export.DataModel;
using WorksAssign.Util.Export;

namespace WorksAssign.Pages
{
    public partial class AttendanceManage : UIPage
    {
   
        public AttendanceManage() {
            InitializeComponent();
            dpk_MonthlyAttendance.Value = DateTime.Now.Date;
        }


        /// <summary>
        /// 出勤表导出按钮响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ExportMonthlyAttendance_Click(object sender, EventArgs e) {
            string template = ConfigurationManager.AppSettings["MonthlyAttendanceTemplatePath"];
            DateTime date = dpk_MonthlyAttendance.Value;
            //IDataModelBuilder<MonthlyAttendanceModel> builder = BuilderFactory<MonthlyAttendanceModel>.GetBuilder();
            IDataModelBuilder<MonthlyAttendanceModel> builder = new MonthlyAttendanceBuilder(date);
            List<MonthlyAttendanceModel> list = builder.BuildData();
           // List<MonthlyAttendanceModel> list = new DataModelBuilder().CreateMonthlyAttendanceData(date);

            


            using (MonthlyAttendance ma = new MonthlyAttendance(template, date, list)) {    
                
                // 创建目录，若存在则不会创建
                DirEx.CreateDir(ConfigurationManager.AppSettings["ExportFilePath"]);
                string filename = ConfigurationManager.AppSettings["ExportFilePath"] + date.ToString("[yyyy.MM]") + "考勤统计-二次班.xlsx";
                ma.ExportExcel(filename);
            }
            this.ShowSuccessDialog("月度考勤表导出成功。");
        }

        /// <summary>
        /// 绩效表导出按钮响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ExportWorkPoints_Click(object sender, EventArgs e) {
            DateTime date = dpk_MonthlyAttendance.Value.BeginOfMonth();
            //hwd = new HolidayWorkdayDiscriminator(date.Year);
            string filename = "Export/" + date.ToString("[yyyy.MM]") + "绩效表-二次班.xlsx";

            IDataModelBuilder<WorkPointModel> builder = new WorkPointBuilder(date);
            List<WorkPointModel> wpm = builder.BuildData();

            using (WorkPoint wp = new WorkPoint(date,wpm)) {
                
                wp.ExportExcel(filename);

            }
               
            this.ShowSuccessDialog("月度绩效表导出成功。");
        }

     

       
    }
}
