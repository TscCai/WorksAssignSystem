using System;
using System.Linq;
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
			DbAgent db = new DbAgent();
            var e = db.GetSubstation().ToList();
            foreach (var i in e) {
                Console.WriteLine(i.SubstationName);
            }
		}
	}
}
