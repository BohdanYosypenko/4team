using _4Teammate.API.Database.Entities;
using _4Teammate.API.Database.Repositories.Interfaces;
using _4Teammate.API.Models;
using _4Teammate.API.Services.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace _4Teammate.API.Services.Realization
{
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

        public List<LookupCategory> GetAll()
        {
            return _mapper.Map<List<LookupCategory>>(_unitOfWork.LookupCategory.GetAll());
        }

        public LookupCategory GetById(int id)
        {
            return _mapper.Map<LookupCategory>(_unitOfWork.LookupCategory.GetById(id));
        }

        public LookupCategory Create(LookupCategory entity)
        {
            var result = _unitOfWork.LookupCategory.Create(_mapper.Map<LookupCategoryEntity>(entity));
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
}
