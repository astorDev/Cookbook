using Cookbook.Data.Repositories;
using Cookbook.Domain;
using Cookbook.Domain.Tests;
using Cookbook.Domain.Tests.RepositoriesTests;
using Cookbook.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Data.Tests
{
	[TestClass]
	public class DishesRepositoryTest : DishesRepositoryTestBase<TestDbArrangement, CookbookDbContext>
	{
		protected override IDishesRepository Repo(CookbookDbContext dbContext)
		{
			return new DishesRepository(dbContext);
		}

		protected override ITestDbArrangement<TestDbArrangement, CookbookDbContext> TestDbArrangement(string testDbName)
		{
			return new TestDbArrangement(testDbName);
		}
	}
}
