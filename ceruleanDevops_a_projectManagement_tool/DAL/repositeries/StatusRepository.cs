using DAL.Dbcontext;
using DAL.Entites;
using DAL.Irepositeries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositeries
{
    public class StatusRepository : IStatusRepository
    {
        private readonly WorkItemsDbContext _workItemsDbContext;
        public StatusRepository(WorkItemsDbContext workItemsDbContext)
        {
            _workItemsDbContext = workItemsDbContext;
        }

        public async Task<IEnumerable<Status>> GetStatuses()
        {
             return await _workItemsDbContext.Statuses.ToListAsync();
        }

        public async Task<IEnumerable<Status>> GetStatusesByType(int typeid)
        {
            return await _workItemsDbContext.Statuses.Where(s => s.Type.TypeId == typeid).ToListAsync();
        }

        public async Task<Status> GetStatusId(string name)
        {
            return await _workItemsDbContext.Statuses.FirstOrDefaultAsync(e => e.StatusName == name);
        }

        public async Task<Status> GetStatusName(int statusId)
        {
            return await _workItemsDbContext.Statuses.FirstOrDefaultAsync(e => e.StatusId == statusId);
        }
    }
}
