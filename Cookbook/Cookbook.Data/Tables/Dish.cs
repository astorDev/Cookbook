using Cookbook.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.Data.Tables
{
    public class Dish : IDish
    {
		public int Id { get; set; }
		public string Name { get; set; }
    }
}
