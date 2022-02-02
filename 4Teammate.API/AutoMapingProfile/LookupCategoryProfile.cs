using _4Teammate.API.Database.Entities;
using _4Teammate.API.Models;
using AutoMapper;

namespace _4Teammate.API.AutoMapingProfile
{
    public class LookupCategoryProfile : Profile
    {
        public LookupCategoryProfile()
        {
            CreateMap<LookupCategoryEntity, LookupCategory>();
            CreateMap<LookupCategory, LookupCategoryEntity>();
        }
    }
}
