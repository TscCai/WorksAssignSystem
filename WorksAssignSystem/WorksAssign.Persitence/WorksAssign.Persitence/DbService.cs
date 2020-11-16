using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorksAssign.Persistence
{
	public class DbService
	{
		public static IQueryable<Employee> GetAllEmpolyees()
		{
			WorksAssignEntities db = new WorksAssignEntities();
			return db.Employee;
		}
	}
}
