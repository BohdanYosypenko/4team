using _4Teammate.Data.Context;
using _4Teammate.Data.Entities;
using _4Teammate.Data.Repositories.Interfaces;

namespace _4Teammate.Data.Repositories.Realization;

public class SportCategoryRepository : BaseRepository<SportCategoryEntity>, ISportCategoryRepository
{
  public SportCategoryRepository(AplicationDataContext context) : base(context) { }
}

