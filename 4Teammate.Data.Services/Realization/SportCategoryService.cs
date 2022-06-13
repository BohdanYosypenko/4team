using System.Linq.Expressions;
using _4Teammate.Data.Entities;
using _4Teammate.Data.Repositories.Interfaces;
using _4Teammate.Domain.Models;
using _4Teammate.Domain.Services.Interfaces;
using AutoMapper;

namespace _4Teammate.Data.Services.Realization;

public class SportCategoryService : ISportCategoryService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;

  public SportCategoryService(IUnitOfWork unitOfWork,
      IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<List<SportCategory>> GetAllAsync()
  {
    return _mapper.Map<List<SportCategory>>(await _unitOfWork.SportCategory.GetAllAsync());
  }

  public async Task<SportCategory> GetByIdAsync(int id)
  {
    Expression<Func<SportCategoryEntity, bool>> filter = a => a.Id == id;
    return _mapper.Map<SportCategory>(await _unitOfWork.SportCategory.GetByIdAsync(filter));
  }

  public async Task<SportCategory> CreateAsync(SportCategory entity)
  {
    var result = await _unitOfWork.SportCategory.CreateAsync(_mapper.Map<SportCategoryEntity>(entity));
    _unitOfWork.SaveAsync();
    return _mapper.Map<SportCategory>(result);
  }

  public SportCategory Update(SportCategory entity)
  {
    var result = _unitOfWork.SportCategory.Update(_mapper.Map<SportCategoryEntity>(entity));
    _unitOfWork.SaveAsync();
    return _mapper.Map<SportCategory>(result);
  }

  public void Delete(SportCategory entity)
  {
    _unitOfWork.LookupCategory.Delete(_mapper.Map<LookupCategoryEntity>(entity));
    _unitOfWork.SaveAsync();
  }
}
