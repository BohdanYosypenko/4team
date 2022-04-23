using _4Teammate.API.Database.Entities;
using _4Teammate.API.Database.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _4Teammate.API.Database.Repositories.Realization
{
    public class SportCategoryRepository : ISportCategoryRepository
    {
        private readonly AplicationDataContext _context;
        public SportCategoryRepository(AplicationDataContext context)
        {
            _context = context;
        }

        public List<SportCategoryEntity> GetAll()
        {
            return _context.SportCategories.ToList();
        }

        public SportCategoryEntity GetById(int id)
        {
            return _context.SportCategories
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public SportCategoryEntity Create(SportCategoryEntity entity)
        {
            return _context.SportCategories.Add(entity).Entity;
        }

        public SportCategoryEntity Update(SportCategoryEntity entity)
        {
            return _context.SportCategories.Update(entity).Entity;
        }

        public void Delete(SportCategoryEntity entity)
        {
            _context.SportCategories.Remove(entity);
        }
    }
}
