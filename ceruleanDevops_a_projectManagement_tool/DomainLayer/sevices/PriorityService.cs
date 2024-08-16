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
    public class PriorityService : IPriorityService
    {
        private readonly IPriorityRepository _priorityRepository;
        public PriorityService(IPriorityRepository priorityRepository)
        {
            _priorityRepository = priorityRepository;
        }

        public Task<IEnumerable<Priorities>> GetPriorities()
        {
            return _priorityRepository.GetPriorities();
        }

        public async Task<int> GetPriorityId(string priorityName)
        {
            var result =  await _priorityRepository.GetPriorityId(priorityName);
            return result. PriorityId;
        }

        public async Task<string> GetPriorityName(int id)
        {
            var result = await _priorityRepository.GetPriorityName(id);
            return result.PriorityName; 
     
        }
    }
}
