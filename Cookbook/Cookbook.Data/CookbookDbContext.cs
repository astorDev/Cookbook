using Cookbook.Data.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Data
{
    public class CookbookDbContext : DbContext
    {
		public CookbookDbContext()
		{
		}

		public CookbookDbContext(DbContextOptions<CookbookDbContext> contextOptions) : base(contextOptions)
		{
		}

		public DbSet<Dish> Dishes { get; set; }
    }
}
