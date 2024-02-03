using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using ProductManagement.Application.Interfaces.CacheRepositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Products.Queries.GetById
{
    public class GetProductByIdQuery : IRequest<Result<GetProductByIdResponse>>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<GetProductByIdResponse>>
        {
            private readonly IProductCacheRepository _productCache;

            public GetProductByIdQueryHandler(IProductCacheRepository productCache)
            {
                _productCache = productCache;
            }

            public async Task<Result<GetProductByIdResponse>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _productCache.GetByIdAsync(query.Id);
                
                var mappedProduct = new GetProductByIdResponse
                {
                    Barcode = product.Barcode,
                    CategoryIds = product.Categories.Select(x => x.CategoryId).ToList(),
                    Description = product.Description,
                    Id = product.Id,
                    Image = product.Image,
                    Name = product.Name,
                    Rate = product.Rate,
                };
                return Result<GetProductByIdResponse>.Success(mappedProduct);
            }
        }
    }
}