using System.Linq.Expressions;
using _4Teammate.Data.Entities;
using _4Teammate.Data.Repositories.Interfaces;
using _4Teammate.Domain.Models;
using _4Teammate.Domain.Services.Interfaces;
using AutoMapper;

namespace _4Teammate.Data.Services.Realization;

public class SportLookupService : ISportLookupService
{
  private readonly IUnitOfWork _unitOfWork;
  private readonly IMapper _mapper;

  public SportLookupService(IUnitOfWork unitOfWork,
      IMapper mapper)
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public async Task<List<SportLookup>> GetAllAsync()
  {
    return _mapper.Map<List<SportLookup>>(await _unitOfWork.SportLookup.GetAllAsync());
  }

  public async Task<SportLookup> GetByIdAsync(int id)
  {
    Expression<Func<SportLookupEntity, bool>> filter = a => a.Id == id;
    return _mapper.Map<SportLookup>(await _unitOfWork.SportLookup.GetByIdAsync(filter));
  }

  public async Task<SportLookup> CreateAsync(SportLookup entity)
  {
    var result = await _unitOfWork.SportLookup.CreateAsync(_mapper.Map<SportLookupEntity>(entity));
    _unitOfWork.SaveAsync();
    return _mapper.Map<SportLookup>(result);
  }

  public SportLookup Update(SportLookup entity)
  {
    var result = _unitOfWork.SportLookup.Update(_mapper.Map<SportLookupEntity>(entity));
    _unitOfWork.SaveAsync();
    return _mapper.Map<SportLookup>(result);
  }

  public void Delete(SportLookup entity)
  {
    _unitOfWork.SportLookup.Delete(_mapper.Map<SportLookupEntity>(entity));
    _unitOfWork.SaveAsync();
  }
}
