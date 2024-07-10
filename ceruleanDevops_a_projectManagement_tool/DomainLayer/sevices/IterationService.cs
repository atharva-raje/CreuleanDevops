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
    public class IterationService : IIterationService
    {
        private readonly IMapper _mapper;
        private readonly IIterationRepository iterationRepository;

        public IterationService(IIterationRepository _iterationRepository, IMapper mapper)
        {
            _mapper = mapper;
            iterationRepository = _iterationRepository;
        }

        public async Task<int> GetIterationId(string iterationName)
        {
            var result = await iterationRepository.GetIterationsIdAsync(iterationName);
            return result.IterationId;    
        }

        public async Task<string> GetIterationName(int id)
        {
            var result = await iterationRepository.GetIterationsNameAsync(id);
            return result.IterationName;
        }

        public async Task<IEnumerable<Iterations>> GetIterations(int AreaId)
        {
             return await iterationRepository.GetIterations(AreaId);
        }
    }
}
