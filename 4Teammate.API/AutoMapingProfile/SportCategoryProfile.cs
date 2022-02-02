using _4Teammate.API.Database.Entities;
using _4Teammate.API.Models;
using AutoMapper;

namespace _4Teammate.API.AutoMapingProfile
{
    public class SportCategoryProfile : Profile
    {
        public SportCategoryProfile()
        {
            CreateMap<SportCategoryEntity, SportCategory>();
            CreateMap<SportCategory, SportCategoryEntity>();
        }
    }
}
