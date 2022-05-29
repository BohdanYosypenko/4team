using _4Teammate.Domain.Models;

namespace _4Teammate.Domain.Services.Interfaces;

public interface ISportTypeService : IBaseService<SportType>
{
    public List<SportType> GetByCategoryId(int categoryId);
}
