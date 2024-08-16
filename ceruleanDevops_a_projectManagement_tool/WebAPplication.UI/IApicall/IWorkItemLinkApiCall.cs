using BusinessLOgic.Models;

namespace WebAPplication.UI.IApicall
{
    public interface IWorkItemLinkApiCall
    {
        Task<bool> LinkWorkItems(string sourceWorkItemId, string targetWorkItemId, int linkType);
        Task<HttpResponseMessage> DeleteLinks(string sourceId);
        Task<List<WorkItemLinkModel>> GetLinksForWorkItem(string sourceId);

    }
}
