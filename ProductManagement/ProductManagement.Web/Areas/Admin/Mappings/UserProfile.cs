using AutoMapper;
using ProductManagement.Infrastructure.Identity.Models;
using ProductManagement.Web.Areas.Admin.Models;

namespace ProductManagement.Web.Areas.Admin.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }
    }
}