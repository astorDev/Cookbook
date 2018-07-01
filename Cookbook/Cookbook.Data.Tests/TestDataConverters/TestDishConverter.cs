using Cookbook.Data.Tables;
using Cookbook.Tests.TestData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Data.Tests.TestDataConverters
{
    public static class TestDishConverter
    {
		public static Dish ToDbRecord(this TestDish testDish)
		{
			return new Dish
			{
				Name = testDish.Name
			};
		}
    }
}
