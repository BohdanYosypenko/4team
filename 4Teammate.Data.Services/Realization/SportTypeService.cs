using System.Linq.Expressions;
using _4Teammate.Data.Entities;
using _4Teammate.Data.Repositories.Interfaces;
using _4Teammate.Domain.Models;
using _4Teammate.Domain.Services.Interfaces;
using AutoMapper;

namespace _4Teammate.Data.Services.Realization;

public class SportTypeService : ISportTypeService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;

  public SportTypeService(IUnitOfWork unitOfWork,
      IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<List<SportType>> GetAllAsync()
  {
    return _mapper.Map<List<SportType>>(await _unitOfWork.SportType.GetAllAsync());
  }

  public async Task<SportType> GetByIdAsync(int id)
  {
    Expression<Func<SportTypeEntity, bool>> filter = a => a.Id == id;
    return _mapper.Map<SportType>(await _unitOfWork.SportType.GetByIdAsync(filter));
  }

  public async Task<SportType> CreateAsync(SportType entity)
  {
    var result = await _unitOfWork.SportType.CreateAsync(_mapper.Map<SportTypeEntity>(entity));
    _unitOfWork.SaveAsync();
    return _mapper.Map<SportType>(result);
  }

  public SportType Update(SportType entity)
  {
    var result = _unitOfWork.SportType.Update(_mapper.Map<SportTypeEntity>(entity));
    _unitOfWork.SaveAsync();
    return _mapper.Map<SportType>(result);
  }

  public void Delete(SportType entity)
  {
    _unitOfWork.SportType.Delete(_mapper.Map<SportTypeEntity>(entity));
    _unitOfWork.SaveAsync();
  }
}
