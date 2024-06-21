using BusinessLOgic.Models;
using WebAPplication.UI.UiModels;

namespace WebAPplication.UI.IApicall
{
    public interface IWorkItemAPiCall
    {
        Task<IEnumerable<WorkItemModel>> GetWorkItems();
        Task<HttpResponseMessage> AddWorkItem(UIWorkItem uiWorkItem);
    }
}
