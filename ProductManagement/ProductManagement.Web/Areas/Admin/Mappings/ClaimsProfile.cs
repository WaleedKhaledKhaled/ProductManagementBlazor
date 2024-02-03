using AutoMapper;
using ProductManagement.Web.Areas.Admin.Models;
using System.Security.Claims;

namespace ProductManagement.Web.Areas.Admin.Mappings
{
    public class ClaimsProfile : Profile
    {
        public ClaimsProfile()
        {
            CreateMap<Claim, RoleClaimsViewModel>().ReverseMap();
        }
    }
}