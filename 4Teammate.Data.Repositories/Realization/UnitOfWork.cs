using _4Teammate.Data.Context;
using _4Teammate.Data.Repositories.Interfaces;

namespace _4Teammate.Data.Repositories.Realization;

public class UnitOfWork : IUnitOfWork
{
  private readonly AplicationDataContext _context;
  private ILookupCategoryRepository _lookupCategoryRepository;
  private ISportTypeRepository _sportTypeRepository;
  private ISportCategoryRepository _sportCategoryRepository;
  private ISportLookupRepository _sportLookupRepository;
  private ITeammateUserRepository _userRepository;

  public UnitOfWork(AplicationDataContext context)
  {
    _context = context;
  }

  public ILookupCategoryRepository LookupCategory
  {
    get { return _lookupCategoryRepository ??= new LookupCategoryRepository(_context); }
  }

  public ISportCategoryRepository SportCategory
  {
    get { return _sportCategoryRepository ??= new SportCategoryRepository(_context); }
  }

  public ISportLookupRepository SportLookup
  {
    get { return _sportLookupRepository ??= new SportLookupRepository(_context); }
  }

  public ISportTypeRepository SportType
  {
    get { return _sportTypeRepository ??= new SportTypeRepository(_context); }
  }

  public ITeammateUserRepository TeammateUser
  {
    get { return _userRepository ??= new TeammateUserRepository(_context); }
  }

  public void SaveAsync()
  {
    _context.SaveChanges();
  }
}

