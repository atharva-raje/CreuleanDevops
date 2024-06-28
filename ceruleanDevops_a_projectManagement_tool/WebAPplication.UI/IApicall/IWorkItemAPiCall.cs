using BusinessLOgic.Models;
using WebAPplication.UI.UiModels;

namespace WebAPplication.UI.IApicall
{
    public interface IWorkItemAPiCall
    {
        Task<IEnumerable<WorkItemModel>> GetWorkItems();
        Task<HttpResponseMessage> AddWorkItem(UIWorkItem uiWorkItem);
        Task<IEnumerable<AreaWithoutId>> GetAreas();
        Task<IEnumerable<IterationWIthoutId>> Getiterations(String areaname);
        Task<IEnumerable<StatusModelWithoutId>> GetStatusModels();
        Task<IEnumerable<UserModel>> GetUsers();
        Task<bool> deleteWorkItem(int id);
        Task<string> GetStatus(int statusId);
    }
}
