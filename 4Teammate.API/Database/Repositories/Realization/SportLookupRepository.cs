using _4Teammate.API.Database.Entities;
using _4Teammate.API.Database.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _4Teammate.API.Database.Repositories.Realization
{
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
}
