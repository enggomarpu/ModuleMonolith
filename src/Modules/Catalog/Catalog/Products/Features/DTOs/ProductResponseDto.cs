using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Products.Features.DTOs
{
	public class ProductResponseDto
	{
		public string Name { get; private set; }
		public string Description { get; private set; }
		public string ImageFile { get; private set; }
		public decimal Price { get; private set; }

	}
}
