using _4Teammate.Data.Context;
using _4Teammate.Data.Repositories.Interfaces;

namespace _4Teammate.Data.Repositories.Realization;

public class UnitOfWork : IUnitOfWork
{
    private readonly AplicationDataContext _context;

    public ILookupCategoryRepository LookupCategory { get; set; }
    public ISportCategoryRepository SportCategory { get; set; }
    public ISportLookupRepository SportLookup { get; set; }
    public ISportTypeRepository SportType { get; set; }
    public UnitOfWork(AplicationDataContext context,
            ILookupCategoryRepository lookupCategory,
            ISportCategoryRepository sportCategory,
            ISportLookupRepository sportLookup,
            ISportTypeRepository sportType)
    {
        _context = context;
        LookupCategory = lookupCategory;
        SportCategory = sportCategory;
        SportLookup = sportLookup;
        SportType = sportType;
    }

    public void SaveAsync()
    {
        _context.SaveChanges();
    }
}

