using AutoMapper;
using ProductManagement.Application.Features.Categories.Commands.Update;
using ProductManagement.Application.Features.Categories.Queries.GetAllCached;
using ProductManagement.Application.Features.Categories.Queries.GetById;
using ProductManagement.Application.Features.Categories.Commands.Create;
using ProductManagement.Web.Areas.Catalog.Models;

namespace ProductManagement.Web.Areas.Catalog.Mappings
{
    internal class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<GetAllCategoriesCachedResponse, CategoryViewModel>().ReverseMap();
            CreateMap<GetCategoryByIdResponse, CategoryViewModel>().ReverseMap();
            CreateMap<CreateCategoryCommand, CategoryViewModel>().ReverseMap();
            CreateMap<UpdateCategoryCommand, CategoryViewModel>().ReverseMap();
        }
    }
}