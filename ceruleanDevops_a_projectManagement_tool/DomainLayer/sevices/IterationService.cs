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
        public async Task<IEnumerable<Iterations>> GetIterations(int AreaId)
        {
             return await iterationRepository.GetIterations(AreaId);
        }
    }
}
