using BusinessLOgic.Models;
using Microsoft.Identity.Client;
using WebAPplication.UI.UiModels;

namespace WebAPplication.UI.IApicall
{
    public interface IWorkItemAPiCall
    {
        Task<IEnumerable<WorkItemModel>> GetWorkItems();
         
        Task<HttpResponseMessage> AddWorkItem(UIWorkItem uiWorkItem);
        Task<IEnumerable<AreaWithoutId>> GetAreas();
        Task<IEnumerable<IterationWIthoutId>> Getiterations(int areaId);
        Task<IEnumerable<StatusModelWithoutId>> GetStatusModels(int TypeId);
        Task<IEnumerable<UserModel>> GetUsers();
        Task<bool> deleteWorkItem(string id);
        Task<string> GetStatus(int statusId);
        Task<HttpResponseMessage> UpdateWorkItem(UIWorkItem uiWorkItem);
        Task<UIWorkItem> GetWorkItemById(string id);
        Task<int> GetWorkItemIdByKey(string key);
        Task<IEnumerable<TypeModel>> GetTypeModels();
        Task<IEnumerable<PriorityModel>> GetPriorityModels();
        Task<string> GetTypeName(int id);
        Task<string> GetIterationName(int id);
        Task<string> GetStatusName(int id);
        Task<string> GetUserName(int id);
        Task<string> GetAreaName(int id);
    }
}
