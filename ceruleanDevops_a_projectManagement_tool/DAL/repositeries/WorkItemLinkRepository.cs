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
    public class WorkItemLinkRepository : IWorkItemLinkRepository
    {
        private readonly WorkItemsDbContext _workItemsDbContext;
        public WorkItemLinkRepository(WorkItemsDbContext workItemsDbContext)
        {
            _workItemsDbContext = workItemsDbContext;
        }
        public async Task AddWorkItemLinkAsync(WorkitemLink workItemLink)
        {
            await _workItemsDbContext.WorkitemLinks.AddAsync(workItemLink);
            await _workItemsDbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAllSourceWorkItemLinkAsync(string workItemId)
        {
            try
            {
                var all = _workItemsDbContext.WorkitemLinks.Where(item => item.SourceWorkItemId == workItemId || item.TargetWorkItemId == workItemId);
                _workItemsDbContext.WorkitemLinks.RemoveRange(all);
                await _workItemsDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         
        public async Task<List<WorkitemLink>> GetWorkItemLinksAsync(string workItemId)
        {
            return await _workItemsDbContext.WorkitemLinks
                                 .Where(link => link.SourceWorkItemId == workItemId)
                                 .Include(link => link.SourceWorkItem)
                                 .ToListAsync();
        }
         
       
    }
}
