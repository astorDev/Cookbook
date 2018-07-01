using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.IntegrationTests
{
    public static class Resolve<T>
    {
		private static IKernel _kernel;
		public static IKernel kernel
		{
			get
			{
				if (_kernel == null)
				{
					_kernel = new StandardKernel();

					//Register dependecies
				}

				return kernel;
			}
		}



    }
}
