﻿using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using ProductManagement.Application.Interfaces.CacheRepositories;
using System.Threading;
using System.Threading.Tasks;

namespace ProductManagement.Application.Features.Categories.Queries.GetById
{
    public class GetCategoryByIdQuery : IRequest<Result<GetCategoryByIdResponse>>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<GetCategoryByIdResponse>>
        {
            private readonly ICategoryCacheRepository _CategoryCache;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(ICategoryCacheRepository productCache, IMapper mapper)
            {
                _CategoryCache = productCache;
                _mapper = mapper;
            }

            public async Task<Result<GetCategoryByIdResponse>> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _CategoryCache.GetByIdAsync(query.Id);
                var mappedProduct = _mapper.Map<GetCategoryByIdResponse>(product);
                return Result<GetCategoryByIdResponse>.Success(mappedProduct);
            }
        }
    }
}