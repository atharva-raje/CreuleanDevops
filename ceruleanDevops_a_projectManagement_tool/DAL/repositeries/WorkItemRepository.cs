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


        public async Task<WorkItem> GetWorkitem(int WorkItemId)
        {
            return await _workItemsDbContext.WorkItems.FirstOrDefaultAsync(w => w.Id == WorkItemId);
        }

        public async Task<IEnumerable<WorkItem>> GetWorkitems()
        {
            return await _workItemsDbContext.WorkItems.ToListAsync();

        }

        public async Task<WorkItem> UpdateWorkitem(WorkItem workItem)
        {
            var result = await _workItemsDbContext.WorkItems
                .FirstOrDefaultAsync(e => e.Id == workItem.Id);

            if (result != null)
            {
                result.Id = workItem.Id;
                result.Name = workItem.Name;
                result.Description = workItem.Description;
                result.iteration = workItem.iteration;
                result.area = workItem.area;
                result.Type = workItem.Type;
                await _workItemsDbContext.SaveChangesAsync();
                return result;

            }
            return null;
        }
    }
}
