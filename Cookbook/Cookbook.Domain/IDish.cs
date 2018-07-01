using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Domain
{
    public interface IDish
    {
		int Id { get; }
		string Name { get; }
    }
}
