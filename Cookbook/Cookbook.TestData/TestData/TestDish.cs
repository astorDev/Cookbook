using Cookbook.Domain;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Tests.TestData
{
    public abstract class TestDish
    {
		public abstract string Name { get; }

		public void AssertEqualiltyTo(IDish dish)
		{
			Assert.AreEqual(this.Name, dish.Name);
		}

		public IDish Fake()
		{
			var fake = A.Fake<IDish>();
			A.CallTo(() => fake.Name).Returns(this.Name);
			return fake;
		}

		public readonly static TestDish Spaghetti = new SpaghettiTestDish();

		private class SpaghettiTestDish : TestDish
		{
			public override string Name => "Spaghetti";
		}

		public readonly static TestDish Hamburger = new HamburgerTestDish();

		private class HamburgerTestDish : TestDish
		{
			public override string Name => "Hamburger";
		}
	}
}
