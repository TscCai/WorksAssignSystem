using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.SS.UserModel;
using WorksAssign.Persistence;
using WorksAssign.Util.Formula;
using System.Data;

using Z.Expressions;

namespace WorksAssign.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1() {
            DbAgent db = new DbAgent();
            var e = db.GetSubstation().ToList();
            foreach (var i in e) {
                Console.WriteLine(i.SubstationName);
            }
        }

        [TestMethod]
        public void TestView_AllPoints() {
            //WorksAssign.Util.Export.WorkPoint wp = new Util.Export.WorkPoint(new DateTime(2020, 10, 1));
            //wp.ExportExcel("Export/test.xlsx",new DateTime(2020,10,3));
        }


        [TestMethod]
        public void GenerateSampleData() {
            using (DbAgent db = new DbAgent()) {
                long substationId, typeId;
                string content, outsider, comment;
                DateTime date = new DateTime(2020, 1, 1);

                int min = 0, max, rndInt;
                Random rnd = new Random();

                for (int i = 0; i < 300; i++) {

                    max = db.GetSubstation().Count();
                    rndInt = rnd.Next(min, max);
                    substationId = db.GetSubstation().AsEnumerable().ElementAt(rndInt).Id;

                    max = db.GetWorkType().Count();
                    rndInt = rnd.Next(min, max);
                    typeId = db.GetWorkType().AsEnumerable().ElementAt(rndInt).Id;

                    content = "This is work " + i;
                    outsider = "外协人员：Member" + i;
                    List<WorkInvolve> list = new List<WorkInvolve>();

                    max = db.GetEmployee().Count();

                    WorkInvolve leader = new WorkInvolve();
                    leader.EmployeeId = db.GetEmployee().AsEnumerable().ElementAt((rnd.Next(min, max))).Id;
                    leader.RoleId = db.GetRole(typeId, "负责人").Id;
                    list.Add(leader);


                    int memberCnt = rnd.Next(1, 6);
                    for (int j = 0; j < memberCnt; j++) {
                        WorkInvolve member = new WorkInvolve();
                        member.EmployeeId = db.GetEmployee().AsEnumerable().ElementAt(rnd.Next(min, max)).Id;
                        member.RoleId = db.GetRole(typeId, "骨干").Id;
                        list.Add(member);
                    }

                    db.AddWork(substationId, typeId, content, date, "预试", list, outsider, "This is a comment" + i);

                    date = date.AddDays(rnd.Next(3));
                    Console.WriteLine("Work {0} Added", i);
                }

            }

            Console.WriteLine("Test complete!");

        }


        [TestMethod]
        public void TestEval() {
            FormulaManager fm = new FormulaManager(0.5, 10, 1);
            double r = fm.DailyPoint("{RoleWgt}*{TypeWgt}*{SeniorityWgt}");
            Assert.AreEqual(r, 5.0);

        }


        [TestMethod]
        public void ImportOldTable() {
            string filename = @"E:\import.xlsx";
            IWorkbook wb = WorkbookFactory.Create(filename);
            ISheet sheet = wb.GetSheetAt(wb.ActiveSheetIndex);

            using (DbAgent db = new DbAgent()) {
                long substationId = 1;
                for (int rowNum = 1; rowNum < sheet.LastRowNum; rowNum++) {
                    IRow row = sheet.GetRow(rowNum);
                    string content = row.Cells[1].ToString();
                    long typeId = Convert.ToInt64(row.Cells[4].ToString());
                    DateTime date = Convert.ToDateTime(row.Cells[2].ToString());

                    string leader = row.Cells[3].StringCellValue;
                    string members = row.Cells[5].StringCellValue;
                    string manager = row.Cells[6].StringCellValue;
                    List<WorkInvolve> wi = CreateWorkInvoves(db, typeId, leader, members, manager, date);

                    db.AddWork(substationId, typeId, content, date, "others", wi);

                }



                Console.WriteLine("Done");
            }


        }

        private List<WorkInvolve> CreateWorkInvoves(DbAgent db, long typeId, string leader, string members, string manager, DateTime workDate) {
            List<WorkInvolve> result = new List<WorkInvolve>();
            WorkInvolve l = new WorkInvolve();
            var e_l = db.GetEmployee(leader);
            if (e_l != null) {
                l.RoleId = db.GetRole(typeId, "负责人").Id;
                l.EmployeeId = e_l.Id;
                result.Add(l);
            }


            if (!String.IsNullOrEmpty(manager)) {

                WorkInvolve mgr = new WorkInvolve();
                var e_m = db.GetEmployee(manager);
                mgr.EmployeeId = e_m.Id;
                mgr.RoleId = db.GetRole(typeId, "管理人员").Id;
                result.Add(mgr);
            }


            string[] mem = members.Split('、');
            foreach (var item in mem) {
                var employee = db.GetEmployee(item);
                if (employee != null) {
                    WorkInvolve wi = new WorkInvolve();
                    wi.EmployeeId = employee.Id;

                    string role = "骨干";
                    if (workDate.Year - employee.JoinDate.Year < 3) {
                        role = "青工";
                    }

                    wi.RoleId = db.GetRole(typeId, role).Id;
                    result.Add(wi);
                }
            }

            return result;

        }


        [TestMethod]
        public void TestDataTable() {
            DataTable dt = new DataTable();
            var dr = dt.NewRow();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns.Add();
            
            dr[0] = "test";
            dr[1] = DateTime.Now;
            dr[2] = 3;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "test2";
            dr[1] = DateTime.Now;
            dr[2] = 33.44;
            dt.Rows.Add(dr);
            foreach (DataRow i in dt.Rows) {
                Console.WriteLine(i[0]);
                Console.WriteLine(i[1]);
                Console.WriteLine(i[2]);
            }
        }




    }

}
