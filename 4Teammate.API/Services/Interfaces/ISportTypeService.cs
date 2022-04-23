using _4Teammate.API.Models;
using System.Collections.Generic;

namespace _4Teammate.API.Services.Interfaces
{
    public interface ISportTypeService : IBaseService<SportType>
    {
        public List<SportType> GetByCategoryId(int categoryId);
    }
}
