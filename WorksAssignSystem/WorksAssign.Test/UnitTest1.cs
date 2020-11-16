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
			var e = DbService.GetAllEmpolyees();
			foreach (var i in e)
			{
				Console.WriteLine(i.Name);
			}
		}
	}
}
