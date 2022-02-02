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
            return _context.Categories.ToList();
        }

        public SportCategoryEntity GetById(int id)
        {
            return _context.Categories
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public SportCategoryEntity Create(SportCategoryEntity entity)
        {
            return _context.Categories.Add(entity).Entity;
        }

        public SportCategoryEntity Update(SportCategoryEntity entity)
        {
            return _context.Categories.Update(entity).Entity;
        }

        public void Delete(SportCategoryEntity entity)
        {
            _context.Categories.Remove(entity);
        }
    }
}
