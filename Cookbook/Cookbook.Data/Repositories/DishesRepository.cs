using Cookbook.Data.Tables;
using Cookbook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cookbook.Data.Repositories
{
	public class DishesRepository : IDishesRepository
	{
		private readonly CookbookDbContext dbContext;

		public DishesRepository(CookbookDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void Add(IDish dish)
		{
			dbContext.Dishes.Add(new Dish() { Name = dish.Name });
			dbContext.SaveChanges();
		}

		public void Delete(int dishId)
		{
			dbContext.Dishes.Remove(dbContext.Dishes.Single(d => d.Id == dishId));
			dbContext.SaveChanges();
		}

		public IEnumerable<IDish> GetAll()
		{
			return dbContext.Dishes;
		}
	}
}
