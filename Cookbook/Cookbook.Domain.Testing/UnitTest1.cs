using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smocks;

namespace Cookbook.Domain.Testing
{
	public class WorkDay
	{
		public static WorkDay Current => new WorkDay(DateTime.Now);
		public static int BorderHour => 11;

		public DateTime DateRepresentation { get; }


		private WorkDay(DateTime dateTime)
		{
			if (dateTime.Hour >= 11)
				this.DateRepresentation = dateTime.Date;
			else this.DateRepresentation = dateTime.Date.AddDays(-1);
		}
	}

	[TestClass]
	public class WorkDayTest
	{
		[TestMethod]
		public void Current_WhenDateNowReturnsTimeLessThenBorderHour_ReturnsPreviousDate()
		{
			Smock.Run(context =>
			{
				context.Setup(() => DateTime.Now).Returns(new DateTime(2018, 5, 20, 7, 0, 0, 0));
				context.Setup(() => WorkDay.BorderHour).Returns(8);

				Assert.AreEqual(WorkDay.Current.DateRepresentation, new DateTime(2018, 5, 19));
			});
		}

		[TestMethod]
		public void Current_WhenDateNowReturnsTimeGreaterThenBorderHour_ReturnsPreviousDate()
		{
			Smock.Run(context =>
			{
				context.Setup(() => DateTime.Now).Returns(new DateTime(2018, 5, 20, 9, 0, 0, 0));
				context.Setup(() => WorkDay.BorderHour).Returns(8);

				Assert.AreEqual(WorkDay.Current.DateRepresentation, new DateTime(2018, 5, 19));
			});
		}
	}
}
