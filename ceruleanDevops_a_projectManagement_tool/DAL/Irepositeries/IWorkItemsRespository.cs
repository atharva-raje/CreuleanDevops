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
        Task<IEnumerable<WorkItem>> GetWorkitemsAsync();
        Task<WorkItem> GetWorkitemByIdAsync(string WorkItemId);
        Task<WorkItem> AddWorkitemAsync(WorkItem WorkItem);
        Task<WorkItem> UpdateWorkitemAsync(WorkItem WorkItem);
        Task<int> DeleteWorkItemAsync(string WorkItemId);
        Task<WorkItem> GetWorkItemIdByUniqueKey(string  UniqueKey);
         

    }
}