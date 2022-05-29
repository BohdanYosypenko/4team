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

    public List<SportLookup> GetAll()
    {
        return _mapper.Map<List<SportLookup>>(_unitOfWork.SportLookup.GetAll());
    }

    public SportLookup GetById(int id)
    {
        return _mapper.Map<SportLookup>(_unitOfWork.SportLookup.GetById(id));
    }

    public SportLookup Create(SportLookup entity)
    {
        var result = _unitOfWork.SportLookup.Create(_mapper.Map<SportLookupEntity>(entity));
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
