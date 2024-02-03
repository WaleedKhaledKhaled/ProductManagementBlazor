using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProductManagement.Web.Areas.Admin.Models;

namespace ProductManagement.Web.Areas.Admin.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
        }
    }
}