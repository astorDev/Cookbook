using Cookbook.Data.Tests.TestDataConverters;
using Cookbook.Tests;
using Cookbook.Tests.TestData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Data.Tests
{
	public class TestDbArrangement : TestDbArrangement<TestDbArrangement>
	{
		public TestDbArrangement(string inMemoryDbName) : base(inMemoryDbName)
		{
		}
	}

	public class TestDbArrangement<TTestDbArrangement> : ITestDbArrangement<TTestDbArrangement, CookbookDbContext>
		where TTestDbArrangement : TestDbArrangement<TTestDbArrangement>
	{
		private DbContextOptions<CookbookDbContext> options;
		private bool arrangementDbContextIsSavedAndDisposed = false;
		private CookbookDbContext arrangementContext;

		public TestDbArrangement(string inMemoryDbName)
		{
			this.options = new DbContextOptionsBuilder<CookbookDbContext>()
				.UseInMemoryDatabase(inMemoryDbName)
				.Options;

			this.arrangementContext = new CookbookDbContext(options);
		}


		public TTestDbArrangement With(TestDish testDish)
		{
			this.arrangementContext.Dishes.Add(testDish.ToDbRecord());
			return (TTestDbArrangement)this;
		}

		public async Task<TTestDbArrangement> ToActOn(Func<CookbookDbContext, Task> testAct)
		{
			this.ensureArrangementContextSavedAndDisposed();

			using (var actionContext = new CookbookDbContext(this.options))
			{
				await testAct(actionContext);
			}

			return (TTestDbArrangement)this;
		}

		public async Task ForAssert(Func<CookbookDbContext, Task> assertFunc)
		{
			this.ensureArrangementContextSavedAndDisposed();

			using (var assertionContext = new CookbookDbContext(this.options))
			{
				await assertFunc(assertionContext);
			}
		}

		private void ensureArrangementContextSavedAndDisposed()
		{
			if (!this.arrangementDbContextIsSavedAndDisposed)
			{
				this.arrangementContext.SaveChanges();
				this.arrangementContext.Dispose();
				this.arrangementDbContextIsSavedAndDisposed = true;
			}
		}
	}
}
