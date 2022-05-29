using _4Teammate.Data.Context;
using _4Teammate.Data.Entities;
using _4Teammate.Data.Repositories.Interfaces;

namespace _4Teammate.Data.Repositories.Realization;

public class SportLookupRepository : ISportLookupRepository
{

    private readonly AplicationDataContext _context;
    public SportLookupRepository(AplicationDataContext context)
    {
        _context = context;
    }

    public List<SportLookupEntity> GetAll()
    {
        return _context.SportLookups.ToList();
    }

    public SportLookupEntity GetById(int id)
    {
        return _context.SportLookups
            .Where(c => c.Id == id)
            .FirstOrDefault();
    }

    public SportLookupEntity Create(SportLookupEntity entity)
    {
        return _context.SportLookups.Add(entity).Entity;
    }

    public SportLookupEntity Update(SportLookupEntity entity)
    {
        return _context.SportLookups.Update(entity).Entity;
    }

    public void Delete(SportLookupEntity entity)
    {
        _context.SportLookups.Remove(entity);
    }
}

