using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorksAssign.Persistence;

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
            WorksAssign.Util.Export.WorkPoint wp = new Util.Export.WorkPoint();
            wp.ExportExcel("Export/test.xlsx",new DateTime(2020,10,3));
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

                    db.AddWork(substationId, typeId, content, date, "预试",list, outsider, "This is a comment" + i);

                    date = date.AddDays(rnd.Next(3));
                    Console.WriteLine("Work {0} Added",i);
                }

            }

            Console.WriteLine("Test complete!");

        }



    }

}
