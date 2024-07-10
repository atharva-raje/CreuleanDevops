using AutoMapper;
using BusinessLOgic.IServices;
using DAL.Entites;
using DAL.Irepositeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.sevices
{
    public class TypeService : ITypeService
    {
        private readonly IMapper _mapper;
        private readonly IWorkItemsRespository _workItemsRespository;
        private readonly IAreaService _areaService;
        private readonly IIterationService iterationService;
        private readonly ITypeRepository _typeRepository;
        public TypeService(IWorkItemsRespository workItemsRespository, IMapper mapper, IAreaService areaService, IIterationService iterationService, ITypeRepository typeRepository)
        {
            _mapper = mapper;
            _workItemsRespository = workItemsRespository;
            _areaService = areaService;
            this.iterationService = iterationService;
            _typeRepository = typeRepository;
        }
        public async Task<int> GetTypeId(string type)
        {
           var result = await _typeRepository.GetTypeIdAsync(type);
            return result.TypeId;
        }

        public async Task<string> GetTypeName(int typeid)
        {
            var result = await _typeRepository.GetTypeName(typeid);
            return result.TypeName;
        }

        public async Task<IEnumerable<Types>> GetTypes()
        {
            return await _typeRepository.GetTypesAsync();
        }
    }
}
