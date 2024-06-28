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
    public class AreaRepository : IAreaRepository
    {
        private readonly WorkItemsDbContext _workItemsDbContext;
        public AreaRepository(WorkItemsDbContext workItemsDbContext)
        {
            _workItemsDbContext = workItemsDbContext;
        }

        public async Task<Areas> GetAreaId(string name)
        {
            return await _workItemsDbContext.Areas.FirstOrDefaultAsync(e => e.areaName == name);
        }

        public async Task<IEnumerable<Areas>> GetAreas()
        {
            return await _workItemsDbContext.Areas.ToListAsync();
        }
    }
}
