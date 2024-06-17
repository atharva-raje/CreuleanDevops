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
        Task<WorkItem> GetWorkitem(int employeeId);
        Task<WorkItem> AddWorkitem(WorkItem employee);
        Task<WorkItem> UpdateWorkitem(WorkItem employee);

    }
}