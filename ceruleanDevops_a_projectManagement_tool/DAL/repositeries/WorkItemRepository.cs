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
        public async Task<WorkItem> AddWorkitemAsync(WorkItem workItem)
        {
            var result = await _workItemsDbContext.WorkItems.AddAsync(workItem);
            await _workItemsDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<int> DeleteWorkItemAsync(string WorkItemId)
        {
            var result = await _workItemsDbContext.WorkItems
                .FirstOrDefaultAsync(e => e.WorkItemId == WorkItemId);
            if (result != null)
            {
                _workItemsDbContext.WorkItems.Remove(result);
                await _workItemsDbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
            public async Task<WorkItem> GetWorkitemByIdAsync(string WorkItemId)
            {
                return await _workItemsDbContext.WorkItems.FirstOrDefaultAsync(w => w.WorkItemId == WorkItemId);
            }

        public async Task<WorkItem> GetWorkItemIdByUniqueKey(string UniqueKey)
        {
             return await _workItemsDbContext.WorkItems.FirstOrDefaultAsync(w => w.WorkItemId == UniqueKey);
        }

        public async Task<IEnumerable<WorkItem>> GetWorkitemsAsync()
            {
                return await _workItemsDbContext.WorkItems.ToListAsync();
            }

            public async Task<WorkItem> UpdateWorkitemAsync(WorkItem WorkItem)
            {
                var result = await _workItemsDbContext.WorkItems
                    .FirstOrDefaultAsync(e => e.WorkItemId == WorkItem.WorkItemId);

                if (result != null)
                {
                     
                    result.Name = WorkItem.Name;
                    result.Description = WorkItem.Description;
                    result.IterationId = WorkItem.IterationId;
                    result.AreaId = WorkItem.AreaId;
                    result.TypeId = WorkItem.TypeId;
                    result.ActualStartDate = WorkItem.ActualStartDate;
                    result.ActualEndDate = WorkItem.ActualEndDate;
                    result.StatusId = WorkItem.StatusId;
                    result.PriorityId = WorkItem.PriorityId;
                    result.ExpectedStartDate = WorkItem.ExpectedStartDate;
                    result.ExpectedEndDate = WorkItem.ExpectedEndDate;
                    result.AssigneeId = WorkItem.AssigneeId;
                    result.ReporterId = WorkItem.ReporterId;
                    result.StoryPoints = WorkItem.StoryPoints;
                    await _workItemsDbContext.SaveChangesAsync();
                    return result;

                }
                return null;
            }
        

    }
}
