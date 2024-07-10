using DAL.Dbcontext;
using DAL.Entites;
using DAL.Irepositeries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositeries
{
    public class PriorityRepository : IPriorityRepository
    {
        private readonly WorkItemsDbContext _workItemsDbContext;
        public PriorityRepository(WorkItemsDbContext workItemsDbContext)
        {
            _workItemsDbContext = workItemsDbContext;
        }

        public async Task<IEnumerable<Priorities>> GetPriorities()
        {
             return await  _workItemsDbContext.Priorities.ToListAsync();
        }

        public async Task<Priorities> GetPriorityId(string priorityName)
        {
            return await _workItemsDbContext.Priorities.FirstOrDefaultAsync(p => p.PritoryName == priorityName);
        }
        public async Task<Priorities> GetPriorityName(int priorityid)
        {
            return await _workItemsDbContext.Priorities.FirstOrDefaultAsync(p => p.PriorityId == priorityid);
        }
    }
}
