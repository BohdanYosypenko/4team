using System.Linq.Expressions;
using _4Teammate.Data.Context;
using _4Teammate.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace _4Teammate.Data.Repositories.Realization;

public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : class
{
  private readonly AplicationDataContext _context;

  public BaseRepository(AplicationDataContext context)
  {
    _context = context;
  }

  public async Task<List<Entity>> GetAllAsync(Expression<Func<Entity, bool>> filter = null,
            Func<IQueryable<Entity>, IIncludableQueryable<Entity, object>> include = null,
            Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
            int? pageNumber = null, int? pageSize = null,
            bool asNoTracking = false)
  {
    IQueryable<Entity> query = GetQuery(filter, include, asNoTracking);

    if (orderBy != null)
      query = orderBy(query);

    if (pageNumber != null && pageSize != null)
      query = query.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);

    return await query.ToListAsync();
  }

  public async Task<Entity> GetByIdAsync(Expression<Func<Entity, bool>> filter = null,
          Func<IQueryable<Entity>, IIncludableQueryable<Entity, object>> include = null,
          bool asNoTracking = false)
  {
    IQueryable<Entity> query = GetQuery(filter, include, asNoTracking);
    return await query.FirstOrDefaultAsync();
  }

  public async Task<Entity> CreateAsync(Entity entity)
  {
    return (await _context.Set<Entity>().AddAsync(entity)).Entity;
  }

  public Entity Update(Entity entity)
  {
    return _context.Set<Entity>().Update(entity).Entity;
  }

  public void Delete(Entity entity)
  {
    _context.Set<Entity>().Remove(entity);
  }

  private IQueryable<Entity> GetQuery(Expression<Func<Entity, bool>> filter = null,
            Func<IQueryable<Entity>, IIncludableQueryable<Entity, object>> include = null,
            bool asNoTracking = false)
  {
    IQueryable<Entity> query = _context.Set<Entity>();

    if (asNoTracking)
      query = query.AsNoTracking();

    if (include != null)
      query = include(query);

    if (filter != null)
      query = query.Where(filter);

    return query;
  }
}
