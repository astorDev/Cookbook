using Cookbook.Tests;
using Cookbook.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Tests.RepositoriesTests
{
	public abstract class DishesRepositoryTestBase<TTestDbArrangement, TDbContext> 
		: RepositoryTest<TTestDbArrangement, TDbContext, IDishesRepository>
		where TTestDbArrangement : ITestDbArrangement<TTestDbArrangement, TDbContext>
	{
		[TestMethod]
		public async Task GetAll_ReturnsValidDataForAllRecordsInDb()
		{
			await this.TestDbArrangement("get all")
				.With(TestDish.Spaghetti)
				.With(TestDish.Hamburger)
				.ForAssert(async (dbContext) =>
				{
					var allDishes = this.Repo(dbContext).GetAll();

					TestDish.Spaghetti.AssertEqualiltyTo(allDishes.ElementAt(0));
					TestDish.Hamburger.AssertEqualiltyTo(allDishes.ElementAt(1));
				});
		}

		[TestMethod]
		public async Task Add_SavesRecordToDbContext()
		{
			await
			(await this.TestDbArrangement("add dish")
				.ToActOn(async (dbContext) =>
				{
					this.Repo(dbContext).Add(TestDish.Spaghetti.Fake());
				}))
				.ForAssert(async (dbContext) =>
				{
					var allDishes = this.Repo(dbContext).GetAll();

					TestDish.Spaghetti.AssertEqualiltyTo(allDishes.Single());
				});
		}

		[TestMethod]
		public async Task Delete_RemovesRecordFromContext()
		{
			await
			(await this.TestDbArrangement("delete dish")
				.With(TestDish.Spaghetti)
				.ToActOn(async (dbContext) =>
				{
					this.Repo(dbContext).Delete(1);
				}))
				.ForAssert(async (dbContext) =>
				{
					var allDishes = this.Repo(dbContext).GetAll();

					Assert.AreEqual(0, allDishes.Count());
				});
		}

	}
}
