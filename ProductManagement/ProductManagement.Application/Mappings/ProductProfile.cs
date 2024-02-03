using AutoMapper;
using ProductManagement.Application.DTOs;
using ProductManagement.Application.Features.Products.Commands.Create;
using ProductManagement.Application.Features.Products.Queries.GetAllCached;
using ProductManagement.Application.Features.Products.Queries.GetAllPaged;
using ProductManagement.Application.Features.Products.Queries.GetById;
using ProductManagement.Domain.Entities.Catalog;
using System.Linq;

namespace ProductManagement.Application.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>()
               .ForMember(dst => dst.Categories, x => x.MapFrom(src => src.CategoryIds.Select(c => new ProductCategory
               {
                   CategoryId = c
               })))
                .ReverseMap();

            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsCachedResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsResponse, Product>().ReverseMap();
        }
    }
}