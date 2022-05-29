using _4Teammate.Data.Entities;
using _4Teammate.Domain.Models;
using AutoMapper;

namespace _4Teammate.API.AutoMapingProfile;

public class LookupCategoryProfile : Profile
{
    public LookupCategoryProfile()
    {
        CreateMap<LookupCategoryEntity, LookupCategory>();
        CreateMap<LookupCategory, LookupCategoryEntity>();
    }
}
