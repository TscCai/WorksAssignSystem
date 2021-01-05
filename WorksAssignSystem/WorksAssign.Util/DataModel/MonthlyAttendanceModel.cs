using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Util.DataModel
{
    public class MonthlyAttendanceModel {
        //public string Department { get { return "变电二次班"; } }

        //public DateTime StaticsTime { get; private set; }

        public string EmployeeName { get; set; }

        public long EmployeeId { get; set; }

        /// <summary>
        /// Key: Date index, e.g, 1,2,3...31
        /// Value: Flag
        /// </summary>
        public Dictionary<int,string> AttendanceFlag { get; set; }

        public MonthlyAttendanceModel() {
            AttendanceFlag = new Dictionary<int, string>();
        }
    }
}
