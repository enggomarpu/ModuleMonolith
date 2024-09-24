using Shared.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Products.Models
{
	public class Product : Entity<Guid>
	{
		public string Name { get; private set; } 
		public List<string> Category { get; private set; } = new();
		public string Description { get; private set; } 
		public string ImageFile { get; private set; } 
		public decimal Price { get; private set; }
	}
}
