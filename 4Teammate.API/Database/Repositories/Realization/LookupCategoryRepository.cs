using _4Teammate.API.Database.Entities;
using _4Teammate.API.Database.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _4Teammate.API.Database.Repositories.Realization
{
    public class LookupCategoryRepository : ILookupCategoryRepository
    {
        private readonly AplicationDataContext _context;
        public LookupCategoryRepository(AplicationDataContext context)
        {
            _context = context;
        }

        public List<LookupCategoryEntity> GetAll()
        {
            return _context.LookupCategories.ToList();
        }

        public LookupCategoryEntity GetById(int id)
        {
            return _context.LookupCategories
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public LookupCategoryEntity Create(LookupCategoryEntity entity)
        {
            return _context.LookupCategories.Add(entity).Entity;
        }

        public LookupCategoryEntity Update(LookupCategoryEntity entity)
        {
            return _context.LookupCategories.Update(entity).Entity;
        }

        public void Delete(LookupCategoryEntity entity)
        {
            _context.LookupCategories.Remove(entity);
        }
    }
}
