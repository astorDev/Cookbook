using Cookbook.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Domain.Tests
{
    public abstract class RepositoryTest<TTestDbArrangement, TDbContext, TRepo>
		where TTestDbArrangement : ITestDbArrangement<TTestDbArrangement, TDbContext>
	{
		protected abstract ITestDbArrangement<TTestDbArrangement, TDbContext> TestDbArrangement(string testDbName);
		protected abstract TRepo Repo(TDbContext dbContext);
	}
}
