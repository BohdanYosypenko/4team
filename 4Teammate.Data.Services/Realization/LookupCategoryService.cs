using System.Linq.Expressions;
using _4Teammate.Data.Entities;
using _4Teammate.Data.Repositories.Interfaces;
using _4Teammate.Domain.Models;
using _4Teammate.Domain.Services.Interfaces;
using AutoMapper;

namespace _4Teammate.Data.Services.Realization;

public class LookupCategoryService : ILookupCategoryService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;

  public LookupCategoryService(IUnitOfWork unitOfWork,
      IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<List<LookupCategory>> GetAllAsync()
  {
    return _mapper.Map<List<LookupCategory>>(await _unitOfWork.LookupCategory.GetAllAsync());
  }

  public async Task<LookupCategory> GetByIdAsync(int id)
  {    
    Expression<Func<LookupCategoryEntity, bool>> filter = a => a.Id == id;    
    return _mapper.Map<LookupCategory>(await _unitOfWork.LookupCategory.GetByIdAsync(filter));
  }

  public async Task<LookupCategory> CreateAsync(LookupCategory entity)
  {
    var result = await _unitOfWork.LookupCategory.CreateAsync(_mapper.Map<LookupCategoryEntity>(entity));
    _unitOfWork.SaveAsync();
    return _mapper.Map<LookupCategory>(result);
  }

  public LookupCategory Update(LookupCategory entity)
  {
    var result = _unitOfWork.LookupCategory.Update(_mapper.Map<LookupCategoryEntity>(entity));
    _unitOfWork.SaveAsync();
    return _mapper.Map<LookupCategory>(result);
  }

  public void Delete(LookupCategory entity)
  {
    _unitOfWork.LookupCategory.Delete(_mapper.Map<LookupCategoryEntity>(entity));
    _unitOfWork.SaveAsync();
  }
}
