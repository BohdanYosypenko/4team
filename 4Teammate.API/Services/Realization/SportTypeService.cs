using _4Teammate.API.Database.Entities;
using _4Teammate.API.Database.Repositories.Interfaces;
using _4Teammate.API.Models;
using _4Teammate.API.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace _4Teammate.API.Services.Realization
{
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
}
