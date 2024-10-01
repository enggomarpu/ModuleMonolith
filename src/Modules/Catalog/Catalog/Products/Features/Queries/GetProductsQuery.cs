using Catalog.Products.Features.DTOs;
using MediatR;

namespace Catalog.Products.Features.Queries
{
	public class GetProductsQuery : IRequest<IEnumerable<ProductResponseDto>>
	{
	}
}
