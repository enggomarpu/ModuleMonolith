using AutoMapper;
using Catalog.Products.Features.DTOs;
using Catalog.Products.Features.Queries;
using Catalog.Products.Models;
using MediatR;
using Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Products.Features.Handlers
{
	public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductResponseDto>>
	{
		private readonly IRepository2<Product, Guid> _productRepo;
		private readonly IMapper _mapper;

		public GetProductsHandler(
			IRepository2<Product, Guid> productRepo,
			IMapper mapper
		)
        {
			_productRepo = productRepo;
			_mapper = mapper;
		}
        public Task<IEnumerable<ProductResponseDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
		{
			var products = await _productRepo.
			var mappedProducts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponse>>(products);
			return mappedProducts;
		}
	}
}
