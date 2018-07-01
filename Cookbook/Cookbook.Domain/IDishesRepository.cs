using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Domain
{
    public interface IDishesRepository
    {
		IEnumerable<IDish> GetAll();
		void Add(IDish dish);
		void Delete(int dishId);
    }
}
