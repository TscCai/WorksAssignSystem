using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Util.DataModel
{
    public class WorkPointModel {
        public string EmloyeeName { get; set; }
        public long EmployeeId { get; set; }
        public DailyWorkPointModel[] MonthWorkPoints{get;set;}
    }

    public class DailyWorkPointModel
    {
        public string WorkContent { get; set; }
        public double Point { get; set; }
    }

}
