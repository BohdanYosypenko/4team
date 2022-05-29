using _4Teammate.Data.Entities;
using _4Teammate.Domain.Models;
using AutoMapper;

namespace _4Teammate.API.AutoMapingProfile;

public class SportLookupProfile : Profile
{
    public SportLookupProfile()
    {
        CreateMap<SportLookupEntity, SportLookup>();
        CreateMap<SportLookup, SportLookupEntity>();
    }
}
