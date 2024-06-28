using DAL.Dbcontext;
using DAL.Entites;
using DAL.Irepositeries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositeries
{
    public class WorkItemRepository : IWorkItemsRespository
    {
        private readonly WorkItemsDbContext _workItemsDbContext;
        public WorkItemRepository(WorkItemsDbContext workItemsDbContext)
        {
            _workItemsDbContext = workItemsDbContext;
        }
        public async Task<WorkItem> AddWorkitem(WorkItem workItem)
        {
            var result = await _workItemsDbContext.WorkItems.AddAsync(workItem);
            await _workItemsDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<int> DeleteWorkItem(int WorkItemId)
        {
            var result = await _workItemsDbContext.WorkItems
                .FirstOrDefaultAsync(e => e.Id == WorkItemId);
            if (result != null)
            {
                _workItemsDbContext.WorkItems.Remove(result);
                await _workItemsDbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
            public async Task<WorkItem> GetWorkitem(int WorkItemId)
            {
                return await _workItemsDbContext.WorkItems.FirstOrDefaultAsync(w => w.Id == WorkItemId);
            }

            public async Task<IEnumerable<WorkItem>> GetWorkitems()
            {
                return await _workItemsDbContext.WorkItems.ToListAsync();
            }

            public async Task<WorkItem> UpdateWorkitem(int id,WorkItem WorkItem)
            {
                var result = await _workItemsDbContext.WorkItems
                    .FirstOrDefaultAsync(e => e.Id == id);

                if (result != null)
                {
                    result.Id = id;
                    result.Name = WorkItem.Name;
                    result.Description = WorkItem.Description;
                    result.iteration = WorkItem.iteration;
                    result.area = WorkItem.area;
                    result.Type = WorkItem.Type;
                    result.startDate = WorkItem.startDate;
                    result.endDate = WorkItem.endDate;
                    result.status = WorkItem.status;
                    result.priority = WorkItem.priority;
                    await _workItemsDbContext.SaveChangesAsync();
                    return result;

                }
                return null;
            }
        
    }
}
