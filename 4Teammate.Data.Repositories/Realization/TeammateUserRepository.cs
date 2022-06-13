using _4Teammate.Data.Context;
using _4Teammate.Data.Entities;
using _4Teammate.Data.Repositories.Interfaces;

namespace _4Teammate.Data.Repositories.Realization;

public class TeammateUserRepository : BaseRepository<TeammateUserEntity>, ITeammateUserRepository
{
  public TeammateUserRepository(AplicationDataContext context) : base(context) { }
}
