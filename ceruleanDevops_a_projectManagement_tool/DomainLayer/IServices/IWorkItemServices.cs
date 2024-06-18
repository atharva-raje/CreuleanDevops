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
         
       

        public  Task<IEnumerable<WorkItem>> GetWorkItemsService();
        public Task<WorkItem> AddWorkItemsService(WorkItemModel workItemModel);
        public Task<WorkItem> UpdateWorkItemsService(int id,WorkItemModel workItemModel);
        public  Task<int>  DeleteWorkItemsService(int WorkItemId);



    }
}
