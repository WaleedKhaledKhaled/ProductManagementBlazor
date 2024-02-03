using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductManagement.Application.Features.Products.Commands.Create;
using ProductManagement.Application.Features.Products.Commands.Update;
using ProductManagement.Application.Features.Products.Queries.GetAllCached;
using ProductManagement.Application.Features.Products.Queries.GetById;
using ProductManagement.Web.Areas.Catalog.Models;
using System.Linq;

namespace ProductManagement.Web.Areas.Catalog.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<GetAllProductsCachedResponse, ProductViewModel>().ReverseMap();
            CreateMap<GetProductByIdResponse, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductViewModel>()
                .ReverseMap();
        }
    }
}