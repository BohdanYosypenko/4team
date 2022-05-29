using _4Teammate.Data.Entities;
using _4Teammate.Domain.Models;
using AutoMapper;

namespace _4Teammate.API.AutoMapingProfile;

public class SportCategoryProfile : Profile
{
    public SportCategoryProfile()
    {
        CreateMap<SportCategoryEntity, SportCategory>();
        CreateMap<SportCategory, SportCategoryEntity>();
    }
}
