using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorksAssign.Persistence;

namespace WorksAssign.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			DbService db = new DbService();
			var e = db.GetEmployee("朱林");
			if (e != null)
			{
				Console.WriteLine(e.IsCCP);
			}
		}
	}
}
