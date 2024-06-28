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
    public class IterationRepository : IIterationRepository
    {
        private readonly WorkItemsDbContext _workItemsDbContext;
        public IterationRepository(WorkItemsDbContext workItemsDbContext)
        {
            _workItemsDbContext = workItemsDbContext;
        }
        public async Task<IEnumerable<Iterations>> GetIterations(int AreaId)
        {
            return await _workItemsDbContext.Iterations.Where(i => i.AreaId == AreaId).ToListAsync();
        }
    }
}
