using _4Teammate.API.Database.Entities;
using _4Teammate.API.Models;
using AutoMapper;

namespace _4Teammate.API.AutoMapingProfile
{
    public class SportTypeProfile : Profile
    {
        public SportTypeProfile()
        {
            CreateMap<SportTypeEntity, SportType>();
            CreateMap<SportType, SportTypeEntity>();
        }
    }
}
