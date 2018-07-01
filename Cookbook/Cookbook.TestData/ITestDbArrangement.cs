using Cookbook.Tests.TestData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Tests
{
    public interface ITestDbArrangement<TArrangement, TDbContext>
		where TArrangement : ITestDbArrangement<TArrangement, TDbContext>
    {
		TArrangement With(TestDish testDish);
		Task<TArrangement> ToActOn(Func<TDbContext, Task> testAct);
		Task ForAssert(Func<TDbContext, Task> assertFunc);

    }
}
