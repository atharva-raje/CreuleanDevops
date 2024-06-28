using BusinessLOgic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Irepositeries;
using DAL.Entites;



namespace BusinessLOgic.IServices
{
    public interface IWorkItemServices
    {
         
           Task<IEnumerable<WorkItem>> GetWorkItemsService();
          Task<WorkItem> AddWorkItemsService(WorkItemModel workItemModel);
          Task<WorkItem> UpdateWorkItemsService(int id,WorkItemModel workItemModel);
           Task<int>  DeleteWorkItemsService(int WorkItemId);
    }
}
