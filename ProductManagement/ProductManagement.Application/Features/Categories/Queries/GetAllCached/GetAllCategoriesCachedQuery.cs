using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using ProductManagement.Application.Interfaces.CacheRepositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Categories.Queries.GetAllCached
{
    public class GetAllCategoriesCachedQuery : IRequest<Result<List<GetAllCategoriesCachedResponse>>>
    {
        public GetAllCategoriesCachedQuery()
        {
        }
    }

    public class GetAllCategoriesCachedQueryHandler : IRequestHandler<GetAllCategoriesCachedQuery, Result<List<GetAllCategoriesCachedResponse>>>
    {
        private readonly ICategoryCacheRepository _productCache;
        private readonly IMapper _mapper;

        public GetAllCategoriesCachedQueryHandler(ICategoryCacheRepository productCache, IMapper mapper)
        {
            _productCache = productCache;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllCategoriesCachedResponse>>> Handle(GetAllCategoriesCachedQuery request, CancellationToken cancellationToken)
        {
            var CategoryList = await _productCache.GetCachedListAsync();
            var mappedCategories = _mapper.Map<List<GetAllCategoriesCachedResponse>>(CategoryList);
            return Result<List<GetAllCategoriesCachedResponse>>.Success(mappedCategories);
        }
    }
}