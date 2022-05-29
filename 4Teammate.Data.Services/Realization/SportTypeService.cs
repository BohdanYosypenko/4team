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

    public List<SportType> GetAll()
    {
        return _mapper.Map<List<SportType>>(_unitOfWork.SportType.GetAll());
    }

    public SportType GetById(int id)
    {
        return _mapper.Map<SportType>(_unitOfWork.SportType.GetById(id));
    }

    public List<SportType> GetByCategoryId(int categoryId)
    {
        return _mapper.Map<List<SportType>>(_unitOfWork.SportType.GetAll().Where(c => c.CategoryFID == categoryId));
    }

    public SportType Create(SportType entity)
    {
        var result = _unitOfWork.SportType.Create(_mapper.Map<SportTypeEntity>(entity));
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
