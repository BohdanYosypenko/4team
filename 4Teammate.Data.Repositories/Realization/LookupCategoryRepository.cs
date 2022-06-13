using _4Teammate.Data.Context;
using _4Teammate.Data.Entities;
using _4Teammate.Data.Repositories.Interfaces;

namespace _4Teammate.Data.Repositories.Realization;

public class LookupCategoryRepository :BaseRepository<LookupCategoryEntity>, ILookupCategoryRepository
{
  public LookupCategoryRepository(AplicationDataContext context) : base(context) { }
}

