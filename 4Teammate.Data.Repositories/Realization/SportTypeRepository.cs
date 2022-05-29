using _4Teammate.Data.Context;
using _4Teammate.Data.Entities;
using _4Teammate.Data.Repositories.Interfaces;

namespace _4Teammate.Data.Repositories.Realization;

public class SportTypeRepository : ISportTypeRepository
{
    private readonly AplicationDataContext _context;
    public SportTypeRepository(AplicationDataContext context)
    {
        _context = context;
    }

    public List<SportTypeEntity> GetAll()
    {
        return _context.SportTypes.ToList();
    }

    public SportTypeEntity GetById(int id)
    {
        return _context.SportTypes
            .Where(c => c.Id == id)
            .FirstOrDefault();
    }

    public SportTypeEntity Create(SportTypeEntity entity)
    {
        return _context.SportTypes.Add(entity).Entity;
    }

    public SportTypeEntity Update(SportTypeEntity entity)
    {
        return _context.SportTypes.Update(entity).Entity;
    }

    public void Delete(SportTypeEntity entity)
    {
        _context.SportTypes.Remove(entity);
    }
}
