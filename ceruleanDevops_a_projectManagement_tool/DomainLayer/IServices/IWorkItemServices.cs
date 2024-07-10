using BusinessLOgic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Irepositeries;
using DAL.Entites;
using WebAPplication.UI.UiModels;



namespace BusinessLOgic.IServices
{
    public interface IWorkItemServices
    {
         
        Task<IEnumerable<WorkItem>> GetWorkItemsService();
        Task<WorkItem> AddWorkItemsService(UIWorkItem workItemModel);
        Task<WorkItem> UpdateWorkItemsService(UIWorkItem workItemModel);
        Task<int>  DeleteWorkItemsService(string WorkItemId);
        Task<WorkItem> GetWorkItemById(string  Id);
        Task<string> GenerateUniqueKeyAsync(UIWorkItem workItem);



    }
}
