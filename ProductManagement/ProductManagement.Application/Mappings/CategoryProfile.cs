using AutoMapper;
using ProductManagement.Application.Features.Categories.Commands.Create;
using ProductManagement.Application.Features.Categories.Queries.GetAllCached;
using ProductManagement.Application.Features.Categories.Queries.GetById;
using ProductManagement.Domain.Entities.Catalog;

namespace ProductManagement.Application.Mappings
{
    internal class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            CreateMap<GetCategoryByIdResponse, Category>().ReverseMap();
            CreateMap<GetAllCategoriesCachedResponse, Category>().ReverseMap();
        }
    }
}