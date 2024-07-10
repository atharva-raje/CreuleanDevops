using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Irepositeries
{
    public  interface IWorkItemLinkRepository
    {
        Task AddWorkItemLinkAsync(WorkitemLink workItemLink);
        Task<List<WorkitemLink>> GetWorkItemLinksAsync(string workItemId);
        Task<bool> DeleteAllSourceWorkItemLinkAsync(string workItemId);
    }
}
