using _4Teammate.API.Database.Entities;
using _4Teammate.API.Models;
using AutoMapper;

namespace _4Teammate.API.AutoMapingProfile
{
    public class SportLookupProfile : Profile
    {
        public SportLookupProfile()
        {
            CreateMap<SportLookupEntity, SportLookup>();
            CreateMap<SportLookup, SportLookupEntity>();
        }
    }
}
