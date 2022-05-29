using _4Teammate.Data.Entities;
using _4Teammate.Domain.Models;
using AutoMapper;

namespace _4Teammate.API.AutoMapingProfile;

public class SportTypeProfile : Profile
{
    public SportTypeProfile()
    {
        CreateMap<SportTypeEntity, SportType>();
        CreateMap<SportType, SportTypeEntity>();
    }
}
