using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Irepositeries
{
    public interface IWorkItemsRespository
    {
        Task<IEnumerable<WorkItem>> GetWorkitems();
        Task<WorkItem> GetWorkitem(int WorkItemId);
        Task<WorkItem> AddWorkitem(WorkItem WorkItem);
        Task<WorkItem> UpdateWorkitem(int id,WorkItem WorkItem);
        Task<int> DeleteWorkItem(int WorkItemId);


    }
}